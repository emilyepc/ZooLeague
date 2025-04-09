using UnityEngine;

[CreateAssetMenu(fileName = "CurrencySO", menuName = "Scriptable Objects/CurrencySO")]
public class CurrencySO : ScriptableObject
{
    public int coins;
    public int gems;
    public int energy;
    public int maxEnergy;
}
