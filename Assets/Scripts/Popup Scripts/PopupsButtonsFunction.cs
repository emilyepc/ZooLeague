using System;
using UnityEngine;
using TMPro;

public class PopupsButtonsFunction : MonoBehaviour
{
    public MatchSimulation matchSimulation;
    public GameObject effectPanel;
    public TeamScoreManager teamScoreManager;
    public TMP_Text text;
    public GameObject homePanel;
    public GameObject matchSelectPanel;
    public GameObject continueButton;

    private void Start()
    {
        effectPanel.SetActive(false);
    }

    public void UpdateTeamFormation()
    {
        homePanel.SetActive(false);
        matchSelectPanel.SetActive(false);
        continueButton.SetActive(true);
    }

    public void UpdateDefence()
    {
        teamScoreManager.UpdateTeamDefenceScore(-20);
        effectPanel.SetActive(true);
        text.text = "Defence went down by 20";
    }

    public void UpdateSpeed()
    {
        teamScoreManager.UpdateTeamTotalScore(-20);
        effectPanel.SetActive(true);
        text.text = "Speed went down by 20";
    }

    public void UpdateOffence(int amt)
    {
        teamScoreManager.UpdateTeamOffenceScore(amt);        
        effectPanel.SetActive(true);
        text.text = "Offence went down by " + amt;
    }

    public void UpdateTeamForm()
    {
        teamScoreManager.UpdateTeamForm(-15);
        effectPanel.SetActive(true);
        text.text = "Form went down by 15";
    }

    public void UpdatePlayerForm()
    {
        effectPanel.SetActive(true);
        text.text = "Defence went down by 20";
    }

    public void UpdateTeamScore()
    {
        print("UpdateTeamScore");
        effectPanel.SetActive(true);        
        text.text = "Team score changed............";
    }

    public void RedCard()
    {
        print("RedCard");
        effectPanel.SetActive(true);
    }
}