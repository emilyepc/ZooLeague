using UnityEngine;

public class OpponentTeamOne : MonoBehaviour
{

    [HideInInspector] public int totalTeamScore;
    public int opponentOffenceScore;
    public int opponentDefenceScore;
    public int opponentSpeedScore;

    public void MatchStart()
    {
        totalTeamScore = opponentDefenceScore + opponentSpeedScore + opponentOffenceScore;
    }

    public void MatchReset()
    {
        opponentOffenceScore = 0;
        opponentDefenceScore = 0;
        opponentSpeedScore = 0;
    }

    public void SetTeamStats(string teamName)
    {
        MatchReset();

        switch (teamName)
        {
            case "Frogs":
                //1060
                opponentOffenceScore = 400;
                opponentDefenceScore = 350;
                opponentSpeedScore = 310;
                break;

            case "Piggies":
                //1240
                opponentOffenceScore = 350;
                opponentDefenceScore = 670;
                opponentSpeedScore = 420;
                break;

            case "Dogs":
                //1480
                opponentOffenceScore = 5;
                opponentDefenceScore = 4;
                opponentSpeedScore = 3;
                break;

            case "Cats":
                //1780
                opponentOffenceScore = 4;
                opponentDefenceScore = 4;
                opponentSpeedScore = 4;
                break;

            case "Flamingos":
                //2100
                opponentOffenceScore = 3;
                opponentDefenceScore = 3;
                opponentSpeedScore = 6;
                break;

            case "Tiger":
                //2870
                opponentOffenceScore = 6;
                opponentDefenceScore = 5;
                opponentSpeedScore = 4;
                break;

            default:
                Debug.LogWarning("Invalid team name: " + teamName);
                break;
        }
    }
}
