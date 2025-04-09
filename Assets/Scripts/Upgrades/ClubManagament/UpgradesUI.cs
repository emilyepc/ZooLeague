using System.Collections;
using UnityEngine;
using TMPro;
public class UpgradesUI : MonoBehaviour
{
    public UpgradeSO upgradeSo;
    public SponsorSO crowdSo;
    public SponsorSO currentSponsorSo;
    
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
        ResetSos();
    }

    private void ResetSos()
    {
        crowdSo.sponsorRelationship = 10;
        crowdSo.sponsorPayment = 15;
        
        currentSponsorSo.sponsorRelationship = 10;
        currentSponsorSo.sponsorPayment = 15;
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
            case UpgradeType.IncreaseCrowdRevenue:
                crowdSo.sponsorPayment += upgradeSo.upgradeEffectValue;
                upgradeFeedback.text = "Crowd Revenue upped by " + upgradeSo.upgradeEffectValue + "to" + crowdSo.sponsorPayment;
                StartCoroutine(ResetFeedbackText());
                break;
            case UpgradeType.IncreaseCrowdMoral:
                crowdSo.sponsorRelationship += upgradeSo.upgradeEffectValue;
                upgradeFeedback.text = "Crowd moral upped by " + upgradeSo.upgradeEffectValue + "to" + crowdSo.sponsorRelationship;
                StartCoroutine(ResetFeedbackText());
                break;
            case UpgradeType.IncreaseSponsorRevenue:
                currentSponsorSo.sponsorPayment += upgradeSo.upgradeEffectValue;
                upgradeFeedback.text = "Sponsor Revenue upped by " + upgradeSo.upgradeEffectValue + "to" + currentSponsorSo.sponsorPayment;
                StartCoroutine(ResetFeedbackText());
                break;
            case UpgradeType.IncreaseSponsorRelationship:
                currentSponsorSo.sponsorRelationship += upgradeSo.upgradeEffectValue;
                upgradeFeedback.text = "Sponsor Relationship upped by " + upgradeSo.upgradeEffectValue + "to" + currentSponsorSo.sponsorRelationship;
                StartCoroutine(ResetFeedbackText());
                break;
            default:
                Debug.LogWarning("Upgrade effect not recognized!");
                break;
        }
        
        upgradeSo.UpgradeUsed();
        UpdateText();
        sponsorUI.UpdateUI();
        fanbaseUI.UpdateUI();
    }

    IEnumerator ResetFeedbackText()
    {
        yield return new WaitForSeconds(4f);
        upgradeFeedback.text = "";
    }
}
