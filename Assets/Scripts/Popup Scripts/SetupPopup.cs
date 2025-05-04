using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class SetupPopup : MonoBehaviour
{
    public TMP_Text popupText;
    public TMP_Text choiceOneEffectText;
    public TMP_Text choiceTwoEffectText;
    public Button choiceOneButton;
    public Button choiceTwoButton;
    public GameObject effectPanel;
    public TMP_Text consequenceText;

    public void SetPopup(PopupSO popupEvent, PlayerSO player, System.Action<PopupActions> onChoiceOne, System.Action<PopupActions> onChoiceTwo)
    {
        popupText.text = string.Format(popupEvent.popupText, player.playerName);

        choiceOneButton.GetComponentInChildren<TMP_Text>().text = string.Format(popupEvent.choiceOneText, player.playerName);
        choiceOneEffectText.text = string.Format(popupEvent.choiceOneEffectText, player.playerName);
        choiceOneButton.onClick.RemoveAllListeners();
        choiceOneButton.onClick.AddListener(() => onChoiceOne(popupEvent.choiceOneAction));

        choiceTwoButton.GetComponentInChildren<TMP_Text>().text = string.Format(popupEvent.choiceTwoText, player.playerName);
        choiceTwoEffectText.text = string.Format(popupEvent.choiceTwoEffectText, player.playerName);
        choiceTwoButton.onClick.RemoveAllListeners();
        choiceTwoButton.onClick.AddListener(() => onChoiceTwo(popupEvent.choiceTwoAction));

        effectPanel.SetActive(false);
    }

    public void ShowConsequence(string text)
    {
        effectPanel.SetActive(true);
        consequenceText.text = text;
    }
}