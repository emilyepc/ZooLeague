using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class PopupTriggerSystem : MonoBehaviour
{
    public PopupEventsManager popupEventsManager;
    public MatchSimulation matchSimulation;
    public PlayerSO popupPlayerSo;
    
    public PopupSO[] popups;
    
    public GameObject teamPopupPanel;
    public GameObject playerPopupPanel;

    private DraggablePlayer selectedDraggablePlayer;
    private float timer;
    [SerializeField] private float eventCheckInterval;

    private GameObject lastModel;
    
    
    [Header("Text Values")]
    public TMP_Text offenceText;
    public TMP_Text defenceText;
    public TMP_Text speedText;
    public TMP_Text formText;
    public TMP_Text formMaxText;

    [Header("Sliders")]
    public Slider offenceSlider;
    public Slider defenceSlider;
    public Slider speedSlider;
    public Slider formSlider;

    private void Start()
    {
        timer = 0f;
        teamPopupPanel.SetActive(false);
        playerPopupPanel.SetActive(false);
        eventCheckInterval = Random.Range(10f, 20f);
    }

    private void Update()
    {
        if (matchSimulation.matchOngoing && !matchSimulation.gamePaused)
        {
            if (timer >= eventCheckInterval)
            {
                timer = 0;
                TriggerPopupEvent();
                eventCheckInterval = Random.Range(10f, 20f);
            }
            timer += Time.deltaTime;
        }
    }
    
    private void TriggerPopupEvent()
    {
        matchSimulation.gamePaused = true;

        //has a specific player got low form?
        PlayerSO tiredPlayer = (from draggable in TeamScoreManager.instance.playersInFormationList 
            where draggable.playerSo.formP < 5 
            select draggable.playerSo).FirstOrDefault();

        popupPlayerSo = tiredPlayer;
        
        if (tiredPlayer != null)
        {
            selectedDraggablePlayer = TeamScoreManager.instance.playersInFormationList
                .FirstOrDefault(dp => dp.playerSo == tiredPlayer);
            
            popupEventsManager.player = tiredPlayer;
            
            foreach (var popup in popups)
            {
                if (popup.name == "FatiguePopup")
                {
                    ShowCorrectPanel(popup);
                    popupEventsManager.SetupPopup(popup);
                    return;
                }
            }
        }
        
        List<DraggablePlayer> availablePlayers = TeamScoreManager.instance.playersInFormationList.Where(player => !player.playerSo.hasBeenInPopup).ToList();
        
        //choosing which player is effected
        int randomIndexPlayer = Random.Range(0, availablePlayers.Count);
        selectedDraggablePlayer = availablePlayers[randomIndexPlayer];
        popupEventsManager.player = selectedDraggablePlayer.playerSo;
        popupPlayerSo = selectedDraggablePlayer.playerSo;
        
        //choosing which popup to do!
        int randomIndexPopup = Random.Range(0, popups.Length);
        
        ShowCorrectPanel(popups[randomIndexPopup]);
        
        popupEventsManager.SetupPopup(popups[randomIndexPopup]);
        selectedDraggablePlayer.playerSo.hasBeenInPopup = true;
    }
    
    void ShowCorrectPanel(PopupSO popup)
    {
        if (popup.category == Category.Player)
        {
            playerPopupPanel.SetActive(true);
            ShowStats();
        }
        else if (popup.category == Category.Team)
            teamPopupPanel.SetActive(true);
    }

    private void ShowStats()
    {
        offenceSlider.value = popupPlayerSo.offenceP;
        defenceSlider.value = popupPlayerSo.defenceP;
        speedSlider.value = popupPlayerSo.speedP;
        formSlider.value = popupPlayerSo.formP;
        formSlider.maxValue = popupPlayerSo.maxFormP;

        offenceText.text = popupPlayerSo.offenceP.ToString();
        defenceText.text = popupPlayerSo.defenceP.ToString();
        speedText.text = popupPlayerSo.speedP.ToString();
        formText.text = popupPlayerSo.formP.ToString();
        formMaxText.text = popupPlayerSo.maxFormP.ToString();
        
        
        selectedDraggablePlayer.rosterButtons.model3D.SetActive(true);
        print(selectedDraggablePlayer.rosterButtons.model3D.name);
    }
}
