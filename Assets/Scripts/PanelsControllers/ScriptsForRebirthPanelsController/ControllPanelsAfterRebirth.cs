using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllPanelsAfterRebirth : MonoBehaviour
{
    // Needed Panles
    public GameObject RebirthPanel;
    public GameObject BlackBackGround;
    
    public void HidePenelsAfterRebirth()
    {
        RebirthPanel.SetActive(false);
        BlackBackGround.SetActive(false);
    }

    // Method to Hide Rebirth panels Later
    public void HidePanelsInSpareTime()
    {
        Invoke("HidePenelsAfterRebirth", 0.02f);
    }
}
