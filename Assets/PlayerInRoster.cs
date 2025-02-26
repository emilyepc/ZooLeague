using UnityEngine;

public class PlayerInRoster : MonoBehaviour
{
    public string playerName;
    public int offenceScore;
    public int defenceScore;
    public int speedScore;
    public int totalScore;

    public void OnClick()
    {
        PlayerStatsInFormation.instance.ShowStats(playerName, offenceScore, defenceScore, speedScore, totalScore);
    }
    
}
