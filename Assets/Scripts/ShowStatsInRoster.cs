using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ShowStatsInRoster : MonoBehaviour
{
    public DraggablePlayer draggablePlayer;

    public TMP_Text playerNameText;
    public TMP_Text offenceText;
    public TMP_Text defenceText;
    public TMP_Text speedText;
    public TMP_Text formText;

    public void ShowPlayerStats()
    {
        if (draggablePlayer != null)
        {
            draggablePlayer.PasteStats(playerNameText, offenceText, defenceText, speedText, formText);
        }
        else
        {
            Debug.LogWarning("DraggablePlayer reference is missing!");
        }
    }
}
