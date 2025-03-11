using UnityEngine;
using Random = UnityEngine.Random;

public class PopupTriggerSystem : MonoBehaviour
{
    public PopupEventsManager popupEventsManager;
    public MatchSimulation matchSimulation;
    
    public GameObject popupPanel;
    
    private float timer;
    [SerializeField] float eventCheckInterval;

    private void Start()
    {
        TimerReset();
        popupPanel.SetActive(false);
    }

    private void Update()
    {
        if (matchSimulation.matchOngoing && !matchSimulation.gamePaused)
        {
            timer += Time.deltaTime;
            if (timer >= eventCheckInterval)
            {
                timer = 0;
                popupPanel.SetActive(true);
                TriggerPopupEvent();
                TimerReset();
            }
        }
    }

    private void TimerReset()
    {
        timer = Random.Range(10f, eventCheckInterval);
    }

    private void TriggerPopupEvent()
    {
        matchSimulation.gamePaused = true;
        
        int popupChance = Random.Range(0, 4);

        if (popupChance == 0)
            popupEventsManager.InjuryPopup();
        else if (popupChance == 1)
            popupEventsManager.YellowCardPopup();
        else if (popupChance == 2)
            popupEventsManager.FakeInjuryPopup();
        else if (popupChance == 3)
            popupEventsManager.FatiguePopup();
        else if (popupChance == 4)
            popupEventsManager.RedCardPopup();
    }
}
