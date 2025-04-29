using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class scrolla : MonoBehaviour
{
    public float scrollSpeedX = 0.1f;
    public float scrollSpeedY = 0.1f;

    private Material runtimeMaterial;
    private Vector2 offset;

    void Start()
    {
        Image img = GetComponent<Image>();
        // Make a copy of the material instance so the scrolling doesn't affect other UI elements
        runtimeMaterial = Instantiate(img.material);
        img.material = runtimeMaterial;
    }

    void Update()
    {
        offset.x = Time.time * scrollSpeedX;
        offset.y = Time.time * scrollSpeedY;

        if (runtimeMaterial != null)
        {
            runtimeMaterial.mainTextureOffset = offset;
        }
    }
}

