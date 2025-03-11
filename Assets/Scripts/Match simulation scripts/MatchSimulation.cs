using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class MatchSimulation : MonoBehaviour
{
    [Header("References")]
    public TeamScoreManager teamScoreManager;
    public OpponentTeamOne opponentTeamOne;
    public MatchScoreboard matchScoreboard;
    public DraggablePlayer draggablePlayer;
    public Slider gameTimerSlider;
    public GameObject claimRewardsButton;
    
    [Header("Match State")]
    public int playerGoals;
    public int opponentGoals;
    public bool matchOngoing;
    public bool matchRewardsCollected;
    
    public bool gamePaused;
    private float gameLength = 60f;
    private float gameTimer;
    private float goalOpportunityInterval = 5f;
    private float timer;
    
    private float playerGoalOpportunityProbability;
    private float opponentGoalOpportunityProbability;
    private float playerConversionProbability;
    private float opponentConversionProbability;
    
    private bool waitingToScore;
    private float waitingToScoreTimer = 2f;
    private string conversionTeam;
    
    [Header("Stats")]
    public int playerGoalOpportunityStat;
    public int playerConversionRate;
    public int opponentGoalOpportunityStat;
    public int opponentConversionRate;
    
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
        if (!matchOngoing) 
        {
            if (matchRewardsCollected)
            {
                //match not ongoing
                matchScoreboard.UpdateMatchStatus("Team Statistics");
                matchScoreboard.UpdateTextTwo($"Goal Opportunities : {playerGoalOpportunityStat}", matchRewardsCollected);
                matchScoreboard.UpdateLineThree($"Conversion rate : {playerConversionRate}", matchRewardsCollected);
            }
        }
        else if (matchOngoing)
        {
            if (!gamePaused)
            {
                timer += Time.deltaTime;
                gameTimer += Time.deltaTime;

                if (timer >= goalOpportunityInterval)
                {
                    timer = 0;
                    GoalOpportunity();
                }

                if (gameTimer >= gameLength)
                {
                    MatchOver();
                    gameTimer = 0;
                }

                gameTimerSlider.value = gameTimer;
                matchScoreboard.UpdateLeaderboard(playerGoals, opponentGoals, gameTimer);

                if (waitingToScore)
                {
                    waitingToScoreTimer -= Time.deltaTime;
                    if (waitingToScoreTimer <= 0)
                    {
                        waitingToScore = false;
                        Conversion(conversionTeam);
                    }
                }
            }
            else
            {
                
            }
        }
    }

    public void MatchStart()
    {
        claimRewardsButton.SetActive(false);
        matchRewardsCollected = false;
        matchOngoing = true;
        gamePaused = false;
        
        playerGoals = 0;
        opponentGoals = 0;
        
        opponentTeamOne.MatchStart();
        matchScoreboard.UpdateTextTwo("Teams are fighting for possession", matchRewardsCollected);
        matchScoreboard.UpdateMatchStatus("Match in progress");
    }

    private void GoalOpportunity()
    {
        int teamAScore = teamScoreManager.totalTeamScore;
        int teamBScore = opponentTeamOne.totalTeamScore;
        int totalScore = teamAScore + teamBScore;
        
        playerGoalOpportunityProbability = (float)teamAScore / totalScore;
        opponentGoalOpportunityProbability = (float)teamBScore / totalScore;
        
        bool teamAChance = Random.value < playerGoalOpportunityProbability;
        bool teamBChance = Random.value < opponentGoalOpportunityProbability;
        
        print("player opportunity: " + playerGoalOpportunityProbability);
        print("player chance: " + teamAChance);
        
        print("opponent opportunity: " + opponentGoalOpportunityProbability);
        print("opponent chance: " + teamBChance);
        
        
        
        //who will get the opportunity to score?
        if (teamAChance && teamBChance)
        {
            //conversionTeam = playerGoalOpportunityProbability >= opponentGoalOpportunityProbability ? "player" : "opponent";
            matchScoreboard.UpdateTextTwo("Teams are fighting for possession", matchRewardsCollected);
        }
        else if (teamAChance)
        {
            conversionTeam = "player";
            matchScoreboard.GoalOpportunity(conversionTeam);
        }
        else if (teamBChance)
        {
            conversionTeam = "opponent";
            matchScoreboard.GoalOpportunity(conversionTeam);
        }
        else
        {
            matchScoreboard.UpdateTextTwo("Teams are fighting for possession", matchRewardsCollected);
            return;
        }
        
        waitingToScore = true;
        waitingToScoreTimer = 2f;
    }

    private void Conversion(string team)
    {
        if (team == "player")
        {
            playerGoalOpportunityStat++;
            playerConversionProbability = (float)teamScoreManager.totalTeamOffenceScore / (teamScoreManager.totalTeamOffenceScore + opponentTeamOne.opponentDefenceScore);
            
            print("player conversion probability: " + playerConversionProbability);
            Debug.Log("total player offence (" + teamScoreManager.totalTeamOffenceScore + ") divided by player offence score (" + teamScoreManager.totalTeamOffenceScore + ") plus opponent defence (" + opponentTeamOne.opponentDefenceScore);

            if (Random.value < playerConversionProbability)
            {
                playerGoals++;
                matchScoreboard.GoalScored("player");
            }
            else
            {
                matchScoreboard.UpdateTextTwo("Goal Missed", matchRewardsCollected);
            }
        }
        
        else if (team == "opponent")
        {
            opponentGoalOpportunityStat++;
            opponentConversionProbability = (float)opponentTeamOne.opponentOffenceScore / (teamScoreManager.totalTeamDefenceScore + opponentTeamOne.opponentOffenceScore);
            
            print("opponent conversion probability: " + opponentConversionProbability);
            Debug.Log("total opponent offence (" + opponentTeamOne.opponentOffenceScore + ") divided by opponent offence score (" + opponentTeamOne.opponentOffenceScore + ") plus player defence (" + teamScoreManager.totalTeamDefenceScore);

            
            if (Random.value < opponentConversionProbability)
            {
                opponentGoals++;
                matchScoreboard.GoalScored("opponent");
            }
            else
            {
                matchScoreboard.UpdateTextTwo("Goal missed!", matchRewardsCollected);
            }
        }
        
        waitingToScore = false;
        timer = 0;
    }

    private void MatchOver()
    {
        matchOngoing = false;
        matchRewardsCollected = false;
        claimRewardsButton.SetActive(true);
        
        if (playerGoals != 0) playerConversionRate = playerGoalOpportunityStat / playerGoals;
        if (opponentGoals != 0) opponentConversionRate = opponentGoalOpportunityStat / opponentGoals;
        
        matchScoreboard.UpdateMatchStatus("Match Over");
        matchScoreboard.UpdateLeaderboard(playerGoals, opponentGoals, gameTimer);
        
        string matchResult = playerGoals > opponentGoals ? "The winner is the player team!" :
            opponentGoals > playerGoals ? "The winner is the opponent team!" : "This game was a draw!";
        
        matchScoreboard.UpdateTextTwo(matchResult, matchRewardsCollected);
        
        teamScoreManager.UpdateTeamForm(-15);
    }

    public void RewardsCollected()
    {
        matchRewardsCollected = true;
    }

    public void UnpauseGame()
    {
        gamePaused = false;
    }
}