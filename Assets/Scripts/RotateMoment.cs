using UnityEngine;
using UnityEngine.UI;

public class RotateMoment : MonoBehaviour
{
    [SerializeField] private float speed = 10f;

    [SerializeField] private RawImage modelImage;

    private bool isRotating;
    private float startMousePosition;

    private Collider interactionCollider;

    void Start()
    {
        interactionCollider = GetComponent<Collider>();
        isRotating = false;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && isMouseInPosition())
        {
            isRotating = true;
            startMousePosition = Input.mousePosition.x;
        }
        else if (Input.GetMouseButtonUp(0))
        {
            isRotating = false;
        }

        if (isRotating)
        {
            float currentMousePosition = Input.mousePosition.x;
            float mouseMovement = currentMousePosition - startMousePosition;

            transform.Rotate(Vector3.up, -mouseMovement * speed * Time.deltaTime);
            startMousePosition = Input.mousePosition.x;
        }
    }

    private bool isMouseInPosition()
    {
        RectTransform rectTransform = modelImage.GetComponent<RectTransform>();
        return RectTransformUtility.RectangleContainsScreenPoint(rectTransform, Input.mousePosition, null);
    }


    public void ResetRotation()
    {
        transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, 0f, transform.rotation.eulerAngles.z);
    }
}
