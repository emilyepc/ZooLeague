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
                // 540
                opponentOffenceScore = 180;
                opponentDefenceScore = 190;
                opponentSpeedScore = 170;
                break;

            case "Piggies":
                // 860
                opponentOffenceScore = 280;
                opponentDefenceScore = 330;
                opponentSpeedScore = 250;
                break;

            case "Dogs":
                // 1230
                opponentOffenceScore = 450;
                opponentDefenceScore = 400;
                opponentSpeedScore = 380;
                break;

            case "Cats":
                // 1440
                opponentOffenceScore = 500;
                opponentDefenceScore = 480;
                opponentSpeedScore = 460;
                break;

            case "Flamingos":
                // 1860
                opponentOffenceScore = 620;
                opponentDefenceScore = 580;
                opponentSpeedScore = 660;
                break;

            case "Tiger":
                // 2100
                opponentOffenceScore = 800;
                opponentDefenceScore = 700;
                opponentSpeedScore = 600;
                break;

            default:
                Debug.LogWarning("Invalid team name: " + teamName);
                break;
        }
    }
}
