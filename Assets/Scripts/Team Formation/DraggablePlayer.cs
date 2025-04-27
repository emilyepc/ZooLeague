using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DraggablePlayer : MonoBehaviour
{
    public MovePlayerIntoFormation movePlayerIntoFormation;
    public PlayerSO playerSo;
    public PlayerSlot currentSlot;
    public BenchSorter bench;
    public GameObject benchSpot;
    
    [HideInInspector] public Transform parentAfterDrag;
    [SerializeField] private string playerName;
    [SerializeField] private int offenceScore;
    [SerializeField] private int speedScore;
    [SerializeField] private int defenceScore;
    [SerializeField] private int currentForm;
    [SerializeField] private int maxForm;
    [SerializeField] private float formLimit;

    public float scoreMultiplier;
    private int grossTotalScore;
    [HideInInspector] public int totalScore;
    [HideInInspector] public int offenceScoreMultiplied;
    [HideInInspector] public int defenceScoreMultiplied;
    [HideInInspector] public int speedScoreMultiplied;
    
    public RosterButtons rosterButtons;
    
    private void Start()
    {
        DraggablePlayersManager.instance.SetActivePlayers(this);
    }

    void Update()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y, 100);
        
        if (offenceScore > 100) offenceScore = 100;
        else if (offenceScore < 0) offenceScore = 0;
        if (defenceScore > 100) defenceScore = 100;
        else if (defenceScore < 0) defenceScore = 0;
        if (speedScore > 100) speedScore = 100;
        else if (speedScore < 0) speedScore = 0;
        if (currentForm > maxForm) currentForm = maxForm;
        else if (currentForm < 0) currentForm = 0;
    }


    public void OnPlayerPressed()
    {
        movePlayerIntoFormation.SelectPlayer(this);
        ApplyMultiplier();
    }

    public void SetPosition(PlayerSlot slot) 
    {
        TeamScoreManager.instance.RemovePlayerFromFormation(this);
        transform.SetParent(slot.transform);
        currentSlot = slot;
        ApplyMultiplier();
        TeamScoreManager.instance.AddPlayerToFormation(this);
    }

    public void SetBenchPosition()
    {
        transform.SetParent(benchSpot.transform);
        currentSlot = null;
        ApplyMultiplier();
        TeamScoreManager.instance.RemovePlayerFromFormation(this);
    }

    public void SetInteractable(bool interactable)
    {
        var button = GetComponent<Button>();
        button.interactable = interactable;
        
        var image = GetComponent<Image>();
        image.raycastTarget = interactable;
    }

    private void ApplyMultiplier()
    {
        //update score from SO
        offenceScore = playerSo.offenceP;
        defenceScore = playerSo.defenceP;
        speedScore = playerSo.speedP;
        
        if (currentSlot != null) //if they are on the field formation
        {
            //find which stat needs to be upgraded
            float baseScore = 0;
            if (currentSlot.positionType == PlayerSlot.PositionType.Forward) baseScore = offenceScore;
            if (currentSlot.positionType == PlayerSlot.PositionType.Midfielder) baseScore = speedScore;
            if (currentSlot.positionType == PlayerSlot.PositionType.Defender) baseScore = defenceScore;

            //upgrade the stat chosen above
            scoreMultiplier = (0.01f * baseScore) + 0.8f;
            int boostedStat = Mathf.RoundToInt(baseScore * scoreMultiplier);

            //apply to the right stat - if not the right stat, then just don't change
            offenceScoreMultiplied = (currentSlot.positionType == PlayerSlot.PositionType.Forward)
                ? boostedStat
                : offenceScore;
            speedScoreMultiplied = (currentSlot.positionType == PlayerSlot.PositionType.Midfielder)
                ? boostedStat
                : speedScore;
            defenceScoreMultiplied = (currentSlot.positionType == PlayerSlot.PositionType.Defender)
                ? boostedStat
                : defenceScore;

            //add up the total (before form impacts it)
            grossTotalScore = offenceScoreMultiplied + speedScoreMultiplied + defenceScoreMultiplied;

            //find form multiplier and apply it
            formLimit = (maxForm > 0) ? (float)currentForm / maxForm : 1f;
            totalScore = Mathf.RoundToInt(grossTotalScore * formLimit);
        }
        else
        {
            grossTotalScore = offenceScore + defenceScore + speedScore;

            formLimit = (maxForm > 0) ? (float)currentForm / maxForm : 1f;
            totalScore = Mathf.RoundToInt(grossTotalScore * formLimit);
        }
        
        //update the ui!
        PlayerStatsInFormation.instance.ShowStats(this, playerSo, rosterButtons.model3D);
    }

    
    // BELOW IS FOR UPGRADES IN THE SHOP AND POPUPS 
    
    public void AddToDefenceScore(int amount)
    {
        playerSo.defenceP += amount;
    }

    public void AddToOffenceScore(int amount)
    {
        playerSo.offenceP += amount;
    }
    public void AddOverallScore(int amount)
    {
        playerSo.defenceP += amount;
        playerSo.offenceP += amount;
        playerSo.speedP += amount;
    }
    public void AddToSpeedScore(int amount)
    {
        playerSo.speedP += amount;
    }

    public void AddToFormScore(int amount)
    {
        playerSo.formP += amount;

        if (playerSo.formP > playerSo.maxFormP)
        {
            playerSo.formP = playerSo.maxFormP;
        }
    }

    public void AddToFormMaxScore(int amount)
    {
        playerSo.maxFormP += amount;
    }



    public void PasteStats(TMP_Text playerNameText, TMP_Text offenceText, TMP_Text defenceText, TMP_Text speedText, TMP_Text formText)
    {
        if (playerNameText != null) playerNameText.text = "Name: " + playerSo.playerName;
        if (offenceText != null) offenceText.text = "Offence: " + playerSo.offenceP;
        if (defenceText != null) defenceText.text = "Defence: " + playerSo.defenceP;
        if (speedText != null) speedText.text = "Speed: " + playerSo.speedP;
        if (formText != null) formText.text = "Form: " + playerSo.formP + " / " + playerSo.maxFormP;
    }

}