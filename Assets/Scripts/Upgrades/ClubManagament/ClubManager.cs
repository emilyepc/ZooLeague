using System;
using UnityEngine;

public class ClubManager : MonoBehaviour
{
    public GameObject upgradePanel;
    public GameObject boostPanel;
    public GameObject sponsorshipPanel;

    private void Start()
    {
        upgradePanel.SetActive(true);
        boostPanel.SetActive(false);
        sponsorshipPanel.SetActive(false);
    }
}
