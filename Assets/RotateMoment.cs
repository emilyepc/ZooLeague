using UnityEngine;

public class RotateMoment : MonoBehaviour
{
    [SerializeField] private float speed = 10f;

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
        if (Input.GetMouseButtonDown(0))
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
        
        
        
        /*
        if (Input.GetMouseButtonDown(0) && IsMouseOverCollider())
        {
            print("rotating");
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
            startMousePosition = currentMousePosition;
        }*/
    }

    private bool IsMouseOverCollider()
    {
        // raycast from the mouse position
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        
        print("mouseovercollider");

        // output what the ray hits
        return interactionCollider != null && interactionCollider.Raycast(ray, out hit, Mathf.Infinity);
    }
}
