using UnityEngine;
using UnityEngine.Serialization;

public class DefenceBoost : MonoBehaviour
{
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

