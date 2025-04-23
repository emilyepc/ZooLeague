using UnityEngine;

public class MovePlayerIntoFormation : MonoBehaviour
{
    public PlayerSlot playerSlot;
    public DraggablePlayer selectedPlayer;
    
    public void SelectPlayer(DraggablePlayer player)
    {
        if (selectedPlayer == player)
        {
            DeselectPlayer();
        }
        else
        {
            selectedPlayer = player;
            DraggablePlayersManager.instance.EnableOnePlayer(selectedPlayer);
        }
    }
    
    public void SelectSlot(PlayerSlot slot)
    {
        if (selectedPlayer != null)
        {
            selectedPlayer.SetPosition(slot);
            DeselectPlayer();
        }
    }

    public void SelectBench()
    {
        if (selectedPlayer != null)
        {
            selectedPlayer.SetBenchPosition();
            DeselectPlayer();
        }
    }

    private void DeselectPlayer()
    {
        DraggablePlayersManager.instance.EnableAllPlayers();
        selectedPlayer = null;
    }
}
