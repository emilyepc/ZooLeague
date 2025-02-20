using UnityEngine;
using UnityEngine.UI;

public class PlayTab : MonoBehaviour
{
    public GameObject objectToEnable;  // Assign the object to enable in Inspector
    public GameObject objectToDisable; // Assign the object to disable in Inspector
    public Button toggleButton;        // Assign the button in Inspector

    private void Start()
    {
        // Attach the Toggle function to the button click event
        if (toggleButton != null)
        {
            toggleButton.onClick.AddListener(Toggle);
        }
    }

    public void Toggle()
    {
        if (objectToEnable != null) objectToEnable.SetActive(true);
        if (objectToDisable != null) objectToDisable.SetActive(false);
    }
}

