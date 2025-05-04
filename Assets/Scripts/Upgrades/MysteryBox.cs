using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class MysteryBox : MonoBehaviour
{
    public static MysteryBox Instance;
    public Button LootBox;
    public GameObject objectToActivate;

    void Start()
    {
        Instance = this;
        
        if (LootBox != null && objectToActivate != null)
        {
            LootBox.onClick.AddListener(ActivateObject);
        }
        else
        {
            print("Button or GameObject not assigned.");
        }
    }

    public void ActivateObject()
    {
        LootBox.interactable = false;
        objectToActivate.SetActive(true);
        //StartCoroutine(DisableText());
    }

 
}
