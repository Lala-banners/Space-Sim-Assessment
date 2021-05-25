using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(SpaceshipPhysics))]
[RequireComponent(typeof(SpaceshipInput))]
public class Spaceship : MonoBehaviour
{

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

    private void FixedUpdate() {
        _physics.SetPhysicsInput(new Vector3(_input.strafe, 0.0f, _input.throttle),
            new Vector3(_input.pitch, _input.yaw, _input.roll));

        if (isPlayer)
        {
            playerShip = this;
        }
    }


}