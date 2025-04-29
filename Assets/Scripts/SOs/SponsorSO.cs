using UnityEngine;

[CreateAssetMenu(fileName = "SponsorSO", menuName = "Scriptable Objects/SponsorSO")]
public class SponsorSO : ScriptableObject
{
    public string sponsorName;
    public Sprite sponsorIcon;
    public int sponsorRelationship;

    public bool currentSponsor;
    
    public string sponsorDescription;

    public int currentPayout;
    
    public int minPayout;
    public int maxPayout;

    public int gemPayout;

    public int payoutAddon;

    public void CalculatePayout()
    {
        currentPayout = (int)(minPayout + ((sponsorRelationship - 20) / 80f) * (maxPayout - minPayout));
    }
}
