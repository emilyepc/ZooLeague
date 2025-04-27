using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class PopupEventsManager : MonoBehaviour
{
    [Header("References")]
    public MatchSimulation matchSimulation;
    public TeamScoreManager teamScoreManager;
    [HideInInspector] public PlayerSO player;
    
    [Header("Panels")]
    public GameObject homePanel;
    public GameObject managerPanel;
    public GameObject matchSelectPanel;
    public GameObject teamSelectPanel;
    public GameObject continueButton;
    
    [Header("UI Elements")]
    public TMP_Text popupText;
    public TMP_Text choiceOneEffectText;
    public TMP_Text choiceTwoEffectText;
    public Button choiceOneButton;
    public Button choiceTwoButton;
    public GameObject effectPanel;
    public TMP_Text consequenceText;
    
    private void Start()
    {
        effectPanel.SetActive(false);
        continueButton.SetActive(false);
    }
    
    public void SetupPopup(PopupSO popupEvent)
    {
        popupText.text = string.Format(popupEvent.popupText, player.playerName);
        
        choiceOneButton.GetComponentInChildren<TMP_Text>().text = string.Format(popupEvent.choiceOneText, player.playerName);
        choiceOneEffectText.text = string.Format(popupEvent.choiceOneEffectText, player.playerName);
        
        choiceTwoButton.GetComponentInChildren<TMP_Text>().text = string.Format(popupEvent.choiceTwoText, player.playerName);
        choiceTwoEffectText.text = string.Format(popupEvent.choiceTwoEffectText, player.playerName);

        choiceOneButton.onClick.RemoveAllListeners();
        choiceOneButton.onClick.AddListener(() => ExecuteAction(popupEvent.choiceOneAction));
        
        choiceTwoButton.onClick.RemoveAllListeners();
        choiceTwoButton.onClick.AddListener(() => ExecuteAction(popupEvent.choiceTwoAction));
    }

    private void ExecuteAction(PopupActions action)
    {
        effectPanel.SetActive(true);

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
        
        consequenceText.text = string.Format(action.effectText, player.playerName);
        TeamScoreManager.instance.UpdateScoreboard();
    }

    //BELOW IS THE UPGRADES EFFECTS <3

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
        consequenceText.text = "Team score changed............";
    }

    private void UpdateNothing()
    {
        
    }

    private void RedCard()
    {
        print("RedCard");
    }
}
