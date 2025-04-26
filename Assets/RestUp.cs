using UnityEngine;
using TMPro;

public class RestUp : MonoBehaviour
{
    public float timerDuration = 5f;
    private float currentTime;
    private bool isTimerRunning = false;

    public PlayerSO playerSO;

    public DraggablePlayer player;
    public enum BoostType { Offence, Form}
    public BoostType boost;

    public TextMeshProUGUI timerText;
    public GameObject objectToToggle;
    public bool isResting;
    
    
    void Update()

    {
        if (isResting == true)
        {
            if (!isTimerRunning)
            {
                StartTimer();
            }

       

            if (isTimerRunning)
            {
                currentTime -= Time.deltaTime;
                timerText.text = Mathf.Ceil(currentTime).ToString();

                if (currentTime <= 0f)
                {
                    EndTimer();
                }
            }
        }
    }

    public void restdafukup()
    {
         isResting = true;
         playerSO.formP += playerSO.maxformP;

    }

    public void ChooseBoost(int value)
    {
        
        if (boost.ToString() == "Form") player.AddToFormScore(value);
        print("Goofysyelll");

    }

    public void Changethedamnplayerdammit(PlayerSO currentplayer)
    {
        playerSO = currentplayer;
        print("Goofysyelll");


    }

    void StartTimer()
    {
        isTimerRunning = true;
        currentTime = timerDuration;
        objectToToggle.SetActive(true);
    }

    void EndTimer()
    {
        isTimerRunning = false;
        timerText.text = "0";
        objectToToggle.SetActive(false);
        isResting = false;
    }
}

