using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ManagerRoster : MonoBehaviour
{

    public Slider offenceSlider;
    public Slider defenceSlider;
    public Slider speedSlider;
    public Slider formSlider;
    public TMP_Text playernameText;
    public TMP_Text playerpositionText;
    public GameObject lastModel;

    //model3D = currentmodel

    public void ChangePlayer(PlayerSO playerSO, GameObject model3D)
    {
        playernameText.text = playerSO.playerName;
        playerpositionText.text = playerSO.playerPosition;
        offenceSlider.value = playerSO.offenceP;


        if (lastModel != null)
        {
            lastModel.SetActive(false);

        }

        lastModel = model3D;
        lastModel.SetActive(true);

    }

}
