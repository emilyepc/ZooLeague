using System;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.PlayerLoop;
using UnityEngine.UI;
using Random = System.Random;

public class SponsorUI : MonoBehaviour
{
    [Header("??")]
    public List<SponsorSO> sponsors;

    public GameObject findingSponsorPanel;
    public GameObject hasSponsorPanel;
    
    //sponsor one
    public SponsorSO sponsorOne;
    public TMP_Text sponsorOneName;
    public Image sponsorOneImage;
    public TMP_Text sponsorOneDescription;
    
    //sponsor two
    public SponsorSO sponsorTwo;
    public TMP_Text sponsorTwoName;
    public Image sponsorTwoImage;
    public TMP_Text sponsorTwoDescription;
    
    [Header("??")]
    public SponsorSO currentSponsor;
    public TMP_Text sponsorName;
    public Image sponsorImage;
    public TMP_Text sponsorRevenue;
    public Slider sponsorRelationship;

    private void Start()
    {
        RandomiseSponsors();
        findingSponsorPanel.SetActive(true);
        hasSponsorPanel.SetActive(false);
    }

    public void OpenPanel()
    {
        if (currentSponsor != null)
        {
            hasSponsorPanel.SetActive(true);
            findingSponsorPanel.SetActive(false);
        }
        else
        {
            findingSponsorPanel.SetActive(true);
            hasSponsorPanel.SetActive(false);
        }
    }
    
    public void RandomiseSponsors()
    {
        if (currentSponsor != null) return;
        
        sponsorOne = sponsors[UnityEngine.Random.Range(0, sponsors.Count)];
        sponsorTwo = sponsors[UnityEngine.Random.Range(0, sponsors.Count)];
        while (sponsorOne == sponsorTwo)
            sponsorTwo = sponsors[UnityEngine.Random.Range(0, sponsors.Count)];
        
        sponsorOneName.text = sponsorOne.sponsorName;
        sponsorOneImage.sprite = sponsorOne.sponsorIcon;
        sponsorOneDescription.text = sponsorOne.sponsorDescription;
        
        sponsorTwoName.text = sponsorTwo.sponsorName;
        sponsorTwoImage.sprite = sponsorTwo.sponsorIcon;
        sponsorTwoDescription.text = sponsorTwo.sponsorDescription;
    }

    public void SelectSponsorOne()
    {
        currentSponsor = sponsorOne;
        UpdateUI();
        OpenPanel();
    }

    public void SelectSponsorTwo()
    {
        currentSponsor = sponsorTwo;
        UpdateUI();
        OpenPanel();
    }

    public void QuitSponsorship()
    {
        currentSponsor = null;
        RandomiseSponsors();
        OpenPanel();
    }
    
    public void UpdateUI()
    {
        sponsorName.text = currentSponsor.sponsorName;
        sponsorImage.sprite = currentSponsor.sponsorIcon;
        sponsorRevenue.text = "Revenue per game = " + currentSponsor.sponsorPayment + " coins";
        sponsorRelationship.value = currentSponsor.sponsorRelationship;
    }
}
