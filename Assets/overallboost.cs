using UnityEngine;
using UnityEngine.Serialization;

public class overallboost : MonoBehaviour
{
    // Public field to assign the DraggableItem script via the Inspector
    public DraggablePlayer draggablePlayer;

    public void OnButtonPressed()
    {
        if (draggablePlayer != null)
        {
            draggablePlayer.AddToDefenceScore(1);
            draggablePlayer.AddToOffenceScore(1);
            draggablePlayer.AddToSpeedScore(1);
        }
        else
        {
            Debug.LogError("DraggableItem reference is not assigned.");
        }
    }
}
