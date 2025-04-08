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
    
    public string effectText1;
    public string effectText2;
    
    public void InjuryPopup()
{
    popupText.text = "A player has gotten a minor injury! What will you do?";
    
    choiceOneButton.GetComponentInChildren<TMP_Text>().text = "Substitute player";
    choiceOneEffectText.text = "Change formation";
    
    choiceTwoButton.GetComponentInChildren<TMP_Text>().text = "Keep playing";
    choiceTwoEffectText.text = "Player form -10";

    effectText1 = "";
    effectText2 = "Form decreased by 10.";
    
    choiceOneButton.onClick.AddListener(() => popupsButtonsFunction.UpdateTeamFormation());
    
    choiceTwoButton.onClick.RemoveAllListeners();
    choiceTwoButton.onClick.AddListener(() => popupsButtonsFunction.UpdateTeamForm(effectText2, 10));
}

public void YellowCardPopup()
{
    popupText.text = "A player has gotten a yellow card for playing aggressively.";

    choiceOneButton.GetComponentInChildren<TMP_Text>().text = "Tell them off";
    choiceOneEffectText.text = "Team defence up, form down";
    
    choiceTwoButton.GetComponentInChildren<TMP_Text>().text = "Encourage them";
    choiceTwoEffectText.text = "Team offence up, defence down";
    
    effectText1 = "Team defence increased by 20, team form decreased.";
    effectText2 = "Team offence increased by 20, team defence decreased.";
    
    choiceOneButton.onClick.RemoveAllListeners();
    choiceOneButton.onClick.AddListener(() => popupsButtonsFunction.UpdateDefence(effectText1, 20));
    choiceOneButton.onClick.AddListener(() => popupsButtonsFunction.UpdateTeamForm(effectText1, -20));
    
    choiceTwoButton.onClick.RemoveAllListeners();
    choiceTwoButton.onClick.AddListener(() => popupsButtonsFunction.UpdateOffence(effectText2, 20));
    choiceTwoButton.onClick.AddListener(() => popupsButtonsFunction.UpdateDefence(effectText2, -20));
    
    
}

public void RedCardPopup()
{
    popupText.text = "One of your players has received a red card for bad behaviour.";
    
    choiceOneButton.GetComponentInChildren<TMP_Text>().text = "Substitute player";
    choiceOneEffectText.text = "Change formation";

    choiceTwoButton.GetComponentInChildren<TMP_Text>().text = "Keep playing";
    choiceTwoEffectText.text = "Player form -10";
    
    effectText1 = "";
    effectText2 = "The player's form decreased by 10";
    
    choiceOneButton.onClick.RemoveAllListeners();
    choiceOneButton.onClick.AddListener(() => popupsButtonsFunction.UpdateTeamFormation());

    choiceTwoButton.onClick.RemoveAllListeners();
    choiceTwoButton.onClick.AddListener(() => popupsButtonsFunction.UpdatePlayerForm(effectText2, -10));
}

public void FakeInjuryPopup()
{
    popupText.text = "One of your players is pretending to be injured, looking for a penalty.";

    choiceOneButton.GetComponentInChildren<TMP_Text>().text = "Encourage them";
    choiceOneEffectText.text = "Team score up, but chance to get a red card";

    choiceTwoButton.GetComponentInChildren<TMP_Text>().text = "Stop them";
    choiceTwoEffectText.text = "Form down -10";
    
    effectText1 = "Team score increased by 20.";
    effectText2 = "Team overall form decreased by ten.";
    
    choiceOneButton.onClick.RemoveAllListeners();
    choiceOneButton.onClick.AddListener(() => popupsButtonsFunction.UpdateTeamScore(effectText1, 20));
    
    choiceTwoButton.onClick.RemoveAllListeners();
    choiceTwoButton.onClick.AddListener(() => popupsButtonsFunction.UpdateTeamForm(effectText2, -10));
}

public void FatiguePopup()
{
    popupText.text = "A player is feeling tired and their form is very low. Take them off?";

    choiceOneButton.GetComponentInChildren<TMP_Text>().text = "Substitute player";
    choiceOneEffectText.text = "Change team formation";

    choiceTwoButton.GetComponentInChildren<TMP_Text>().text = "Keep playing";
    choiceTwoEffectText.text = "No impact";

    effectText1 = "";
    effectText2 = "The game continues...";

    choiceOneButton.onClick.RemoveAllListeners();
    choiceOneButton.onClick.AddListener(() => popupsButtonsFunction.UpdateTeamFormation());
    
    choiceTwoButton.onClick.RemoveAllListeners();
    choiceTwoButton.onClick.AddListener(() => popupsButtonsFunction.UpdateNothing(effectText2));
}
    
    public void HalftimePopup()
    {
        //at halftime, or
        //give moral boost? or change formation?
    }
}

