using UnityEngine;
using UnityEngine.Serialization;

public class Add20 : MonoBehaviour
{
    // Public field to assign the DraggableItem script via the Inspector
    public DraggablePlayer draggablePlayer;

    public void OnPopupButtonPressed()
    {
        if (draggablePlayer != null)
        {
            draggablePlayer.AddToDefenceScore(20);
        }
        else
        {
            Debug.LogError("DraggableItem reference is not assigned.");
        }
    }
}

