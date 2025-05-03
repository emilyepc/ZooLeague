using UnityEngine;
using TMPro;

public class MatchScoreboard : MonoBehaviour
{
    public TeamScoreManager teamScoreManger;
    public OpponentTeamOne opponentTeamOne;
    
    public TMP_Text matchStatus;
    public TMP_Text lineTwo;
    public TMP_Text lineThree;

    public TMP_Text playerTotalScoreText;
    public TMP_Text playerDefenceScoreText;
    public TMP_Text playerSpeedScoreText;
    public TMP_Text playerOffenceScoreText;
    
    public TMP_Text opposistionTotalScoreText;
    public TMP_Text opposistionDefenceScoreText;
    public TMP_Text opposistionSpeedScoreText;
    public TMP_Text opposistionOffenceScoreText;

    private float textClearTimer;
    private bool textShowing;
    
    public void Awake()
    {
        lineThree = GameObject.Find("Scoreboard Text").GetComponent<TMP_Text>();
        textShowing = false;
    }

    void Update()
    {
        if (textShowing)
        {
            if (textClearTimer > 0) textClearTimer -= Time.deltaTime;
            else textShowing = false;
        }
        else lineTwo.text = "Teams are fighting for possession";
    }

    
    //line 1
    public void UpdateMatchStatus(string status)
    {
        matchStatus.text = status;
    }
    
    //line 2 
    public void UpdateTextTwo(string text)
    {
        lineTwo.text = text;
        textShowing = true;
        textClearTimer = 3f;
    }
    
    public void GoalOpportunity(string team)
    {
        textShowing = true; 
        textClearTimer = 5f;
        lineTwo.text = "Goal opportunity for " + team + " team!!";
    }

    public void GoalScored(string team)
    {
        lineTwo.text = "Goal scored for " + team + " team!!";
        textShowing = true;
        textClearTimer = 3f;
    }

    //line three
    public void UpdateLeaderboard(int playerScore, int opponentScore, float timeLeft)
    {
        lineThree.text = playerScore.ToString() + "   -   " + opponentScore.ToString();
    }
    
    public void UpdatePlayerStatsText()
    {
        playerTotalScoreText.text = "Total: " + TeamScoreManager.instance.totalTeamScore.ToString();
        playerDefenceScoreText.text = "D: " + TeamScoreManager.instance.totalTeamDefenceScore.ToString();
        playerSpeedScoreText.text = "S: " + TeamScoreManager.instance.totalTeamSpeedScore.ToString();
        playerOffenceScoreText.text = "O: " + TeamScoreManager.instance.totalTeamOffenceScore.ToString();
    }

    public void UpdateOpponentStatsText()
    {
        opposistionTotalScoreText.text = "Total: " + opponentTeamOne.totalTeamScore.ToString();
        opposistionDefenceScoreText.text = "D: " + opponentTeamOne.opponentDefenceScore.ToString();
        opposistionSpeedScoreText.text = "S: " + opponentTeamOne.opponentSpeedScore.ToString();
        opposistionOffenceScoreText.text = "O: " + opponentTeamOne.opponentOffenceScore.ToString();
    }
}