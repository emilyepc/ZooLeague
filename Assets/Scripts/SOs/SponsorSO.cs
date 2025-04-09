using UnityEngine;

[CreateAssetMenu(fileName = "SponsorSO", menuName = "Scriptable Objects/SponsorSO")]
public class SponsorSO : ScriptableObject
{
    public string sponsorName;
    public Sprite sponsorIcon;
    public int sponsorRelationship;

    public bool currentSponsor;
    
    public int sponsorPayment;
}
