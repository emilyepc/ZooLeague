using UnityEngine;

public class ShowStatsInRoster : MonoBehaviour
{
    public RosterStatUpdating rosterStatUpdating;
    
    [SerializeField] private string playerName;
    [SerializeField] private int offenceScore;
    [SerializeField] private int speedScore;
    [SerializeField] private int defenceScore;
    [SerializeField] private int currentForm;
    [SerializeField] private int maxForm;

    [SerializeField] private DraggablePlayer correspondingPlayer;

    public void UpdateStatText()
    {
        rosterStatUpdating.ShowStats(playerName, offenceScore, defenceScore, speedScore, currentForm, maxForm);
    }
}
