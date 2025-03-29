using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;

public class DraggablePlayer : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public RawImage rawImage;
    [HideInInspector] public Transform parentAfterDrag;
    public PlayerSlot playerSlot;

    [SerializeField] private string playerName;
    [SerializeField] private int offenceScore;
    [SerializeField] private int speedScore;
    [SerializeField] private int defenceScore;
    [SerializeField] private int currentForm;
    [SerializeField] private int maxForm;
    private float formLimit;

    private float scoreMultiplier;
    private int grossTotalScore;
    [HideInInspector] public int totalScore;
    [HideInInspector] public int offenceScoreMultiplied;
    [HideInInspector] public int defenceScoreMultiplied;

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

    public void OnBeginDrag(PointerEventData eventData)
    {
        parentAfterDrag = transform.parent;
        transform.SetParent(transform.root);
        transform.SetAsLastSibling();
        rawImage.raycastTarget = false;

        CalculateTotalScore();
        PlayerStatsInFormation.instance.ShowStats(playerName, offenceScore, defenceScore, speedScore, totalScore, currentForm, maxForm);
        //form bar
    }

    private void CalculateTotalScore()
    {
        totalScore = offenceScore + defenceScore + speedScore;

        if (currentForm != 0 && maxForm != 0)
            formLimit = (float)currentForm / maxForm;

        totalScore = Mathf.RoundToInt(totalScore * formLimit);
    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = Input.mousePosition;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        transform.SetParent(parentAfterDrag);
        rawImage.raycastTarget = true;
    }

    public void SetPosition(PlayerSlot slot)
    {
        TeamScoreManager.instance.RemovePlayerFromFormation(this); //remove score from team score
        playerSlot = slot;
        ApplyMultiplier();
        TeamScoreManager.instance.AddPlayerToFormation(this); //add new score

    }

    private void ApplyMultiplier()
    {
        float baseScore = 0;

        if (playerSlot.positionType == PlayerSlot.PositionType.Forward) baseScore = offenceScore;
        if (playerSlot.positionType == PlayerSlot.PositionType.Midfielder) baseScore = speedScore;
        if (playerSlot.positionType == PlayerSlot.PositionType.Defender) baseScore = defenceScore;

        scoreMultiplier = (0.01f * baseScore) + 0.8f;
        float finalScore = baseScore * scoreMultiplier;

        offenceScoreMultiplied = Mathf.RoundToInt(offenceScore * scoreMultiplier);
        defenceScoreMultiplied = Mathf.RoundToInt(defenceScore * scoreMultiplier);

        grossTotalScore =
        (playerSlot.positionType == PlayerSlot.PositionType.Forward ? Mathf.RoundToInt(finalScore) : offenceScore) +
        (playerSlot.positionType == PlayerSlot.PositionType.Defender ? Mathf.RoundToInt(finalScore) : defenceScore) +
        (playerSlot.positionType == PlayerSlot.PositionType.Midfielder ? Mathf.RoundToInt(finalScore) : speedScore);

        if (currentForm != 0 && maxForm != 0)
            formLimit = (float)currentForm / maxForm;

        totalScore = Mathf.RoundToInt(grossTotalScore * formLimit);

        PlayerStatsInFormation.instance.ShowStats(playerName,
            playerSlot.positionType == PlayerSlot.PositionType.Forward ? Mathf.RoundToInt(finalScore) : offenceScore,
            playerSlot.positionType == PlayerSlot.PositionType.Defender ? Mathf.RoundToInt(finalScore) : defenceScore,
            playerSlot.positionType == PlayerSlot.PositionType.Midfielder ? Mathf.RoundToInt(finalScore) : speedScore,
            totalScore, currentForm, maxForm);
        // conditional ? -->  X = (condition) ? (value if true) : (value if false);
    }

    public void AddToDefenceScore(int amount)
    {
        defenceScore += amount;
    }

    public void AddToOffenceScore(int amount)
    {
        offenceScore += amount;
    }
    public void AddOverallScore(int amount)
    {
        defenceScore += amount;
        offenceScore += amount;
        speedScore += amount;
    }
    public void AddToSpeedScore(int amount)
    {
        speedScore += amount;
    }

    public void AddToFormScore(int amount)
    {
        currentForm += amount;

        if (currentForm > maxForm)
        {
            currentForm = maxForm;
        }
    }

    public void AddToFormMaxScore(int amount)
    {
        maxForm += amount;

    }



    public void PasteStats(TMP_Text playerNameText, TMP_Text offenceText, TMP_Text defenceText, TMP_Text speedText, TMP_Text formText)
    {
        if (playerNameText != null) playerNameText.text = "Name: " + playerName;
        if (offenceText != null) offenceText.text = "Offence: " + offenceScore.ToString();
        if (defenceText != null) defenceText.text = "Defence: " + defenceScore.ToString();
        if (speedText != null) speedText.text = "Speed: " + speedScore.ToString();
        if (formText != null) formText.text = "Form: " + currentForm + " / " + maxForm;
    }

}