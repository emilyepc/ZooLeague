using UnityEngine;
using UnityEngine.UI;

public class ActivateObjectOnButtonPress : MonoBehaviour
{
    
    public Button LootBox;
    public GameObject objectToActivate;

    void Start()
    {
        
        if (LootBox != null && objectToActivate != null)
        {
            LootBox.onClick.AddListener(ActivateObject);
        }
        else
        {
            print("Button or GameObject not assigned.");
        }
    }

    void ActivateObject()
    {
        objectToActivate.SetActive(true);
    }
}
