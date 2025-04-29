using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class FanbaseUI : MonoBehaviour
{
    public SponsorSO fanbase;
    public TMP_Text sponsorName;
    public Image sponsorImage;
    public TMP_Text sponsorRevenue;
    public Slider sponsorRelationship;
    
    
    public void UpdateUI()
    {
        fanbase.CalculatePayout();
        sponsorName.text = fanbase.sponsorName;
        sponsorImage.sprite = fanbase.sponsorIcon;
        sponsorRevenue.text = "Approx. revenue per game = " + fanbase.currentPayout + " coins";
        sponsorRelationship.value = fanbase.sponsorRelationship;
    }
}
