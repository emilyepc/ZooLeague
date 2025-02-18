using UnityEngine;
using System.Collections.Generic;

public class BenchSorter : MonoBehaviour
{
    public List<PlayerSlot> benchSlots = new List<PlayerSlot>();

    private void Start()
    {
        // Find all PlayerSlot components tagged as "Bench"
        PlayerSlot[] allSlots = FindObjectsOfType<PlayerSlot>();
        foreach (PlayerSlot slot in allSlots)
        {
            if (slot.positionType == PlayerSlot.PositionType.Bench)
            {
                benchSlots.Add(slot);
            }
        }
    }

    public void Sort()
    {
        foreach (PlayerSlot slot in benchSlots)
        {
            if (!slot.spotOccupied)
            {
                slot.transform.SetAsLastSibling(); // Move empty slots to the end
            }
        }
    }
}
