using System.Collections;
using UnityEngine;
using TMPro;
public class UpgradesUI : MonoBehaviour
{
    public UpgradeSO upgradeSo;
    public SponsorSO crowdSo;
    public SponsorSO currentSponsorSo;
    public currency currencySystem;
    
    public SponsorUI sponsorUI;
    public SponsorUI fanbaseUI;
    
    public TMP_Text upgradeName;
    public TMP_Text upgradeDescription;
    public TMP_Text upgradeEffect;
    public TMP_Text upgradeCost;
    public TMP_Text upgradeUses;
    
    public TMP_Text upgradeFeedback;

    public void Start()
    {
        UpdateText();
    }

    public void UpdateText()
    {
        upgradeName.text = upgradeSo.upgradeName;
        upgradeDescription.text = upgradeSo.upgradeDescription;
        upgradeEffect.text = "Effect: " + upgradeSo.upgradeEffect;
        upgradeCost.text = "Cost: " + upgradeSo.upgradeCost;
        upgradeUses.text = "Times upgraded: " + upgradeSo.upgradeUses + "/" + upgradeSo.upgradeMaxUses;
    }

    public void ApplyUpgrade()
    {
        switch (upgradeSo.upgradeType)
        {
            case UpgradeType.IncreaseCrowdMinRevenue:
                crowdSo.minPayout += upgradeSo.upgradeEffectValue;
                upgradeFeedback.text = "Crowd min payout increased by " + upgradeSo.upgradeEffectValue + "to" + crowdSo.minPayout;
                StartCoroutine(ResetFeedbackText());
                break;
            case UpgradeType.IncreaseCrowdMaxRevenue:
                crowdSo.maxPayout += upgradeSo.upgradeEffectValue;
                upgradeFeedback.text = "Crowd max payout increased by " + upgradeSo.upgradeEffectValue + "to" + crowdSo.maxPayout;
                StartCoroutine(ResetFeedbackText());
                break;
            case UpgradeType.IncreaseCrowdMoral:
                crowdSo.sponsorRelationship += upgradeSo.upgradeEffectValue;
                if (crowdSo.sponsorRelationship > 100 ) crowdSo.sponsorRelationship = 100; 
                upgradeFeedback.text = "Crowd moral upped by " + upgradeSo.upgradeEffectValue + "to" + crowdSo.sponsorRelationship;
                StartCoroutine(ResetFeedbackText());
                break;
            case UpgradeType.IncreaseSponsorMaxRevenue:
                currentSponsorSo.maxPayout += upgradeSo.upgradeEffectValue;
                upgradeFeedback.text = "Sponsor max payout upped by " + upgradeSo.upgradeEffectValue + "to" + currentSponsorSo.maxPayout;
                StartCoroutine(ResetFeedbackText());
                break;
            case UpgradeType.IncreaseSponsorMinRevenue:
                currentSponsorSo.minPayout += upgradeSo.upgradeEffectValue;
                upgradeFeedback.text = "Sponsor min payout upped by " + upgradeSo.upgradeEffectValue + "to" + currentSponsorSo.minPayout;
                StartCoroutine(ResetFeedbackText());
                break;
            case UpgradeType.IncreaseSponsorRelationship:
                currentSponsorSo.sponsorRelationship += upgradeSo.upgradeEffectValue;
                if (currentSponsorSo.sponsorRelationship > 100) currentSponsorSo.sponsorRelationship = 100;
                upgradeFeedback.text = "Sponsor Relationship upped by " + upgradeSo.upgradeEffectValue + "to" + currentSponsorSo.sponsorRelationship;
                StartCoroutine(ResetFeedbackText());
                break;
            default:
                Debug.LogWarning("Upgrade effect not recognised!");
                break;
        }
        
        
        upgradeSo.UpgradeUsed();
        UpdateText();
        sponsorUI.UpdateUI();
        fanbaseUI.UpdateUI();
    }

    IEnumerator ResetFeedbackText()
    {
        yield return new WaitForSeconds(2f);
        upgradeFeedback.text = "";
    }
}
