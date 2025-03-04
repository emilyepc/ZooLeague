using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems; 

public class DraggablePlayer : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public RawImage rawImage;
    [HideInInspector] public Transform parentAfterDrag;
    public PlayerSlot playerSlot;

    [SerializeField] private string playerName;
    [SerializeField] private int offenceScore;
    [SerializeField] private int speedScore;
    [SerializeField] private int defenceScore;

    private float scoreMultiplier;
    public int totalScore;
    public int offenceScoreMultiplied;
    public int defenceScoreMultiplied;
 
    void Update()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y, 100);
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        parentAfterDrag = transform.parent;
        transform.SetParent(transform.root);
        transform.SetAsLastSibling();
        rawImage.raycastTarget = false;

        CalculateTotalScore();
        PlayerStatsInFormation.instance.ShowStats(playerName, offenceScore, defenceScore, speedScore, totalScore);
    }

    public void CalculateTotalScore()
    {
        totalScore = offenceScore + defenceScore + speedScore;
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

        totalScore =
        (playerSlot.positionType == PlayerSlot.PositionType.Forward ? Mathf.RoundToInt(finalScore) : offenceScore) +
        (playerSlot.positionType == PlayerSlot.PositionType.Defender ? Mathf.RoundToInt(finalScore) : defenceScore) +
        (playerSlot.positionType == PlayerSlot.PositionType.Midfielder ? Mathf.RoundToInt(finalScore) : speedScore);

        PlayerStatsInFormation.instance.ShowStats(playerName,
            playerSlot.positionType == PlayerSlot.PositionType.Forward ? Mathf.RoundToInt(finalScore) : offenceScore,
            playerSlot.positionType == PlayerSlot.PositionType.Defender ? Mathf.RoundToInt(finalScore) : defenceScore,
            playerSlot.positionType == PlayerSlot.PositionType.Midfielder ? Mathf.RoundToInt(finalScore) : speedScore,
            totalScore);
        // conditional ? -->  X = (condition) ? (value if true) : (value if false);
    }
}
