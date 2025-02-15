using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems; 

public class DraggableItem : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public RawImage rawImage;
    [HideInInspector] public Transform parentAfterDrag;

    public PlayerSlot playerSlot;

    //in future, these are pulled from animal upgrade script?? i guess? or maybe not, idk
    [SerializeField] private string playerName;
    [SerializeField] private int offenceScore;
    [SerializeField] private int speedScore;
    [SerializeField] private int defenceScore;

    private float scoreMultiplier;
    public int totalScore;

    public int offenceScoreMultiplied;
    public int defenceScoreMultiplied;
 
    void Start()
    {
        
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        //print("begin drag");
        parentAfterDrag = transform.parent;
        transform.SetParent(transform.root);
        transform.SetAsLastSibling();
        rawImage.raycastTarget = false;

        totalScore = offenceScore + defenceScore + speedScore;
        
        PlayerStatsInFormation.instance.ShowStats(playerName, offenceScore, defenceScore, speedScore, totalScore);

    }

    public void OnDrag(PointerEventData eventData)
    {
        //print("dragging");
        transform.position = Input.mousePosition;

    }

    public void OnEndDrag(PointerEventData eventData)
    {
        //print("end drag");
        transform.SetParent(parentAfterDrag);
        rawImage.raycastTarget = true;
    }

    public void SetPosition(PlayerSlot slot)
    {
        TeamScoreManager.instance.RemovePlayerFromFormation(this); //remove score from team score

        playerSlot = slot;
        ApplyMultiplier();

        if (parentAfterDrag.tag != "Bench")
        {
            TeamScoreManager.instance.AddPlayerToFormation(this); //add new score
        }
    }

    private void ApplyMultiplier()
    {
        float baseScore = 0;

        switch (playerSlot.positionType)
        {
            case PlayerSlot.PositionType.Forward:
                baseScore = offenceScore;
                break;
            case PlayerSlot.PositionType.Midfielder:
                baseScore = speedScore;
                break;
            case PlayerSlot.PositionType.Defender:
                baseScore = defenceScore;
                break;
        }

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
        // conditional ?:    X = (condition) ? (value if true) : (value if false);
    }
}
