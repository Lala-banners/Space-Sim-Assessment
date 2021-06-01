using UnityEngine;

public class Bullet : MonoBehaviour
{
    public Rigidbody rb;
    public float speed;
    
    // Start is called before the first frame update
    void Start() {
        rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate() {
        //Shoot bullet
        float moveH = Input.GetAxis("Horizontal");
        float moveV = Input.GetAxis("Vertical");

        Vector3 moveBullet = new Vector3(moveH, 0f, moveV);
        rb.velocity = moveBullet * speed;
    }
}
