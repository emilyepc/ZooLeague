using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Random = UnityEngine.Random;

public class PopupTriggerSystem : MonoBehaviour
{
    public PopupEventsManager popupEventsManager;
    public MatchSimulation matchSimulation;
    
    public PopupSO[] popups;
    
    public GameObject popupPanel;
    
    private float timer;
    [SerializeField] private float eventCheckInterval;

    private void Start()
    {
        timer = 0f;
        popupPanel.SetActive(false);
        eventCheckInterval = Random.Range(10f, 20f);
    }

    private void Update()
    {
        if (matchSimulation.matchOngoing && !matchSimulation.gamePaused)
        {
            if (timer >= eventCheckInterval)
            {
                timer = 0;
                popupPanel.SetActive(true);
                TriggerPopupEvent();
                eventCheckInterval = Random.Range(10f, 20f);
            }
            timer += Time.deltaTime;
        }
    }
    
    private void TriggerPopupEvent()
    {
        matchSimulation.gamePaused = true;
        popupPanel.SetActive(true);

        //has a specific player got low form?
        PlayerSO tiredPlayer = (from draggable in TeamScoreManager.instance.playersInFormationList 
            where draggable.playerSo.formP < 5 
            select draggable.playerSo).FirstOrDefault();
        
        if (tiredPlayer != null)
        {
            popupEventsManager.player = tiredPlayer;
            
            foreach (var popup in popups)
            {
                if (popup.name == "FatiguePopup")
                {
                    popupEventsManager.SetupPopup(popup);
                    return;
                }
            }
        }
        
        List<DraggablePlayer> availablePlayers = TeamScoreManager.instance.playersInFormationList.Where(player => !player.playerSo.hasBeenInPopup).ToList();
        
        //choosing which player is effected
        int randomIndexPlayer = Random.Range(0, availablePlayers.Count);
        DraggablePlayer selectedDraggablePlayer = availablePlayers[randomIndexPlayer];
        popupEventsManager.player = selectedDraggablePlayer.playerSo;
        
        //choosing which popup to do!
        int randomIndexPopup = Random.Range(0, popups.Length);
        
        popupEventsManager.SetupPopup(popups[randomIndexPopup]);
        selectedDraggablePlayer.playerSo.hasBeenInPopup = true;
    }
}
