using UnityEngine;

public class PlayerSlot : MonoBehaviour
{
    public enum PositionType { Forward, Midfielder, Defender, Goalkeeper, Bench }
    public PositionType positionType;

    public bool spotOccupied;

    public MovePlayerIntoFormation movePlayerIntoFormation;
    
    
    //when u click on this button...
    public void SpotSelected()
    {
        spotOccupied = transform.childCount > 0;

        if (!spotOccupied)
        {
            movePlayerIntoFormation.SelectSlot(this);
            spotOccupied = true;
            DraggablePlayersManager.instance.EnableAllPlayers();
        }
        else
        {
            print("spot occupied!");
        }
    }
    
}