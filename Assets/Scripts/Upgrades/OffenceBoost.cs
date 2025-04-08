using UnityEngine;

public class OffenceBoost : MonoBehaviour
{
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
