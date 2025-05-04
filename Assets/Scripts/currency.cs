using System.Collections;
using UnityEngine;
using TMPro;

public class currency : MonoBehaviour
{
    public Upgrader upgraderTarget;
    public CurrencySO currencySO;
    
    public TMP_Text coinsText;
    public TMP_Text gemsText;
    public TMP_Text energyText;

    public bool canBuy;
    public TMP_Text feedbackText;
    
    void Start()
    {
        UpdateCurrencyDisplay();

        currencySO.coins = 40;
        currencySO.gems = 40;
        currencySO.energy = 50;
        currencySO.maxEnergy = 50;
    }

    public void UpdateCurrencyDisplay()
    {
        coinsText.text = currencySO.coins.ToString();
        gemsText.text = currencySO.gems.ToString();
        energyText.text = currencySO.energy + " / 50";
    }

    public void Who(Upgrader upgrader)
    {
        upgraderTarget = upgrader;
    }
    
    public void BuyWithCoins(int cost)
    {
        if (currencySO.coins >= cost)
        {
            currencySO.coins -= cost;
            UpdateCurrencyDisplay();
            upgraderTarget.ChooseBoost(cost);
            canBuy = true;
        }
        else
        {
            feedbackText.text = "Not enough coins!";
            StartCoroutine(ClearText());
            canBuy = false;
        }
        
    }
    
    public void BuyUpgradeInManager(int cost)
    {
        if (currencySO.coins >= cost)
        {
            currencySO.coins -= cost;
            UpdateCurrencyDisplay();
            canBuy = true;
        }
        else
        {
            feedbackText.text = "Not enough coins!";
            StartCoroutine(ClearText());
            canBuy = false;
        }
        
    }

    public void BuyWithDiamonds(int cost)
    {
        if (currencySO.gems >= cost)
        {
            currencySO.gems -= cost;
            UpdateCurrencyDisplay();
            if (upgraderTarget) upgraderTarget.ChooseBoost(cost);
            canBuy = true;
        }
        else
        {
            feedbackText.text = "Not enough gems!";
            StartCoroutine(ClearText());
            canBuy = false;
        }
    }

    public void OpenGacha(int cost)
    {
        if (currencySO.gems >= cost)
        {
            currencySO.gems -= cost;
            UpdateCurrencyDisplay();
            MysteryBox.Instance.ActivateObject();
        }
        else
        {
            feedbackText.text = "Not enough gems!";
            StartCoroutine(ClearText());
        }
    }

    public void BuyWithEnergy(int cost)
    {
        if (currencySO.energy >= cost)
        {
            currencySO.energy -= cost;
            UpdateCurrencyDisplay();
            upgraderTarget.ChooseBoost(cost);
        }
        else 
            print ("Not enough energy");
    }
    
    IEnumerator ClearText()
    {
        yield return new WaitForSeconds(3);
        feedbackText.text = "";
    }
}

