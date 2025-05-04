using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class PopupEventsManager : MonoBehaviour
{
    [Header("References")]
    public MatchSimulation matchSimulation;
    public TeamScoreManager teamScoreManager;
    [HideInInspector] public PlayerSO player;

    [Header("UI Panels")]
    public SetupPopup playerPopupUI;
    public SetupPopup teamPopupUI;

    [Header("Navigation Panels")]
    public GameObject homePanel;
    public GameObject managerPanel;
    public GameObject matchSelectPanel;
    public GameObject teamSelectPanel;
    public GameObject continueButton;

    private SetupPopup currentUI;

    private void Start()
    {
        playerPopupUI.effectPanel.SetActive(false);
        teamPopupUI.effectPanel.SetActive(false);
        continueButton.SetActive(false);
    }

    public void SetupPopup(PopupSO popupEvent)
    {
        // Choose the correct panel based on popup category
        currentUI = popupEvent.category == Category.Player ? playerPopupUI : teamPopupUI;

        currentUI.SetPopup(
            popupEvent,
            player,
            ExecuteAction, // Choice One
            ExecuteAction  // Choice Two
        );
    }

    private void ExecuteAction(PopupActions action)
    {
        if (action.openCompletePanel)
        {
            currentUI.effectPanel.SetActive(true);
        }

        foreach (var effect in action.popupEffects)
        {
            switch (effect.actionType)
            {
                case PopupActionType.UpdateTeamFormation:
                    UpdateTeamFormation();
                    break;
                case PopupActionType.UpdateDefence:
                    UpdateDefence(effect.effectValue);
                    break;
                case PopupActionType.UpdateOffence:
                    UpdateOffence(effect.effectValue);
                    break;
                case PopupActionType.UpdateSpeed:
                    UpdateSpeed(effect.effectValue);
                    break;
                case PopupActionType.UpdateTeamForm:
                    UpdateTeamForm(effect.effectValue);
                    break;
                case PopupActionType.UpdatePlayerForm:
                    UpdatePlayerForm(effect.effectValue);
                    break;
                case PopupActionType.UpdateTeamScore:
                    UpdateTeamScore(effect.effectValue);
                    break;
                case PopupActionType.None:
                default:
                    UpdateNothing();
                    break;
            }
        }

        currentUI.ShowConsequence(string.Format(action.effectText, player.playerName));
        TeamScoreManager.instance.UpdateScoreboard();
    }

    // Effect handling methods

    private void UpdateTeamFormation()
    {
        homePanel.SetActive(false);
        managerPanel.SetActive(false);
        matchSelectPanel.SetActive(false);
        teamSelectPanel.SetActive(true);
        continueButton.SetActive(true);
    }

    private void UpdateDefence(int amt)
    {
        player.defenceP += amt;
    }

    private void UpdateSpeed(int amt)
    {
        player.speedP += amt;
    }

    private void UpdateOffence(int amt)
    {
        player.offenceP += amt;
    }

    private void UpdateTeamForm(int amt)
    {
        teamScoreManager.UpdateTeamForm(amt);
    }

    private void UpdatePlayerForm(int amt)
    {
        player.formP += amt;
    }

    private void UpdateTeamScore(int amt)
    {
        Debug.Log("Team score changed by " + amt);
        // Apply team score logic here if needed
    }

    private void UpdateNothing()
    {
        // No effect
    }
}
