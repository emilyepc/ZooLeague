using UnityEngine;
using UnityEngine.UI;

public class RestFunction : MonoBehaviour
{
    public Button button;                    // The button to be clicked
    public GameObject objectToActivate;      // Object to activate
    public GameObject objectToDeactivate;    // Object to deactivate (e.g., the button itself)
    public DraggablePlayer draggablePlayer;  // Reference to the draggable player

    void Start()
    {
        if (button != null)
        {
            button.onClick.AddListener(OnButtonClick);
        }
    }

    void OnButtonClick()
    {
        if (objectToDeactivate != null)
        {
            objectToDeactivate.SetActive(false);
        }

        if (objectToActivate != null)
        {
            objectToActivate.SetActive(true);
        }

        if (draggablePlayer != null)
        {
            draggablePlayer.AddToFormScore(10);
        }
        else
        {
            Debug.LogError("DraggablePlayer reference is not assigned.");
        }
    }
}
