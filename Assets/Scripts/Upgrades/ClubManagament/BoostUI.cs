using System.Collections;
using UnityEngine;
using TMPro;
using Random = UnityEngine.Random;


public class BoostUI : MonoBehaviour
{
    public BoostSO boostSo;
    public SponsorSO crowdSo;
    public SponsorSO currentSponsorSo;
    public SponsorUI sponsorUI;
    public SponsorUI fanbaseUI;
    
    public TMP_Text boostName;
    public TMP_Text boostDescription; //say how long it lasts too
    public TMP_Text boostEffect;
    public TMP_Text boostCost;
    public TMP_Text boostUsesLeft;
    
    public TMP_Text upgradeFeedback;
    public TMP_Text nerfFeedback;

    private void Start()
    {
        UpdateText();
    }

    public void UpdateText()
    {
        boostName.text = boostSo.boostName;
        boostDescription.text = boostSo.boostDescription;
        boostEffect.text = "Effect: " + boostSo.boostEffect;
        boostCost.text = "Cost: " + boostSo.boostCost;
        //boostUsesLeft.text = "Boosts left: " + boostSo.boostUsesLeft;
    }
    
    
    public void ApplyUpgrade()
    {
        // the chance that a nerf will be applied as well!
        var chanceOfNerf = Random.Range(1, 15);
        
        switch (boostSo.buffType)
        {
            case BuffType.IncreaseCrowdRevenue:
                crowdSo.sponsorPayment += boostSo.buffEffectValue;
                if (chanceOfNerf >= 10) ApplyNerf(boostSo.nerfType);
                upgradeFeedback.text = "Crowd Revenue upped by " + boostSo.buffEffectValue + "to" + crowdSo.sponsorPayment;
                StartCoroutine(ResetFeedbackText());
                break;
            case BuffType.IncreaseCrowdMoral:
                crowdSo.sponsorRelationship += boostSo.buffEffectValue;
                if (chanceOfNerf >= 10) ApplyNerf(boostSo.nerfType);
                upgradeFeedback.text = "Crowd Morale upped by " + boostSo.buffEffectValue + "to" + crowdSo.sponsorRelationship;
                StartCoroutine(ResetFeedbackText());
                break;
            case BuffType.IncreaseSponsorRevenue:
                currentSponsorSo.sponsorPayment += boostSo.buffEffectValue;
                if (chanceOfNerf >= 10) ApplyNerf(boostSo.nerfType);
                upgradeFeedback.text = "Sponsor Revenue upped by " + boostSo.buffEffectValue + "to" + currentSponsorSo.sponsorPayment;
                StartCoroutine(ResetFeedbackText());
                break;
            case BuffType.IncreaseSponsorRelationship:
                currentSponsorSo.sponsorRelationship += boostSo.buffEffectValue;
                if (chanceOfNerf >= 10) ApplyNerf(boostSo.nerfType);
                upgradeFeedback.text = "Sponsor Relationship upped by " + boostSo.buffEffectValue + "to" + currentSponsorSo.sponsorRelationship;
                StartCoroutine(ResetFeedbackText());
                break;
            default:
                Debug.LogWarning("Upgrade effect not recognized!");
                break;
        }
        
        boostSo.BoostUsed();
        UpdateText();
        sponsorUI.UpdateUI();
        fanbaseUI.UpdateUI();
    }

    private void ApplyNerf(NerfType nerfType)
    {
        switch (boostSo.nerfType)
        {
            case NerfType.DecreaseCrowdRevenue:
                crowdSo.sponsorPayment -= boostSo.nerfEffectValue;
                nerfFeedback.text = "Crowd Revenue nerfed by " + boostSo.buffEffectValue + "to" + crowdSo.sponsorPayment;
                StartCoroutine(ResetFeedbackText());
                break;
            case NerfType.DecreaseCrowdMoral:
                crowdSo.sponsorRelationship -= boostSo.nerfEffectValue;
                nerfFeedback.text = "Crowd Morale nerfed by " + boostSo.buffEffectValue + "to" + crowdSo.sponsorRelationship;
                StartCoroutine(ResetFeedbackText());
                break;
            case NerfType.DecreaseSponsorRevenue:
                currentSponsorSo.sponsorPayment -= boostSo.nerfEffectValue;
                nerfFeedback.text = "Sponsor Revenue nerfed by " + boostSo.buffEffectValue + "to" + currentSponsorSo.sponsorPayment;
                StartCoroutine(ResetFeedbackText());
                break;
            case NerfType.DecreaseSponsorRelationship:
                currentSponsorSo.sponsorRelationship -= boostSo.nerfEffectValue;
                nerfFeedback.text = "Sponsor Relationship nerfed by " + boostSo.buffEffectValue + "to" + currentSponsorSo.sponsorRelationship;
                StartCoroutine(ResetFeedbackText());
                break;
            
            // Add more nerfs here
            default:
                Debug.LogWarning("No nerf defined for: " + nerfType);
                break;
        }
        sponsorUI.UpdateUI();
        fanbaseUI.UpdateUI();
    }
    
    IEnumerator ResetFeedbackText()
    {
        yield return new WaitForSeconds(4f);
        upgradeFeedback.text = "";
        nerfFeedback.text = "";
    }
}
