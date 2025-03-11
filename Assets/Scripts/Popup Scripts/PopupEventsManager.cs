using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PopupEventsManager : MonoBehaviour
{
    public PopupsButtonsFunction popupsButtonsFunction;
    
    public TMP_Text popupText;
    public TMP_Text choiceOneEffectText;
    public TMP_Text choiceTwoEffectText;
    public Button choiceOneButton;
    public Button choiceTwoButton;
    
    public void InjuryPopup()
{
    popupText.text = "A player has gotten a minor injury! What will you do?";
    
    choiceOneButton.GetComponentInChildren<TMP_Text>().text = "Substitute player";
    choiceOneEffectText.text = "Change formation";
    
    choiceTwoButton.GetComponentInChildren<TMP_Text>().text = "Keep playing";
    choiceTwoEffectText.text = "Player form -10";
}

public void YellowCardPopup()
{
    popupText.text = "A player has gotten a yellow card for playing aggressively.";

    choiceOneButton.GetComponentInChildren<TMP_Text>().text = "Tell them off";
    choiceOneEffectText.text = "Team defence up, form down";
    
    choiceTwoButton.GetComponentInChildren<TMP_Text>().text = "Encourage them";
    choiceTwoEffectText.text = "Team offence up, defence down";
    
    choiceOneButton.onClick.RemoveAllListeners();
    choiceOneButton.onClick.AddListener(() => popupsButtonsFunction.UpdateDefence());
    choiceOneButton.onClick.AddListener(() => popupsButtonsFunction.UpdateTeamForm());

    choiceTwoButton.onClick.RemoveAllListeners();
    choiceTwoButton.onClick.AddListener(() => popupsButtonsFunction.UpdateOffence(15));
    choiceTwoButton.onClick.AddListener(() => popupsButtonsFunction.UpdateDefence());
}

public void RedCardPopup()
{
    popupText.text = "One of your players has received a red card for bad behaviour.";
    
    choiceOneButton.GetComponentInChildren<TMP_Text>().text = "Substitute player";
    choiceOneEffectText.text = "Change formation";

    choiceTwoButton.GetComponentInChildren<TMP_Text>().text = "Keep playing";
    choiceTwoEffectText.text = "Player form -10";

    choiceOneButton.onClick.RemoveAllListeners();
    choiceOneButton.onClick.AddListener(() => popupsButtonsFunction.UpdateTeamFormation());

    choiceTwoButton.onClick.RemoveAllListeners();
    choiceTwoButton.onClick.AddListener(() => popupsButtonsFunction.UpdatePlayerForm());
}

public void FakeInjuryPopup()
{
    popupText.text = "One of your players is pretending to be injured, looking for a penalty.";

    choiceOneButton.GetComponentInChildren<TMP_Text>().text = "Encourage them";
    choiceOneEffectText.text = "Team score up, but chance to get a red card";

    choiceTwoButton.GetComponentInChildren<TMP_Text>().text = "Stop them";
    choiceTwoEffectText.text = "Form down -5";

    choiceOneButton.onClick.RemoveAllListeners();
    choiceOneButton.onClick.AddListener(() => popupsButtonsFunction.UpdateTeamScore());

    choiceTwoButton.onClick.RemoveAllListeners();
    choiceTwoButton.onClick.AddListener(() => popupsButtonsFunction.UpdateTeamForm());
}

public void FatiguePopup()
{
    popupText.text = "A player is feeling tired and their form is very low. Take them off?";

    choiceOneButton.GetComponentInChildren<TMP_Text>().text = "Substitute player";
    choiceOneEffectText.text = "Change team formation";

    choiceTwoButton.GetComponentInChildren<TMP_Text>().text = "Keep playing";
    choiceTwoEffectText.text = "No impact";

    choiceOneButton.onClick.RemoveAllListeners();
    choiceOneButton.onClick.AddListener(() => popupsButtonsFunction.UpdateTeamFormation());
}

    
    public void HalftimePopup()
    {
        //at halftime, or
        //give moral boost? or change formation?
    }
}

