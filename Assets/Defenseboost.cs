using UnityEngine;

public class MainButtonController : MonoBehaviour
{
    public GameObject popupPanel;

    public void TogglePopup()
    {
        bool isActive = popupPanel.activeSelf;
        popupPanel.SetActive(!isActive);
    }
}

