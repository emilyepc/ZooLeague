using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ManagerRoster : MonoBehaviour
{
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
    
    public GameObject lastModel;

    //model3D = currentmodel

    public void ChangePlayer(PlayerSO playerSO, GameObject model3D)
    {
        playerNameText.text = playerSO.playerName;
        playerPositionText.text = playerSO.playerPosition;
        offenceSlider.value = playerSO.offenceP;
        defenceSlider.value = playerSO.defenceP;
        speedSlider.value = playerSO.speedP;
            
        offenceText.text = playerSO.offenceP.ToString();
        defenceText.text = playerSO.defenceP.ToString();
        speedText.text = playerSO.speedP.ToString();

        formSlider.value = playerSO.formP;
        formSlider.maxValue = playerSO.maxFormP;
        formText.text = playerSO.formP.ToString();
        formMaxText.text = playerSO.maxFormP.ToString();
        
        if (lastModel != null)
        {
            lastModel.SetActive(false);

        }

        lastModel = model3D;
        lastModel.SetActive(true);

    }

    public void TurnOff3DModel()
    {
        if (lastModel != null)
            lastModel.SetActive(false);
    }
}
