using UnityEngine;

public class DragonflyFlight : MonoBehaviour
{
    public float speed = 100f, hoverSpeed = 5f, sideSpeed = 7.5f;

    private void Update()
    {
        Flight();
    }

    public void Flight()
    {
        float upSpeed = Input.GetAxisRaw("Vertical") * speed;
        float activeSideSpeed = Input.GetAxisRaw("Horizontal") * sideSpeed;
        float activeHoverSpeed = Input.GetAxisRaw("Hover") * hoverSpeed;

        transform.position += transform.up * upSpeed * Time.deltaTime;
        transform.position += (transform.right * activeSideSpeed * Time.deltaTime) + (transform.forward * activeHoverSpeed * Time.deltaTime);
    }
}
