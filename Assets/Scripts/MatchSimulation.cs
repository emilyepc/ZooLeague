using System;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class MatchSimulation : MonoBehaviour
{
    public TeamScoreManager teamScoreManager;
    public OpponentTeamOne opponentTeamOne;
    public MatchScoreboard matchScoreboard;

    public int playerGoals;
    public int opponentGoals;
    
    public Slider gameTimerSlider;
    
    private float gameLength = 60f;
    [HideInInspector] public float gameTimer;
    private float goalOpportunityInterval = 5f;
    private float timer;


    private float playerGoalOpportunityProbability;
    private float opponentGoalOpportunityProbability;

    private float playerConversionProbability;
    private float opponentConversionProbability;
    
    public bool matchOngoing;
    [FormerlySerializedAs("matchOver")] public bool matchRewardsCollected;
    private float waitingToScoreTimer;
    private bool waitingToScore;
    public bool goalOpportunity;

    private string conversionTeam;
    
    [Header("Stats")]
    public int playerGoalOpportunityStat;
    [FormerlySerializedAs("playerConversionRateStat")] public int playerConversionRate;

    public int opponentGoalOpportunityStat;
    public int opponentConversionRate;

    public GameObject claimRewardsButton;
    
    void Awake()
    {
        matchOngoing = false;
        matchRewardsCollected = true;
        waitingToScoreTimer = 5;
        claimRewardsButton.SetActive(false);
        timer = 0f;
    }

    void Update()
    {
        if (matchOngoing)
        {
            //gameTimerSlider = GameObject.Find("Game Timer Slider").GetComponent<Slider>();
            print("match ongoing");
            timer += Time.deltaTime;

            timer += Time.deltaTime;
            if (timer >= goalOpportunityInterval)
            {
                timer = 0;
                GoalOpportunity();
                print("goal opportunity");
            }

            if (gameTimer >= gameLength)
            {
                gameTimer = 0;
                MatchOver();        
            }
            else
            {
                gameTimer += Time.deltaTime;
                gameTimerSlider.value = gameTimer;
                matchScoreboard.UpdateLeaderboard(playerGoals, opponentGoals, gameTimer);
            }

            if (waitingToScore)
            {
                if (waitingToScoreTimer <= 0)
                {
                    waitingToScore = false; 
                    Conversion(conversionTeam);
                }
                else
                {
                    waitingToScoreTimer -= Time.deltaTime;
                }
            }
            else
            {
                //if (!goalOpportunity) 
            }
        }
        else if (!matchOngoing && matchRewardsCollected)
        {
            matchScoreboard.UpdateMatchStatus("Team Statistics");
            matchScoreboard.UpdateTextTwo("Goal Opportunities : " + playerGoalOpportunityStat, matchRewardsCollected);
            matchScoreboard.UpdateLineThree("Conversion rate : " + playerConversionRate, matchRewardsCollected);
        }
    }

    public void RewardsCollected()
    {
        matchRewardsCollected = true;
    }

    public void MatchStart()
    {
        claimRewardsButton.SetActive(false);
        matchRewardsCollected = false;
        
        matchOngoing = true;
        opponentTeamOne.MatchStart();
        print("player team score: " + teamScoreManager.totalTeamScore);
        print("opponent team score: " + opponentTeamOne.totalTeamScore);

        matchOngoing = true;
        goalOpportunity = false;
        
        playerGoals = 0;
        opponentGoals = 0;
        
        matchScoreboard.UpdateTextTwo("Teams are fighting for possession", matchRewardsCollected);
        matchScoreboard.UpdateMatchStatus("Match in progress");
    }

    public void GoalOpportunity()
    {
        goalOpportunity = true;
        print("in goal opportunity method");
        
        int teamAScore = teamScoreManager.totalTeamScore;
        int teamBScore = opponentTeamOne.totalTeamScore;

        playerGoalOpportunityProbability = (float)teamAScore / (teamAScore + teamBScore);
        opponentGoalOpportunityProbability = (float)teamBScore / (teamAScore + teamBScore);
        
        bool teamAChance = Random.value < playerGoalOpportunityProbability;
        bool teamBChance = Random.value < opponentGoalOpportunityProbability;

        switch ((teamAChance, teamBChance))
        {
            case (true, false):
                conversionTeam = "player"; //team a gets chance to convert
                waitingToScore = true;
                waitingToScoreTimer = 2f;
                matchScoreboard.GoalOpportunity("player");
                print("player opportunity");
                break;
            case (false, true):
                conversionTeam = "opponent"; //team b gets chance to convert
                waitingToScore = true;
                waitingToScoreTimer = 2f;
                matchScoreboard.GoalOpportunity("opponent");
                print("opponent opportunity");
                break;
            case (true, true):
                matchScoreboard.GoalOpportunity(playerGoalOpportunityProbability >= opponentGoalOpportunityProbability ? "player" : "opponent");
                conversionTeam = (playerGoalOpportunityProbability >= opponentGoalOpportunityProbability ? "player" : "opponent"); //team with higher probability gets chance to convert
                if (conversionTeam == "player") matchScoreboard.GoalOpportunity("player");
                else if (conversionTeam == "opponent") matchScoreboard.GoalOpportunity("opponent");
                waitingToScore = true;
                waitingToScoreTimer = 2f;
                print("draw opportunity");
                //this should change, this is too high prob for the higher team methinks... 
                break;
            case (false, false):
                goalOpportunity = false;
                matchScoreboard.UpdateTextTwo("Teams are fighting for possession", matchRewardsCollected);
                break;
        }
    }

    private void Conversion(string team)
    {
        if (conversionTeam == "player")
        {
            playerGoalOpportunityStat++;
            
            playerConversionProbability = teamScoreManager.totalTeamOffenceScore /
                                          (teamScoreManager.totalTeamOffenceScore +
                                           (opponentTeamOne.opponentDefenceScore));

            bool conversion = Random.value < playerGoalOpportunityProbability;

            if (conversion)
            {
                matchScoreboard.GoalScored("player");

                print("PLAYER SCORES!");
                playerGoals++;
            }
            else
            {
                print("goal missed");
                matchScoreboard.UpdateLineThree("Goal Missed", matchRewardsCollected);
            }
        }

        else if (conversionTeam == "opponent")
        {
            opponentGoalOpportunityStat++;
            
            opponentConversionProbability = opponentTeamOne.opponentOffenceScore / (teamScoreManager.totalTeamDefenceScore + (opponentTeamOne.opponentOffenceScore));

            bool conversion = Random.value < opponentGoalOpportunityProbability;

            if (conversion)
            {
                matchScoreboard.GoalScored("opponent");

                print("OPPONENT SCORES");
                opponentGoals++;
            }
            else
            {
                print("goal missed");
                matchScoreboard.UpdateTextTwo("Goal missed!", matchRewardsCollected);
            }
        }
        waitingToScore = false;
        timer = 0;
    }

    public void MatchOver()
    {
        if (playerGoals != 0) playerConversionRate = playerGoalOpportunityStat / playerGoals;
        if (opponentGoals != 0) opponentConversionRate = opponentGoalOpportunityStat / opponentGoals;
        
        matchScoreboard.UpdateMatchStatus("Match Over");
        matchScoreboard.UpdateLeaderboard(playerGoals, opponentGoals, gameTimer);
        
        matchOngoing = false;
        matchRewardsCollected = false;
        
        claimRewardsButton.SetActive(true);
        
        if (playerGoals > opponentGoals)
        {
            print("PLAYER TEAM WON!");
            matchScoreboard.UpdateTextTwo("The winner is the player team!", matchRewardsCollected);

        }
        else if (opponentGoals > playerGoals)
        {
            print("OPPONENT TEAM WON");
            matchScoreboard.UpdateTextTwo("The winner is the opponent team!", matchRewardsCollected);
        }
        else
        {
            print("DRAW...");
            matchScoreboard.UpdateTextTwo("This game was a draw!", matchRewardsCollected);
        }
    }
}