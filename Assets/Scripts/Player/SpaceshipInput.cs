using UnityEngine;

public class SpaceshipInput : MonoBehaviour
{
    [Tooltip("When true, mouse + mousewheel are used for input, and A/D are used for strafing.\n\nOtherwise, WASD are used for flying.")]
    public bool useMouseInput = true;
    
    [Tooltip("When using keyboard/joystick, roll added to horizontal stick movement.")]
    public bool addRoll = true;

    [Space] 
    
    [Range(-1, 1)] public float pitch;
    [Range(-1, 1)] public float yaw;
    [Range(-1, 1)] public float roll;
    [Range(-1, 1)] public float strafe;
    [Range(-1, 1)] public float throttle;

    private const float ThrottleSpeed = 50f;
    private const float RollSpeed = 5f;

    private Spaceship ship;
    public float deadZone;

    private void Awake() {
        ship = GetComponent<Spaceship>();
    }

    // Update is called once per frame
    void Update()
    {
        if (useMouseInput)
        {
            strafe = Input.GetAxis("Horizontal");
            SetStickCmdUsingMouse();
            UpdateMouseWheelThrottle();
            UpdateKeyboardThrottle(KeyCode.W, KeyCode.S);
            UpdateKeyboardRoll(KeyCode.Q, KeyCode.E);
        }
        else
        {
            pitch = Input.GetAxis("Vertical");
            yaw = Input.GetAxis("Horizontal");

            if (addRoll)
            {
                roll = -Input.GetAxis("Horizontal") * 0.5f;
            }

            strafe = 0.0f;
            UpdateKeyboardThrottle(KeyCode.R, KeyCode.F);
        }
    }

    private void UpdateKeyboardRoll(KeyCode increaseKey, KeyCode decreaseKey) {
        float target = 0;
        
        if (Input.GetKey(increaseKey))
        {
            target += 1f;
        }
        else if (Input.GetKey(decreaseKey))
        {
            target = -1f;
        }
        else
        {
            target = 0;
        }

        roll = Mathf.MoveTowards(roll, target, Time.deltaTime * RollSpeed);

    }

    /// <summary>
    /// Uses R and F to raise and lower throttle.
    /// </summary>
    private void UpdateKeyboardThrottle(KeyCode increaseKey, KeyCode decreaseKey) {
        float target = throttle;

        if (Input.GetKey(increaseKey))
        {
            target = 1.0f;
        }
        else if (Input.GetKey(decreaseKey))
        {
            target = 0.0f;
        }

        throttle = Mathf.MoveTowards(throttle, target, Time.deltaTime * ThrottleSpeed);
    }

    /// <summary>
    /// Uses the mouse to simulate a virtual joystick.
    /// When mouse is in center of screen, same as centered joystick.
    /// </summary>
    private void SetStickCmdUsingMouse() {
        Vector3 mousePos = Input.mousePosition;

        pitch =  (mousePos.y - (Screen.height * 0.5f)) / (Screen.height * 0.5f);
        yaw = (mousePos.x - (Screen.width * 0.5f)) / (Screen.width * 0.5f);

        pitch = Mathf.Clamp(pitch, -1.0f, 1.0f);
        if (pitch > -deadZone && pitch < deadZone)
            pitch = 0;
        yaw = Mathf.Clamp(yaw, -1.0f, 1.0f);
        if (yaw > -deadZone && yaw < deadZone)
            yaw = 0;
    }

    /// <summary>
    /// Use mouse scroll wheel to control throttle.
    /// </summary>
    private void UpdateMouseWheelThrottle() {
        throttle *= Input.GetAxis("Mouse ScrollWheel");
        throttle = Mathf.Clamp(throttle, 0.0f, 1.0f);
    }
}
