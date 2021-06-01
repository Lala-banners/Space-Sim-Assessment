using UnityEngine;

public class SpaceshipPhysics : MonoBehaviour
{
    public Vector3 linearForce = new Vector3(100.0f, 100.0f, 100.0f);
    public Vector3 angularForce = new Vector3(100.0f, 100.0f, 100.0f);
    
    [Tooltip("Multiplier for longitudinal force when reverse is requested"),Range(0.0f, 1.0f)] 
    public float reverseMultiplier = 0.1f;

    [Tooltip("Multiplier for all forces")] public float forceMultiplier = 100.0f;

    public Rigidbody Rigidbody { get { return rb; } }

    private Rigidbody rb;
    private Vector3 appliedLinearForce = Vector3.zero;
    private Vector3 appliedAngularForce = Vector3.zero;

    [Tooltip("Reference to the ship")] private Spaceship _ship;

    private void Awake() {
        rb = GetComponent<Rigidbody>();

        if (rb.Equals(null))
        {
            Debug.LogWarning(name + ": ShipPhysics has no Rigidbody");
        }

        _ship = GetComponent<Spaceship>();
    }

    private void FixedUpdate() {
        if (rb != null)
        {
            //rb.velocity = _ship.transform.forward * 50;
            rb.AddRelativeForce(appliedLinearForce * forceMultiplier, ForceMode.Force);
            rb.AddRelativeTorque(appliedAngularForce * forceMultiplier, ForceMode.Force);
        }
    }

    /// <summary>
    /// Sets the input for how much of linearForce and angularForce are applied
    /// to the ship. Each component of the input Vectors is assumed to be scaled
    /// from -1 to 1, but not clamped.
    /// </summary>
    public void SetPhysicsInput(Vector3 linearInput, Vector3 angularInput) {
        //Debug.Log(linearInput + " " + angularInput);
        appliedLinearForce = MultiplyByComponent(linearInput, linearForce);
        appliedAngularForce = MultiplyByComponent(angularInput, angularForce);
    }

    /// <summary>
    /// Returns a Vector3 where each component of Vector A is multiplied by the
    /// equivilent component of Vector B.
    /// </summary>
    private Vector3 MultiplyByComponent(Vector3 a, Vector3 b) {
        Vector3 ret;

        ret.x = a.x * b.x;
        ret.y = a.y * b.y;
        ret.z = a.z * b.z;

        return ret;
    }
}
