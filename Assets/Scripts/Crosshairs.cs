using UnityEngine;
using UnityEngine.UI;

public class Crosshairs : MonoBehaviour
{
    public Image crosshairImg;
    
    // Start is called before the first frame update
    void Start() {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Spaceship.PlayerShip.UsingMouseInput)
        {
            crosshairImg.transform.position = Input.mousePosition;
            Cursor.lockState = CursorLockMode.Confined;
            Cursor.visible = false;
        }
    }
}
