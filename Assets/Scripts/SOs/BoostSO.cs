using UnityEngine;

public enum BuffType
{
    IncreaseCrowdRevenue,
    IncreaseCrowdMoral,
    IncreaseSponsorRevenue,
    IncreaseSponsorRelationship,
}

public enum NerfType
{
    DecreaseCrowdRevenue,
    DecreaseCrowdMoral,
    DecreaseSponsorRevenue,
    DecreaseSponsorRelationship,
    NoneYay
}


[CreateAssetMenu(fileName = "BoostSO", menuName = "Scriptable Objects/BoostSO")]
public class BoostSO : ScriptableObject
{
    public string boostName;
    public BuffType buffType;
    public NerfType nerfType;
    public string boostDescription;
    public string boostEffect;
    public int buffEffectValue;
    public int nerfEffectValue;
    public int boostCost;
    //public int boostUsesLeft;

    public void BoostUsed()
    {
        //idk what goes here
    }
}
