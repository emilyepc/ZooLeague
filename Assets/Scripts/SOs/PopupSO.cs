using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

[CreateAssetMenu(fileName = "PopupSO", menuName = "Scriptable Objects/PopupSO")]
public class PopupSO : ScriptableObject
{
    public bool effectsOnePlayer;
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
