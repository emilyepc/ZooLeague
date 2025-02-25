using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class PlayTab : MonoBehaviour
{
    public GameObject objectToEnable;                  // Assign the object to enable in Inspector
    public List<GameObject> objectsToDisable;          // List of objects to disable
    public Button toggleButton;                        // Assign the button in Inspector

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
        if (objectToEnable != null)
        {
            objectToEnable.SetActive(true);
        }

        if (objectsToDisable != null)
        {
            foreach (GameObject obj in objectsToDisable)
            {
                if (obj != null)
                {
                    obj.SetActive(false);
                }
            }
        }
    }
}


