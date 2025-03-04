using UnityEngine;

public class Add15 : MonoBehaviour
{
    // Public field to assign the DraggableItem script via the Inspector
    public DraggablePlayer draggablePlayer;

    public void OnPopupButtonPressed()
    {
        if (draggablePlayer != null)
        {
            draggablePlayer.AddToOffenceScore(20);
        }
        else
        {
            Debug.LogError("draggablePlayer reference is not assigned.");
        }
    }
}
