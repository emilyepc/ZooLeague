using UnityEngine;

public class Add15 : MonoBehaviour
{
    // Public field to assign the DraggableItem script via the Inspector
    public DraggableItem draggableItem;

    public void OnPopupButtonPressed()
    {
        if (draggableItem != null)
        {
            draggableItem.AddToOffenceScore(20);
        }
        else
        {
            Debug.LogError("DraggableItem reference is not assigned.");
        }
    }
}
