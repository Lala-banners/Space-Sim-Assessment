using System;
using UnityEngine;

public class RoboFlyInput : MonoBehaviour
{

    [Tooltip("Min speed")] public float speed = 10f;
    [Tooltip("Speed that the fly will rotate")] public float rotationSpeed = 10f;
    private Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        Flight();
    }

    public void Flight()
    {
        Quaternion addRotation = Quaternion.identity;
        //A pitch motion is an up or down movement of the wings of the aircraft.
        float roll = 0;
        //A pitch motion is an up or down movement of the nose of the aircraft.
        float pitch = 0;
        //(of a moving ship or aircraft) twist or oscillate about a vertical axis
        float yaw = 0;
        roll = Input.GetAxis("Roll") * (Time.fixedDeltaTime * rotationSpeed);
        pitch = Input.GetAxis("Pitch") * (Time.fixedDeltaTime * rotationSpeed);
        yaw = Input.GetAxis("Yaw") * (Time.fixedDeltaTime * rotationSpeed);
        addRotation.eulerAngles = new Vector3(-pitch, yaw, -roll);
        rb.rotation = addRotation;
        Vector3 addPosition = Vector3.forward;
        addPosition = rb.rotation * addPosition;
        rb.velocity = addPosition * (Time.fixedDeltaTime * speed);
    }
}
