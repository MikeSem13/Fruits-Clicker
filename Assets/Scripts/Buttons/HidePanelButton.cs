using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class HidePanelButton : MonoBehaviour
{
    public PanelManager PanelManager;

    public void DoHidePanel()
    {
        PanelManager.HideLastPanel();
    }
}
