using UnityEngine;

public class RotateMoment : MonoBehaviour
{
    public float Speed = 10f;

    private bool isRotating = false;
    private float startMousePosition;

    private Collider interactionCollider;

    void Start()
    {
        // Ensure the GameObject has a collider (2D or 3D)
        interactionCollider = GetComponent<Collider>();

        if (interactionCollider == null)
        {
            Debug.LogError("No collider attached to the object. Add a Collider component to define the interaction area.");
        }
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && IsMouseOverCollider())
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

            transform.Rotate(Vector3.up, -mouseMovement * Speed * Time.deltaTime);
            startMousePosition = currentMousePosition;
        }
    }

    private bool IsMouseOverCollider()
    {
        // Perform a raycast from the mouse position into the world
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        // Check if the ray hits the collider
        return interactionCollider != null && interactionCollider.Raycast(ray, out hit, Mathf.Infinity);
    }
}
