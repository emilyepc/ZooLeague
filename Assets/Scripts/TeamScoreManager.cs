using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using TMPro;


public class TeamScoreManager : MonoBehaviour
{
    public static TeamScoreManager instance; 

    public TMP_Text teamTotalScoreText;
    public TMP_Text teamOffenceScoreText;
    public TMP_Text teamDefenceScoreText;

    private List<DraggablePlayer> playersInFormationList = new List<DraggablePlayer>();

    public int totalTeamScore;
    public int totalTeamOffenceScore;
    public int totalTeamDefenceScore;

    private void Awake()
    {
        instance = this; 
    }

    public void AddPlayerToFormation(DraggablePlayer player)
    {
        if (!playersInFormationList.Contains(player))
        {
            playersInFormationList.Add(player);
            UpdateTeamTotalScore();
            UpdateTeamOffenceScore();
            UpdateTeamDefenceScore();
        }
    }

    public void RemovePlayerFromFormation(DraggablePlayer player)
    {
        if (playersInFormationList.Contains(player))
        {
            print("team formation change");
            
            playersInFormationList.Remove(player);
            UpdateTeamTotalScore();
            UpdateTeamOffenceScore(); 
            UpdateTeamDefenceScore();
        }
    }

    public void UpdateTeamTotalScore()
    {
        totalTeamScore = 0;

        foreach (DraggablePlayer player in playersInFormationList)
        {
            print(playersInFormationList);
            totalTeamScore += player.totalScore;
        }

        teamTotalScoreText.text = "Team Score: " + totalTeamScore.ToString();
    }

    public void UpdateTeamOffenceScore()
    {
        totalTeamOffenceScore = 0;

        foreach (DraggablePlayer player in playersInFormationList)
        {
            totalTeamOffenceScore += player.offenceScoreMultiplied;
        }

        teamOffenceScoreText.text = "Team Offence Score: " + totalTeamOffenceScore.ToString();
    }

    public void UpdateTeamDefenceScore()
    {
        totalTeamDefenceScore = 0;

        foreach (DraggablePlayer player in playersInFormationList)
        {
            totalTeamDefenceScore += player.defenceScoreMultiplied;
        }
        
        teamDefenceScoreText.text = "Team Defence Score: " + totalTeamDefenceScore.ToString();
    }
}
