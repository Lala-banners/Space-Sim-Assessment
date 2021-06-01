using UnityEngine;
using UnityEngine.UI;

public class ChangeRenderTexture : MonoBehaviour
{
    [SerializeField] private RenderTexture texture2;
    [SerializeField] private RawImage raw;
    [SerializeField] private Camera cam;
    
    
    // Start is called before the first frame update
    void Start()
    {
        if (cam.targetTexture != null)
        {
            cam.targetTexture.Release();
        }

        RenderTexture texture3 = new RenderTexture(texture2);
        texture3.width = Screen.width;
        texture3.height = Screen.height;
        texture2.depth = 16;
        cam.targetTexture = texture3;
        raw.texture = texture3;
    }
}
