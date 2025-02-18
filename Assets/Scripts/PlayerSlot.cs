using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerSlot : MonoBehaviour , IDropHandler
{
    public enum PositionType { Forward, Midfielder, Defender, Goalkeeper, Bench }
    public PositionType positionType;

    public bool spotOccupied;

    private bool sorted;

    public BenchSorter benchSorter;
    
    void Start()
    {
        benchSorter = FindObjectOfType<BenchSorter>();

        if (transform.childCount > 0)
        {
            spotOccupied = true;
        }
        else
        {
            spotOccupied = false;
        }
    }


    public void OnDrop(PointerEventData eventData)
    {
        GameObject dropped = eventData.pointerDrag;
        DraggableItem draggableItem = dropped.GetComponent<DraggableItem>();

        if (draggableItem == null) return;

        PlayerSlot oldSlot = draggableItem.parentAfterDrag.GetComponent<PlayerSlot>();
        if (oldSlot != null)
        {
            oldSlot.spotOccupied = false; //free the old slot
        }

        if (!spotOccupied)
        {
            draggableItem.parentAfterDrag = transform; //make the parent after drag this item
            draggableItem.SetPosition(this); //set the slot to this slot position type
            spotOccupied = true;

            if (oldSlot.gameObject.tag == "Bench" && sorted == false)
            {
                if (oldSlot.spotOccupied == false)
                {
                    print("trying to sort");
                    sorted = true;
                    benchSorter.Sort(); 
                }            
            }
        }
        else
        {
            sorted = false;
        }
    }
}
