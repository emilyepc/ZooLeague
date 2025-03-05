using UnityEngine;

public class PopupTriggerSystem : MonoBehaviour
{
    public PopupEventsManager popupEventsManager;
    
    private float timer;
    [SerializeField] float eventCheckInterval;
    
    private void Update()
    {
        timer += Time.deltaTime;
        if (timer >= eventCheckInterval)
        {
            timer = 0;
            TriggerPopupEvent();
            TimerReset();
        }
    }

    private void TimerReset()
    {
        
    }

    private void TriggerPopupEvent()
    {
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
