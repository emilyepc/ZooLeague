using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class MatchSimulation : MonoBehaviour
{
    public TeamScoreManager teamScoreManager;
    public OpponentTeamOne opponentTeamOne;

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
    }

    void Update()
    {
        if (matchOngoing)
        {
            gameTimerSlider = GameObject.Find("Game Timer Slider").GetComponent<Slider>();
            
            timer += Time.deltaTime;
            if (timer >= goalOpportunityInterval)
            {
                timer = 0;
                GoalOpportunity();
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
                MatchScoreboard.instance.UpdateLeaderboard(playerGoals, opponentGoals, gameTimer);
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
        }
        else if (!matchOngoing && matchRewardsCollected)
        {
            MatchScoreboard.instance.UpdateMatchStatus("Team Statistics");
            MatchScoreboard.instance.UpdateTextTwo("Goal Opportunities : " + playerGoalOpportunityStat, matchRewardsCollected);
            MatchScoreboard.instance.UpdateLineThree("Conversion rate : " + playerConversionRate, matchRewardsCollected);
        }
    }

    public void RewardsCollected()
    {
        matchRewardsCollected = true;
        matchOngoing = false;   
    }

    public void MatchStart()
    {
        claimRewardsButton.SetActive(false);
        
        matchOngoing = true;
        opponentTeamOne.MatchStart();
        print("player team score: " + teamScoreManager.totalTeamScore);
        print("opponent team score: " + opponentTeamOne.totalTeamScore);

        matchOngoing = true;
        
        playerGoals = 0;
        opponentGoals = 0;
        
        MatchScoreboard.instance.UpdateMatchStatus("Match in progress");
    }

    public void GoalOpportunity()
    {
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
                MatchScoreboard.instance.GoalOpportunity("player");
                print("player opportunity");
                break;
            case (false, true):
                conversionTeam = "opponent"; //team b gets chance to convert
                waitingToScore = true;
                waitingToScoreTimer = 2f;
                MatchScoreboard.instance.GoalOpportunity("opponent");
                print("opponent opportunity");
                break;
            case (true, true):
                MatchScoreboard.instance.GoalOpportunity(playerGoalOpportunityProbability >= opponentGoalOpportunityProbability ? "player" : "opponent");
                conversionTeam = (playerGoalOpportunityProbability >= opponentGoalOpportunityProbability ? "player" : "opponent"); //team with higher probability gets chance to convert
                if (conversionTeam == "player") MatchScoreboard.instance.GoalOpportunity("player");
                else if (conversionTeam == "opponent") MatchScoreboard.instance.GoalOpportunity("opponent");
                waitingToScore = true;
                waitingToScoreTimer = 2f;
                print("draw opportunity");
                //this should change, this is too high prob for the higher team methinks... 
                break;
            case (false, false):
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
                MatchScoreboard.instance.GoalScored("player");

                print("PLAYER SCORES!");
                playerGoals++;
            }
            else
            {
                print("goal missed");
                MatchScoreboard.instance.UpdateLineThree("Goal Missed", matchRewardsCollected);
            }
        }

        else if (conversionTeam == "opponent")
        {
            opponentGoalOpportunityStat++;
            
            opponentConversionProbability = opponentTeamOne.opponentOffenceScore / (teamScoreManager.totalTeamDefenceScore + (opponentTeamOne.opponentOffenceScore));

            bool conversion = Random.value < opponentGoalOpportunityProbability;

            if (conversion)
            {
                MatchScoreboard.instance.GoalScored("opponent");

                print("OPPONENT SCORES");
                opponentGoals++;
            }
            else
            {
                print("goal missed");
                MatchScoreboard.instance.UpdateTextTwo("Goal missed!", matchRewardsCollected);
            }
        }
        waitingToScore = false;
    }

    public void MatchOver()
    {
        if (playerGoals != 0) playerConversionRate = playerGoalOpportunityStat / playerGoals;
        if (opponentGoals != 0) opponentConversionRate = opponentGoalOpportunityStat / opponentGoals;
        
        MatchScoreboard.instance.UpdateMatchStatus("Match Over");
        MatchScoreboard.instance.UpdateLeaderboard(playerGoals, opponentGoals, gameTimer);
        
        matchOngoing = false;
        matchRewardsCollected = false;
        
        claimRewardsButton.SetActive(true);
        
        if (playerGoals > opponentGoals)
        {
            print("PLAYER TEAM WON!");
            MatchScoreboard.instance.UpdateTextTwo("The winner is the player team!", matchRewardsCollected);

        }
        else if (opponentGoals > playerGoals)
        {
            print("OPPONENT TEAM WON");
            MatchScoreboard.instance.UpdateTextTwo("The winner is the opponent team!", matchRewardsCollected);
        }
        else
        {
            print("DRAW...");
            MatchScoreboard.instance.UpdateTextTwo("This game was a draw!", matchRewardsCollected);
        }
    }
}