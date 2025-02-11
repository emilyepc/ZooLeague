using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using TMPro;


public class TeamScoreManager : MonoBehaviour
{
    public static TeamScoreManager instance; 

    public TMP_Text teamTotalScoreText;
    private List<DraggableItem> playersInFormationList = new List<DraggableItem>();

    private void Awake()
    {
        instance = this; 
    }

    public void AddPlayerToFormation(DraggableItem player)
    {
        if (!playersInFormationList.Contains(player))
        {
            playersInFormationList.Add(player);
            UpdateTeamTotalScore();
        }
    }

    public void RemovePlayerFromFormation(DraggableItem player)
    {
        if (playersInFormationList.Contains(player))
        {
            playersInFormationList.Remove(player);
            UpdateTeamTotalScore();
        }
    }

    public void UpdateTeamTotalScore()
    {
        int teamTotalScore = 0;
        foreach (DraggableItem player in playersInFormationList)
        {
            teamTotalScore += player.totalScore;
        }

        teamTotalScoreText.text = "Team Score: " + teamTotalScore.ToString();
    }
}
