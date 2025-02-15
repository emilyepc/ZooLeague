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

    private bool matchOngoing;

    void Awake()
    {
        matchOngoing = false;
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

        }
    }

    public void MatchStart()
    {
        matchOngoing = true;
        print(teamScoreManager.totalTeamScore);
        print(opponentTeamOne.totalTeamScore);


        playerGoals = 0;
        opponentGoals = 0;

    }

    public void GoalOpportunity()
    {
        int teamAScore = teamScoreManager.totalTeamScore;
        int teamBScore = opponentTeamOne.totalTeamScore;

        playerGoalOpportunityProbability = (float)teamAScore / (teamAScore + teamBScore);
        opponentGoalOpportunityProbability = (float)teamBScore / (teamAScore + teamBScore);

        //print(playerGoalOpportunityProbability);
        //print(opponentGoalOpportunityProbability);

        bool teamAChance = Random.value < playerGoalOpportunityProbability;
        bool teamBChance = Random.value < opponentGoalOpportunityProbability;

        switch ((teamAChance, teamBChance))
        {
            case (true, false):
                Conversion("Player"); //team a gets chance to convert
                break;
            case (false, true):
                Conversion("Opponent"); //team b gets chance to convert
                break;
            case (true, true):
                Conversion(playerGoalOpportunityProbability >= opponentGoalOpportunityProbability ? "Player" : "Opponent"); //team with higher probability gets chance to convert
                break;
            case (false, false):
                break;
        }

        // timer = 0
    }  

    public void Conversion(string team)
    {
        print("Conversion Opportunity For " + team + " Team");

        if (team == "Player")
        {
            playerConversionProbability = teamScoreManager.totalTeamOffenceScore / (teamScoreManager.totalTeamOffenceScore + (opponentTeamOne.opponentDefenceScore));
            //print(playerConversionProbability);

            bool conversion = Random.value < playerGoalOpportunityProbability;

            if (conversion) 
            {
                print("PLAYER SCORES!");
                playerGoals++;
            }

        }
        if (team == "Opponent")
        {
            opponentConversionProbability = opponentTeamOne.opponentOffenceScore / (teamScoreManager.totalTeamDefenceScore + (opponentTeamOne.opponentOffenceScore));
            //print(playerConversionProbability);

            bool conversion = Random.value < opponentGoalOpportunityProbability;

            if (conversion)
            {
                print("OPPONENT SCORES");
                opponentGoals++;
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