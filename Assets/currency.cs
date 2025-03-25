using UnityEngine;
using TMPro;

public class currency : MonoBehaviour
{
   
    public int coins = 0;
    public int diamonds = 0;

  
    public int coinBuyAmount = 0;
    public int diamondBuyAmount = 0;

    public TMP_Text coinsText;
    public TMP_Text diamondsText;

    void Start()
    {
        UpdateCurrencyDisplay();
    }

    void UpdateCurrencyDisplay()
    {
        coinsText.text = "Coins: " + coins.ToString();
        diamondsText.text = "Diamonds: " + diamonds.ToString();
    }

    public void BuyWithCoins()
    {
        if (coins >= coinBuyAmount)
        {
            coins -= coinBuyAmount;
            UpdateCurrencyDisplay();
        }
        else
        {
            Debug.Log("eh no");
        }
    }

    public void BuyWithDiamonds()
    {
        if (diamonds >= diamondBuyAmount)
        {
            diamonds -= diamondBuyAmount;
            UpdateCurrencyDisplay();
        }
        else
        {
            Debug.Log("eh no");
        }
    }
}



