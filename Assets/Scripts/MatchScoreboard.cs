using UnityEngine;
using TMPro;

public class MatchScoreboard : MonoBehaviour
{
    public TMP_Text scoreboard;
    public TMP_Text timer;
    public TMP_Text goalStatus;

    private float textClearTimer;

    public static MatchScoreboard instance;

    void Awake()
    {
        scoreboard = GameObject.Find("Scoreboard Text").GetComponent<TMP_Text>();
        timer = GameObject.Find("Timer Text").GetComponent<TMP_Text>();

        instance = this;
    }

    void Update()
    {
        if (textClearTimer < 0)
        {
            goalStatus.text = "";
        }
        else
        {
            textClearTimer -= Time.deltaTime;
        }
    }

    public void UpdateLeaderboard(int playerScore, int opponentScore, float timeLeft)
    {
        scoreboard.text = playerScore.ToString() + " - " + opponentScore.ToString();
        timer.text = (60f - Mathf.Round(timeLeft)).ToString();

    }

    public void GoalOpportunity(string team)
    {
        goalStatus.text = "Goal opportunity for " + team + " team!!";
    }

    public void GoalScored(string team)
    {
        goalStatus.text = "Goal scored for " + team + " team!!";
        textClearTimer = 4;
    }

    public void GoalMissed()
    {
        goalStatus.text = "Goal missed";
        textClearTimer = 4;
    }
}
