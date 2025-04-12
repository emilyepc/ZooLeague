using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ManagerRoster : MonoBehaviour
{

    public Slider offenceSlider;
    public Slider defenceSlider;
    public Slider speedSlider;
    public Slider formSlider;
    public TMP_Text playerNameText;
    public TMP_Text playerPositionText;
    public GameObject lastModel;

    //model3D = currentmodel

    public void ChangePlayer(PlayerSO playerSO, GameObject model3D)
    {
        playerNameText.text = playerSO.playerName;
        playerPositionText.text = playerSO.playerPosition;
        offenceSlider.value = playerSO.offenceP;
        defenceSlider.value = playerSO.defenceP;
        speedSlider.value = playerSO.speedP;


        if (lastModel != null)
        {
            lastModel.SetActive(false);

        }

        lastModel = model3D;
        lastModel.SetActive(true);

    }

}
