using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class MysteryBox : MonoBehaviour
{
    public static MysteryBox Instance;
    public Button LootBox;
    public GameObject rosterObjectToUnlock;
    public GameObject teamPageObjectToUnlock;
    public GameObject feedbackObject;
    public GameObject nextButton;

    void Start()
    {
        Instance = this;
        
        rosterObjectToUnlock.SetActive(false);
        teamPageObjectToUnlock.SetActive(false);
        feedbackObject.SetActive(false);
        
        if (LootBox != null && rosterObjectToUnlock != null)
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
        rosterObjectToUnlock.SetActive(true);
        teamPageObjectToUnlock.SetActive(true);
        feedbackObject.SetActive(true);
        
        if (nextButton != null) nextButton.SetActive(true);  
    }
}
