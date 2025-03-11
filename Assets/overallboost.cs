using UnityEngine;
using UnityEngine.Serialization;

public class overallboost : MonoBehaviour
{
    public RosterStatUpdating rosterStatUpdating;
    public DraggablePlayer draggablePlayer;

    void Update()
    {
        GameObject correspondingPlayer;

        if (rosterStatUpdating.playerNameText.text == "Francis The Frog")
        {
            correspondingPlayer = GameObject.Find("Francis The Frog");   
            draggablePlayer = correspondingPlayer.GetComponent<DraggablePlayer>();
        } 
        else if (rosterStatUpdating.playerNameText.text == "Danny The Dog")
        {
            correspondingPlayer = GameObject.Find("Danny The Dog");
            draggablePlayer = correspondingPlayer.GetComponent<DraggablePlayer>();
        }
        else if (rosterStatUpdating.playerNameText.text == "Felicity The Frog")
        {
            correspondingPlayer = GameObject.Find("Felicity The Frog");
            draggablePlayer = correspondingPlayer.GetComponent<DraggablePlayer>();
        }
        else if (rosterStatUpdating.playerNameText.text == "Florence The Fox")
        {
            correspondingPlayer = GameObject.Find("Florence The Fox");
            draggablePlayer = correspondingPlayer.GetComponent<DraggablePlayer>();
        }
        else if (rosterStatUpdating.playerNameText.text == "Freddie The Fox")
        {
            correspondingPlayer = GameObject.Find("Freddie The Fox");
            draggablePlayer = correspondingPlayer.GetComponent<DraggablePlayer>();
        }
        else if (rosterStatUpdating.playerNameText.text == "Darcy The Dog")
        {
            correspondingPlayer = GameObject.Find("Darcy The Dog");
            draggablePlayer = correspondingPlayer.GetComponent<DraggablePlayer>();
        }
        else if (rosterStatUpdating.playerNameText.text == "Honey The Hare")
        {
            correspondingPlayer = GameObject.Find("Honey The Hare");
            draggablePlayer = correspondingPlayer.GetComponent<DraggablePlayer>();
        }
        else if (rosterStatUpdating.playerNameText.text == "Harvey The Hare")
        {
            correspondingPlayer = GameObject.Find("Harvey The Hare");
            draggablePlayer = correspondingPlayer.GetComponent<DraggablePlayer>();
        }
    }
    
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
