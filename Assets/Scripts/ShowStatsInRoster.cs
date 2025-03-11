using UnityEngine;

public class ShowStatsInRoster : MonoBehaviour
{
    public DraggablePlayer draggablePlayer;

    [SerializeField] private string playerName;
    [SerializeField] private int offenceScore;
    [SerializeField] private int speedScore;
    [SerializeField] private int defenceScore;
    [SerializeField] private int currentForm;
    [SerializeField] private int maxForm;

    [SerializeField] private DraggablePlayer correspondingPlayer;

    void Update()
    {

            draggablePlayer.PasteStats();
        
    }
}