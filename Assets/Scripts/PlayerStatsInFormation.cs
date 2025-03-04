using UnityEngine;
using TMPro;


public class PlayerStatsInFormation : MonoBehaviour
{
    public TMP_Text playerNameText;
    public TMP_Text offenceText;
    public TMP_Text defenceText;
    public TMP_Text speedText;
    public TMP_Text totalText;

    public static PlayerStatsInFormation instance;

    private void Awake()
    {
        instance = this;
    }

    public void ShowStats(string playerName, int offence, int defence, int speed, int total)
    {
        playerNameText.text = "Name: " + playerName;
        offenceText.text = "Offence: " + offence;
        defenceText.text = "Defence: " + defence;
        speedText.text = "Speed: " + speed;
        totalText.text = "Total Score: " + total;
    }
}
