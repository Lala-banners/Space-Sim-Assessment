using UnityEngine;

public class Bullet : MonoBehaviour
{
    public Rigidbody rb;
    public float speed;
    
    // Start is called before the first frame update
    void Start() {
        rb = GetComponent<Rigidbody>();
        rb.velocity = transform.up * speed;
    }
}
