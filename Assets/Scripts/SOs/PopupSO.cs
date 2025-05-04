using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

[CreateAssetMenu(fileName = "PopupSO", menuName = "Scriptable Objects/PopupSO")]
public class PopupSO : ScriptableObject
{
    public Category category;
    public string popupText;
    
    [Header("Choice One")]
    public string choiceOneText;
    public string choiceOneEffectText;
    public PopupActions choiceOneAction;
    
    [Header("Choice Two")]
    public string choiceTwoText;
    public string choiceTwoEffectText;
    public PopupActions choiceTwoAction;
}

[System.Serializable]
public class PopupActions
{
    public List<PopupEffect> popupEffects = new List<PopupEffect>();
    public string effectText;
    public bool openCompletePanel = true;
}

[System.Serializable]
public class PopupEffect
{ 
    public PopupActionType actionType;
    public int effectValue;
}

public enum PopupActionType
{
    None,
    UpdateTeamFormation,
    UpdateDefence,
    UpdateOffence,
    UpdateSpeed,   
    UpdateTeamForm,
    UpdatePlayerForm,
    UpdateTeamScore
}
public enum Category { Player, Team, Sponsor, Crowd}

