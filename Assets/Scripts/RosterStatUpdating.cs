using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class RosterStatUpdating : MonoBehaviour
{
    public TMP_Text playerNameText;
    public TMP_Text offenceText;
    public TMP_Text defenceText;
    public TMP_Text speedText;
    public TMP_Text formText;
    public TMP_Text formMaxText;

    public Slider formSlider;
    
    
    public void ShowStats(string playerName, int offence, int defence, int speed, int form, int maxForm)
    {
        playerNameText.text = "Name: " + playerName;
        offenceText.text = "Offence: " + offence;
        defenceText.text = "Defence: " + defence;
        speedText.text = "Speed: " + speed;
        
        formSlider.value = form;
        formSlider.maxValue = maxForm;
        formText.text = form.ToString();
        formMaxText.text = maxForm.ToString();
    }
}
