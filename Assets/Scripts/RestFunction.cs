using UnityEngine;
using TMPro;

public class RestFunction : MonoBehaviour
{
    public TMP_Text text;
    public DraggablePlayer draggablePlayer;
    
    public TMP_Text playerNameText;
    public TMP_Text offenceText;
    public TMP_Text defenceText;
    public TMP_Text speedText;
    public TMP_Text formText;

    public void OnButtonPressed()
    {
        GameObject correspondingPlayer;

        if (text.text == "Name: Francis The Frog")
        {
            correspondingPlayer = GameObject.Find("B_Francis The Frog");   
            if (correspondingPlayer != null) draggablePlayer = correspondingPlayer.GetComponent<DraggablePlayer>();
        } 
        else if (text.text == "Name: Danny The Dog")
        {
            correspondingPlayer = GameObject.Find("B_Danny The Dog");
            if (correspondingPlayer != null) draggablePlayer = correspondingPlayer.GetComponent<DraggablePlayer>();
        }
        else if (text.text == "Name: Felicity The Frog")
        {
            correspondingPlayer = GameObject.Find("B_Felicity The Frog");
            if (correspondingPlayer != null) draggablePlayer = correspondingPlayer.GetComponent<DraggablePlayer>();
        }
        else if (text.text == "Name: Florence The Fox")
        {
            correspondingPlayer = GameObject.Find("B_Florence The Fox");
            if (correspondingPlayer != null) draggablePlayer = correspondingPlayer.GetComponent<DraggablePlayer>();
        }
        else if (text.text == "Name: Freddie The Fox")
        {
            correspondingPlayer = GameObject.Find("B_Freddie The Fox");
            if (correspondingPlayer != null) draggablePlayer = correspondingPlayer.GetComponent<DraggablePlayer>();
        }
        else if (text.text == "Name: Darcy The Dog")
        {
            correspondingPlayer = GameObject.Find("B_Darcy The Dog");
            if (correspondingPlayer != null) draggablePlayer = correspondingPlayer.GetComponent<DraggablePlayer>();
        }
        else if (text.text == "Name: Honey The Hare")
        {
            correspondingPlayer = GameObject.Find("B_Honey The Hare");
            if (correspondingPlayer != null) draggablePlayer = correspondingPlayer.GetComponent<DraggablePlayer>();
        }
        else if (text.text == "Name: Harvey The Hare")
        {
            correspondingPlayer = GameObject.Find("B_Harvey The Hare");
            if (correspondingPlayer != null) draggablePlayer = correspondingPlayer.GetComponent<DraggablePlayer>();
        }
        
        if (draggablePlayer != null)
        {
            draggablePlayer.AddToFormScore(10);
            print("here");
            draggablePlayer.PasteStats(playerNameText, offenceText, defenceText, speedText, formText);
        }
        else
        {
            Debug.Log("DraggableItem reference is not assigned.");
        }
        
    }
}
