using UnityEngine;

public class Add20 : MonoBehaviour
{
    // Public field to assign the DraggableItem script via the Inspector
    public DraggableItem draggableItem;

    public void OnPopupButtonPressed()
    {
        if (draggableItem != null)
        {
            draggableItem.AddToDefenceScore(20);
        }
        else
        {
            Debug.LogError("DraggableItem reference is not assigned.");
        }
    }
}

