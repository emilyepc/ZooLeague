using System;
using UnityEngine;
using TMPro;
using Unity.VisualScripting;
using UnityEngine.UI;

public class SponsorUI : MonoBehaviour
{
    public SponsorSO sponsorSo;
    
    public TMP_Text sponsorName;
    public Image sponsorImage;
    public TMP_Text sponsorRevenue;
    public Slider sponsorRelationship;

    private void Start()
    {
        UpdateUI();
    }

    public void UpdateUI()
    {
        sponsorName.text = sponsorSo.sponsorName;
        sponsorImage.sprite = sponsorSo.sponsorIcon;
        sponsorRevenue.text = "Revenue per game = " + sponsorSo.sponsorPayment + " coins";
        sponsorRelationship.value = sponsorSo.sponsorRelationship;
    }
}
