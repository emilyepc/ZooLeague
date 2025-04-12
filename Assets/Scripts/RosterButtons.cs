using UnityEngine;

public class RosterButtons : MonoBehaviour
{

    public ManagerRoster managerRoster;
    public PlayerSO playerSO;
    public GameObject model3D;

    public void ButtonPressed() 
    {
        managerRoster.ChangePlayer(playerSO, model3D);

    
    }



}
