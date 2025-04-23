using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DraggablePlayersManager : MonoBehaviour
{
    public static DraggablePlayersManager instance;
    public List<DraggablePlayer> allPlayers = new List<DraggablePlayer>();
    public GameObject bench;
    public GameObject benchUI;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        var button = GetComponent<Button>();
        button.interactable = false;
        benchUI.SetActive(false);
    }

    public void SetActivePlayers(DraggablePlayer player)
    {
        if (!allPlayers.Contains(player)) allPlayers.Add(player);
    }

    public void EnableOnePlayer(DraggablePlayer selectedPlayer)
    {
        foreach (var player in allPlayers)
        {
            bool isSelected = player == selectedPlayer;
            player.SetInteractable(isSelected);
        }
        
        var button = GetComponent<Button>();
        button.interactable = true;
        benchUI.SetActive(true);
    }
    
    public void EnableAllPlayers()
    {
        foreach (var player in allPlayers)
        {
            player.SetInteractable(true);
        }
        
        var button = GetComponent<Button>();
        button.interactable = false;
        benchUI.SetActive(false);
    }
}
