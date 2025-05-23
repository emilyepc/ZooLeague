using UnityEngine;
using System.Collections.Generic;
using TMPro;


public class TeamScoreManager : MonoBehaviour
{
    public static TeamScoreManager instance; 
    public MatchScoreboard matchScoreboard;

    public TMP_Text teamTotalScoreText;
    public TMP_Text teamOffenceScoreText;
    public TMP_Text teamDefenceScoreText;
    public TMP_Text teamSpeedScoreText;

    [HideInInspector] public List<DraggablePlayer> playersInFormationList = new List<DraggablePlayer>();

    public int totalTeamScore;
    public int totalTeamSpeedScore;
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
            UpdateTeamSpeedScore(0);
        }
    }

    public void RemovePlayerFromFormation(DraggablePlayer player)
    {
        if (playersInFormationList.Contains(player))
        {
            playersInFormationList.Remove(player);
            UpdateTeamTotalScore(0);
            UpdateTeamOffenceScore(0); 
            UpdateTeamDefenceScore(0);
            UpdateTeamSpeedScore(0);
        }
    }

    public void UpdateScoreboard()
    {
        UpdateTeamTotalScore(0);
        UpdateTeamOffenceScore(0); 
        UpdateTeamDefenceScore(0);
        UpdateTeamSpeedScore(0);
    }
    
    public void UpdateTeamTotalScore(int amt)
    {
        totalTeamScore = 0;

        foreach (DraggablePlayer player in playersInFormationList)
        {
            totalTeamScore += player.totalScore;
        }

        teamTotalScoreText.text = "Overall Team Score: " + totalTeamScore;
    }

    public void UpdateTeamOffenceScore(int amt)
    {
        totalTeamOffenceScore = 0;

        foreach (DraggablePlayer player in playersInFormationList)
        {
            totalTeamOffenceScore += player.offenceScoreMultiplied;
        }
        
        //totalTeamOffenceScore += amt; //for popups
        teamOffenceScoreText.text = totalTeamOffenceScore.ToString();
    }

    public void UpdateTeamDefenceScore(int amt)
    {
        totalTeamDefenceScore = 0;

        foreach (DraggablePlayer player in playersInFormationList)
        {
            totalTeamDefenceScore += player.defenceScoreMultiplied;
        }
        
        //totalTeamDefenceScore += amt; //for popups/ upgrades
        teamDefenceScoreText.text = totalTeamDefenceScore.ToString();
    }

    public void UpdateTeamSpeedScore(int amt)
    {
        totalTeamSpeedScore = 0;

        foreach (DraggablePlayer player in playersInFormationList)
        {
            totalTeamSpeedScore += player.speedScoreMultiplied;
        }
        
        //totalTeamSpeedScore += amt; //for popups/ upgrades
        teamSpeedScoreText.text = totalTeamSpeedScore.ToString();
    }

    public void UpdateTeamForm(int amount)
    {
        foreach (DraggablePlayer player in playersInFormationList)
        {
            player.AddToFormScore(amount);
        }
        
        
        matchScoreboard.UpdatePlayerStatsText();
    }

}
