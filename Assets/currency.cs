using UnityEngine;
using Unity.UI;
using TMPro;

public class currency : MonoBehaviour
{
    // Currency values
    public int Coins = 0;
    public int Energy = 0;

    // TextMeshPro UI elements to display the currencies
    public TMP_Text coinsText;
    public TMP_Text energyText;

    void Start()
    {
        UpdateUI();
    }

    // Updates the UI text fields with the current currency values
    void UpdateUI()
    {
        if (coinsText != null)
        {
            coinsText.text = "Coins: " + Coins;
        }

        if (energyText != null)
        {
            energyText.text = "Energy: " + Energy;
        }
    }
}

