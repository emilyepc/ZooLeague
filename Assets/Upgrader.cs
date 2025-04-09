using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Upgrader : MonoBehaviour
{
    public DraggablePlayer player;
    public enum BoostType { Offence, Defence, Speed, Form } 
    public BoostType boost;

    public TMP_Text gachaText;
    
    public void ChooseBoost(int value)
    {
        if (boost.ToString() == "Offence") player.AddToOffenceScore(value);
        else if (boost.ToString() == "Defence") player.AddToDefenceScore(value);
        else if (boost.ToString() == "Speed") player.AddToSpeedScore(value);
        else if (boost.ToString() == "Form") player.AddToFormScore(value);
        
        
        print("Change made to " + player);
    }
}
