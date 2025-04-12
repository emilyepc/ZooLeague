using UnityEngine;

[CreateAssetMenu(fileName = "PlayerSO", menuName = "Scriptable Objects/PlayerSO")]

[System.Serializable]
public class PlayerSO : ScriptableObject
{
    public string playerName;
    public string playerPosition;
    public int offenceP;
    public int defenceP;
    public int speedP;
    public int formP;
    public int maxformP;
}
