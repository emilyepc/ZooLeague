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
    
    private bool matchOngoing;
    private float waitingToScoreTimer;
    private bool waitingToScore;

    private string conversionTeam;
    
    [Header("Stats")]
    public int playerGoalOpportunityStat;
    [FormerlySerializedAs("playerConversionRateStat")] public int playerConversionRate;

    public int opponentGoalOpportunityStat;
    public int opponentConversionRate;
    
    void Awake()
    {
        matchOngoing = false;
        waitingToScoreTimer = 5;
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
                matchOngoing = false;
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
    }

    public void MatchStart()
    {
        matchOngoing = true;
        opponentTeamOne.MatchStart();
        print("player team score: " + teamScoreManager.totalTeamScore);
        print("opponent team score: " + opponentTeamOne.totalTeamScore);


        playerGoals = 0;
        opponentGoals = 0;
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
                conversionTeam = (playerGoalOpportunityProbability >= opponentGoalOpportunityProbability ? "player" : "opponent"); //team with higher probability gets chance to conver
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
                MatchScoreboard.instance.GoalMissed();
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
                MatchScoreboard.instance.GoalMissed();
            }
        }
        waitingToScore = false;
    }

    public void MatchOver()
    {
        playerConversionRate = playerGoalOpportunityStat / playerGoals;
        opponentConversionRate = opponentGoalOpportunityStat / opponentGoals;
        
        
        if (playerGoals > opponentGoals)
        {
            print("PLAYER TEAM WON!");
        }
        else if (opponentGoals > playerGoals)
        {
            print("OPPONENT TEAM WON");
        }
        else
        {
            print("DRAW...");
        }
    }
}