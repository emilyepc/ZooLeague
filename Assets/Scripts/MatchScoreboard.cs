using UnityEngine;
using TMPro;

public class MatchScoreboard : MonoBehaviour
{
    public TMP_Text scoreboard;
    public TMP_Text timer;

    public static MatchScoreboard instance;

    void Awake()
    {
        scoreboard = GameObject.Find("Scoreboard Text").GetComponent<TMP_Text>();
        timer = GameObject.Find("Timer Text").GetComponent<TMP_Text>();

        instance = this;
    }

    public void UpdateLeaderboard(int playerScore, int opponentScore, float timeLeft)
    {
        scoreboard.text = playerScore.ToString() + " - " + opponentScore.ToString();
        timer.text = (60f - Mathf.Round(timeLeft)).ToString();

    }

}
