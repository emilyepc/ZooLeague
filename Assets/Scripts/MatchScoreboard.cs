using UnityEngine;
using TMPro;

public class MatchScoreboard : MonoBehaviour
{
    public TMP_Text matchStatus;
    public TMP_Text scoreboard;
    public TMP_Text timer;
    public TMP_Text goalStatus;

    private float textClearTimer;
    private bool textShowing;

    public static MatchScoreboard instance;

    void Awake()
    {
        scoreboard = GameObject.Find("Scoreboard Text").GetComponent<TMP_Text>();
        timer = GameObject.Find("Timer Text").GetComponent<TMP_Text>();

        instance = this;
        textShowing = false;
    }

    void Update()
    {
        if (textShowing)
        {
            if (textClearTimer > 0) textClearTimer -= Time.deltaTime;
            else textShowing = false;
        }
        else goalStatus.text = "";
    }

    public void UpdateLeaderboard(int playerScore, int opponentScore, float timeLeft)
    {
        scoreboard.text = playerScore.ToString() + " - " + opponentScore.ToString();
        timer.text = (60f - Mathf.Round(timeLeft)).ToString();
    }

    public void GoalOpportunity(string team)
    {
        print("its coming here!");
        textShowing = true; 
        textClearTimer = 5f;
        goalStatus.text = "Goal opportunity for " + team + " team!!";
    }

    public void GoalScored(string team)
    {
        goalStatus.text = "Goal scored for " + team + " team!!";
        textShowing = true;
        textClearTimer = 3f;
    }

    public void GoalMissed()
    {
        goalStatus.text = "Goal missed";
        textShowing = true;
        textClearTimer = 3f;
    }
}