using UnityEngine;

public class OpponentTeamOne : MonoBehaviour
{

    [HideInInspector] public int totalTeamScore;
    public int opponentOffenceScore;
    public int opponentDefenceScore;
    public int opponentSpeedScore;
    
    void Start()
    {
        totalTeamScore = opponentDefenceScore + opponentSpeedScore + opponentOffenceScore; 
    }
}
