using UnityEngine;
using Unity.UI;
using TMPro;

public class currency : MonoBehaviour
{
    public Upgrader upgraderTarget;
    
    public int coins = 50;
    public int gems = 50;
    public int energy = 50;

    public TMP_Text coinsText;
    public TMP_Text gemsText;
    public TMP_Text energyText;

    void Start()
    {
        UpdateCurrencyDisplay();
    }

    private void UpdateCurrencyDisplay()
    {
        coinsText.text = coins.ToString();
        gemsText.text = gems.ToString();
        energyText.text = energy + " / 50";
    }

    public void Who(Upgrader upgrader)
    {
        upgraderTarget = upgrader;
    }
    
    public void BuyWithCoins(int cost)
    {
        if (coins >= cost)
        {
            coins -= cost;
            UpdateCurrencyDisplay();
            upgraderTarget.ChooseBoost(cost);
        }
        else 
            Debug.Log("Not enough coins");
    }

    public void BuyWithDiamonds(int cost)
    {
        if (gems >= cost)
        {
            gems -= cost;
            UpdateCurrencyDisplay();
            upgraderTarget.ChooseBoost(cost);
        }
        else 
            Debug.Log("Not enough gems");
    }

    public void OpenGacha(int cost)
    {
        if (gems >= cost)
        {
            gems -= cost;
            UpdateCurrencyDisplay();
            MysteryBox.Instance.ActivateObject();
        }
        else 
            Debug.Log("Not enough gems");
    }

    public void BuyWithEnergy(int cost)
    {
        if (energy >= cost)
        {
            energy -= cost;
            UpdateCurrencyDisplay();
            upgraderTarget.ChooseBoost(cost);
        }
        else 
            print ("Not enough energy");
    }
}

