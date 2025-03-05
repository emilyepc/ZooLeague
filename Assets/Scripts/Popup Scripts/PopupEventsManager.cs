using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class PopupEventsManager : MonoBehaviour
{
    
    
    public void InjuryPopup()
    {
        
    }

    public void YellowCardPopup()
    {
        //a player got a yellow card for playing aggressively
        //tell them off? or encourage behaviour?
    }

    public void RedCardPopup()
    {
        
    }

    public void FakeInjuryPopup()
    {
        //a player is faking an injury: 
        //encourage it? or tell them to stop?
    }

    public void FatiguePopup()
    {
        //form getting low
        //take them off? or moral boost? (small form boost)
    }
    
    public void HalftimePopup()
    {
        //maybe a couple popups itself, or
        //give moral boost? or change formation?
    }
}
