using UnityEngine;
using TMPro;
using UnityEngine.UI;


public class PlayerStatsInFormation : MonoBehaviour
{
    public static PlayerStatsInFormation instance;

    [Header("Text Values")]
    public TMP_Text playerNameText;
    public TMP_Text playerPositionText;
    public TMP_Text offenceText;
    public TMP_Text defenceText;
    public TMP_Text speedText;
    public TMP_Text formText;
    public TMP_Text formMaxText;
    public TMP_Text totalText;

    [Header("Sliders")]
    public Slider offenceSlider;
    public Slider defenceSlider;
    public Slider speedSlider;
    public Slider formSlider;

    [Header("Model Display")]
    public GameObject lastModel;
    
    private void Awake()
    {
        instance = this;
    }

    public void ShowStats(DraggablePlayer player, PlayerSO playerSo, GameObject model3D)
    {
        playerNameText.text = playerSo.playerName;
        playerPositionText.text = playerSo.playerPosition;

        if (player.currentSlot == null) //they are on the bench
        {
            offenceSlider.value = playerSo.offenceP;
            defenceSlider.value = playerSo.defenceP;
            speedSlider.value = playerSo.speedP;
            
            offenceText.text = playerSo.offenceP.ToString();
            defenceText.text = playerSo.defenceP.ToString();
            speedText.text = playerSo.speedP.ToString();
            
            totalText.text = (playerSo.offenceP + playerSo.defenceP + playerSo.speedP).ToString();
        }

        if (player.currentSlot != null) //they are somewhere on the field formation
        {
            offenceSlider.value = player.offenceScoreMultiplied;
            defenceSlider.value = player.defenceScoreMultiplied;
            speedSlider.value = player.speedScoreMultiplied;
            
            //see if the score has been impacted by a multiplier
            if (player.offenceScoreMultiplied != playerSo.offenceP)
                offenceText.text = player.offenceScoreMultiplied + " (+" + player.scoreMultiplier + ")";
            else
                offenceText.text = playerSo.offenceP.ToString();
            
            if (player.defenceScoreMultiplied != playerSo.defenceP)
                defenceText.text = player.defenceScoreMultiplied + " (+" + player.scoreMultiplier + ")";
            else
                defenceText.text = playerSo.defenceP.ToString();
            
            if (player.speedScoreMultiplied != playerSo.speedP)
                speedText.text = player.speedScoreMultiplied + " (+" + player.scoreMultiplier + ")";
            else
                speedText.text = playerSo.speedP.ToString();
            
            totalText.text = player.totalScore.ToString();
        }
        
        formSlider.value = playerSo.formP;
        formSlider.maxValue = playerSo.maxFormP;
        formText.text = playerSo.formP.ToString();
        formMaxText.text = playerSo.maxFormP.ToString();
        
        if (lastModel != null) lastModel.SetActive(false);
        lastModel = model3D;
        lastModel.SetActive(true);
    }
}
