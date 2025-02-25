using UnityEngine;
using TMPro;
using UnityEngine.Serialization;

public class MatchScoreboard : MonoBehaviour
{
    public TMP_Text matchStatus;
    public TMP_Text lineTwo;
    public TMP_Text lineThree;

    private float textClearTimer;
    private bool textShowing;

    public static MatchScoreboard instance;

    void Awake()
    {
        lineThree = GameObject.Find("Scoreboard Text").GetComponent<TMP_Text>();

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
        else lineTwo.text = "";
    }

    
    //line 1 methods
    public void UpdateMatchStatus(string status)
    {
        matchStatus.text = status;
    }
    
    //line 2 methods
    public void UpdateTextTwo(string text, bool matchOver)
    {
        lineThree.text = text;
        
        if (!matchOver)
        {
            textShowing = true;
            textClearTimer = 3f;
        }
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
        lineThree.text = playerScore.ToString() + " - " + opponentScore.ToString();
    }
    
    public void UpdateLineThree(string line, bool matchOver)
    {
        lineThree.text = line;

        if (!matchOver)
        {
            textShowing = true;
            textClearTimer = 3f;
        }
    }
}