using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(SpaceshipPhysics))]
[RequireComponent(typeof(SpaceshipInput))]
public class Spaceship : MonoBehaviour
{
    #region Old Vars

    /*public float averageSpeed = 25f, accelerateSpeed = 45f, rotateSpeed = 2.5f;
    public Transform cameraPos;
    public Camera mainCam;
    public Transform spaceshipRoot;
    public float smoothCamera;

    private float speed;
    private Rigidbody rb;
    private Quaternion lookRotation; //Mouse look
    private float zRotation;
    private float smoothMouseX;
    private float smoothMouseY;
    private Vector3 defaultRotation;*/

    #endregion

    public bool isPlayer = false;

    private SpaceshipInput _input;
    private SpaceshipPhysics _physics;

    public static Spaceship PlayerShip {
        get { return playerShip; }
    }

    private static Spaceship playerShip;

    public bool UsingMouseInput {
        get { return _input.useMouseInput; }
    }

    public Vector3 Velocity {
        get { return _physics.Rigidbody.velocity; }
    }

    public float Throttle {
        get { return _input.throttle; }
    }

    private void Awake() {
        _input = GetComponent<SpaceshipInput>();
        _physics = GetComponent<SpaceshipPhysics>();
    }

    private void Update() {
        _physics.SetPhysicsInput(new Vector3(_input.strafe, 0.0f, _input.throttle),
            new Vector3(_input.pitch, _input.yaw, _input.roll));

        if (isPlayer)
        {
            playerShip = this;
        }
    }


    private void Start() {
        #region Old

        // rb = GetComponent<Rigidbody>();
        // rb.useGravity = false;
        // lookRotation = transform.rotation;
        // defaultRotation = spaceshipRoot.localEulerAngles;
        // zRotation = defaultRotation.z;

        #endregion

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    #region Old Function

    /*private void FixedUpdate() {
        //Right mouse to accelerate
        if (Input.GetMouseButton(1))
        {
            speed = Mathf.Lerp(speed, accelerateSpeed, Time.fixedDeltaTime * 3);
        }
        else
        {
            speed = Mathf.Lerp(speed, averageSpeed, Time.fixedDeltaTime * 10);
        }

        //Move direction
        Vector3 moveDir = new Vector3(0, 0, speed);

        //Transform Vector3 to local space
        moveDir = transform.TransformDirection(moveDir);

        //Rigidbody velocity to move
        rb.velocity = new Vector3(moveDir.x, moveDir.y, moveDir.z);

        //Camera follow - works!
        mainCam.transform.position = Vector3.Lerp(mainCam.transform.position, cameraPos.position,
            Time.fixedDeltaTime * smoothCamera);
        mainCam.transform.rotation = Quaternion.Lerp(mainCam.transform.rotation, cameraPos.rotation,
            Time.fixedDeltaTime * smoothCamera);

        //Rotation for player
        float tempRotation = 0;
        if (Input.GetKey(KeyCode.A))
        {
            tempRotation = 1;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            tempRotation = -1;
        }

        smoothMouseX = Mathf.Lerp(smoothMouseX, Input.GetAxis("Mouse X") * rotateSpeed,
            Time.fixedDeltaTime * smoothCamera);
        smoothMouseY = Mathf.Lerp(smoothMouseY, Input.GetAxis("Mouse Y") * rotateSpeed,
            Time.fixedDeltaTime * smoothCamera);

        Quaternion localRotation = Quaternion.Euler(smoothMouseY, smoothMouseX, tempRotation * rotateSpeed);
        lookRotation = localRotation * lookRotation;
        transform.rotation = lookRotation;
        zRotation -= smoothMouseX;
        zRotation = Mathf.Clamp(zRotation, -45, 45);

        spaceshipRoot.transform.eulerAngles = new Vector3(defaultRotation.x, defaultRotation.y, zRotation);
        zRotation = Mathf.Lerp(zRotation, defaultRotation.z, Time.fixedDeltaTime * smoothCamera);
    }*/

    #endregion
}