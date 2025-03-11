using UnityEngine;
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
            UpdateTeamTotalScore(0);
            UpdateTeamOffenceScore(0);
            UpdateTeamDefenceScore(0);
        }
    }

    public void RemovePlayerFromFormation(DraggablePlayer player)
    {
        if (playersInFormationList.Contains(player))
        {
            print("team formation change");
            
            playersInFormationList.Remove(player);
            UpdateTeamTotalScore(0);
            UpdateTeamOffenceScore(0); 
            UpdateTeamDefenceScore(0);
        }
    }

    public void UpdateTeamTotalScore(int amt)
    {
        totalTeamScore = 0;

        foreach (DraggablePlayer player in playersInFormationList)
        {
            totalTeamScore += player.totalScore;
        }

        teamTotalScoreText.text = "Team Score: " + totalTeamScore.ToString();
    }

    public void UpdateTeamOffenceScore(int amt)
    {
        totalTeamOffenceScore = 0;

        foreach (DraggablePlayer player in playersInFormationList)
        {
            totalTeamOffenceScore += player.offenceScoreMultiplied;
        }

        teamOffenceScoreText.text = "Team Offence Score: " + totalTeamOffenceScore.ToString();
    }

    public void UpdateTeamDefenceScore(int amt)
    {
        totalTeamDefenceScore = 0;

        foreach (DraggablePlayer player in playersInFormationList)
        {
            totalTeamDefenceScore += player.defenceScoreMultiplied;
        }
        
        totalTeamDefenceScore += amt;
        
        teamDefenceScoreText.text = "Team Defence Score: " + totalTeamDefenceScore.ToString();
    }

    public void UpdateTeamForm(int amount)
    {
        foreach (DraggablePlayer player in playersInFormationList)
        {
            player.AddToFormScore(amount);
        }
    }

    public void UpdatePlayerForm(int amount)
    {
        
    }
}
