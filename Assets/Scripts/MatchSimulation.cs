using UnityEngine;

public class MatchSimulation : MonoBehaviour
{
    public TeamScoreManager teamScoreManager;
    public OpponentTeamOne opponentTeamOne;

    public int playerGoals;
    public int opponentGoals;

    private float gameLength = 60f;
    [HideInInspector] public float gameTimer;
    private float goalOpportunityInterval = 5f;
    private float timer;


    private float playerGoalOpportunityProbability;
    private float opponentGoalOpportunityProbability;

    private float playerConversionProbability;
    private float opponentConversionProbability;

    [Header("Stats")]
    public int playerGoalOpportunityStat;
    public int playerConversionRateStat;

    public int opponentGoalOpportunityStat;
    public int opponentConversionRate;

    private bool matchOngoing;
    private float waitingToScoreTimer;
    private bool waitingToScore;

    private string conversionTeam;

    void Awake()
    {
        matchOngoing = false;
        waitingToScoreTimer = 5;
    }

    void Update()
    {
        if (matchOngoing)
        {
            timer += Time.deltaTime;
            if (timer >= goalOpportunityInterval)
            {
                timer = 0;
                GoalOpportunity();

            }

            gameTimer += Time.deltaTime;
            if (gameTimer >= gameLength)
            {
                gameTimer = 0;
                matchOngoing = false;
                MatchOver();        
            }
            else
            {
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

        print("Player goal opportunity chance = " + playerGoalOpportunityProbability);
        print("Opponent goal opportunity chance = " + opponentGoalOpportunityProbability);

        bool teamAChance = Random.value < playerGoalOpportunityProbability;
        bool teamBChance = Random.value < opponentGoalOpportunityProbability;

        switch ((teamAChance, teamBChance))
        {
            case (true, false):
                conversionTeam = "player"; //team a gets chance to convert
                waitingToScore = true;
                print("player conversion attempt");
                break;
            case (false, true):
                conversionTeam = "opponent"; //team b gets chance to convert
                waitingToScore = true;
                print("opp conversion attempt");
                break;
            case (true, true):
                conversionTeam = (playerGoalOpportunityProbability >= opponentGoalOpportunityProbability ? "player" : "opponent"); //team with higher probability gets chance to convert
                waitingToScore = true;
                print("draw attempt");
                //this should change, this is too high prob for the higher team methinks... 
                break;
            case (false, false):
                break;
        }
    }

    public void Conversion(string team)
    {
        print("Conversion Opportunity For " + conversionTeam + " Team");
        MatchScoreboard.instance.GoalOpportunity(conversionTeam);

        if (conversionTeam == "player")
        {
            playerConversionProbability = teamScoreManager.totalTeamOffenceScore / (teamScoreManager.totalTeamOffenceScore + (opponentTeamOne.opponentDefenceScore));
            //print(playerConversionProbability);

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
            opponentConversionProbability = opponentTeamOne.opponentOffenceScore / (teamScoreManager.totalTeamDefenceScore + (opponentTeamOne.opponentOffenceScore));
            //print(playerConversionProbability);

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
    }

    public void MatchOver()
    {
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