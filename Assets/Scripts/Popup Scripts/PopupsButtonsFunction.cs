using UnityEngine;
using TMPro;

public class PopupsButtonsFunction : MonoBehaviour
{
    public MatchSimulation matchSimulation;
    public GameObject effectPanel;
    public TeamScoreManager teamScoreManager;
    public TMP_Text text;
    public GameObject homePanel;
    public GameObject ManagerPanel;
    public GameObject matchSelectPanel;
    public GameObject teamSelectPanel;
    public GameObject continueButton;

    private void Start()
    {
        effectPanel.SetActive(false);
    }

    public void UpdateTeamFormation()
    {
        homePanel.SetActive(false);
        ManagerPanel.SetActive(false);
        matchSelectPanel.SetActive(false);
        teamSelectPanel.SetActive(true);
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
        text.text = effectText;
    }

    public void UpdateOffence(string effectText, int amt)
    {
        teamScoreManager.UpdateTeamOffenceScore(amt);        
        effectPanel.SetActive(true);
        text.text = effectText;
    }

    public void UpdateTeamForm(string effectText, int amt)
    {
        teamScoreManager.UpdateTeamForm(amt);
        effectPanel.SetActive(true);
        text.text = effectText;
    }

    public void UpdatePlayerForm(string effectText, int amt)
    {
        effectPanel.SetActive(true);
        text.text = effectText;
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