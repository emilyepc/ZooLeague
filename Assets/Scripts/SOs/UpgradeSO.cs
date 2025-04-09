using UnityEngine;
using UnityEngine.Serialization;

public enum UpgradeType
{
    IncreaseCrowdRevenue,
    IncreaseCrowdMoral,
    IncreaseSponsorRevenue,
    IncreaseSponsorRelationship,
}

[CreateAssetMenu(fileName = "UpgradeSO", menuName = "Scriptable Objects/UpgradeSO")]
public class UpgradeSO : ScriptableObject
{
    public string upgradeName;
    public UpgradeType upgradeType;
    public string upgradeDescription;  //make a [] in future bbg and update when used
    public string upgradeEffect; //same with this pookie
    public int upgradeEffectValue;
    public int upgradeCost;
    public int upgradeUses;
    public int upgradeMaxUses;

    public void UpgradeUsed()
    {
        if (upgradeUses < upgradeMaxUses)
        {
            upgradeUses++;
            // changes to data etc
        }
    }
}
