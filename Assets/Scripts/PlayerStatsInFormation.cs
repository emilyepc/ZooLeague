using UnityEngine;
using TMPro;
using UnityEngine.UI;


public class PlayerStatsInFormation : MonoBehaviour
{
    public TMP_Text playerNameText;
    public TMP_Text offenceText;
    public TMP_Text defenceText;
    public TMP_Text speedText;
    public TMP_Text formText;
    public TMP_Text formMaxText;
    public TMP_Text totalText;

    public Slider formSlider;

    public static PlayerStatsInFormation instance;

    private void Awake()
    {
        instance = this;
    }

    public void ShowStats(string playerName, int offence, int defence, int speed, int total, int form, int maxForm)
    {
        playerNameText.text = "Name: " + playerName;
        offenceText.text = "Offence: " + offence;
        defenceText.text = "Defence: " + defence;
        speedText.text = "Speed: " + speed;
        totalText.text = "Total Score: " + total;
        
        formSlider.value = form;
        formSlider.maxValue = maxForm;
        formText.text = form.ToString();
        formMaxText.text = maxForm.ToString();
    }
}
