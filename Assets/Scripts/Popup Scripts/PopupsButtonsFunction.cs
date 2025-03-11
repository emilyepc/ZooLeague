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

    public void UpdateDefence(string effectText, int amt)
    {
        teamScoreManager.UpdateTeamDefenceScore(amt);
        effectPanel.SetActive(true);
        text.text = effectText;
    }

    public void UpdateSpeed(string effectText, int amt)
    {
        teamScoreManager.UpdateTeamTotalScore(amt);
        effectPanel.SetActive(true);
        text.text = "Speed went down by 20";
    }

    public void UpdateOffence(string effectText, int amt)
    {
        teamScoreManager.UpdateTeamOffenceScore(amt);        
        effectPanel.SetActive(true);
        text.text = "Offence went down by " + amt;
    }

    public void UpdateTeamForm(string effectText, int amt)
    {
        teamScoreManager.UpdateTeamForm(-15);
        effectPanel.SetActive(true);
        text.text = "Form went down by 15";
    }

    public void UpdatePlayerForm(string effectText, int amt)
    {
        effectPanel.SetActive(true);
        text.text = "Defence went down by 20";
    }

    public void UpdateTeamScore(string effectText, int amt)
    {
        
        effectPanel.SetActive(true);        
        text.text = "Team score changed............";
    }

    public void UpdateNothing(string effectText)
    {
        effectPanel.SetActive(true);     
        text.text = effectText;
    }

    public void RedCard()
    {
        print("RedCard");
        effectPanel.SetActive(true);
    }
}