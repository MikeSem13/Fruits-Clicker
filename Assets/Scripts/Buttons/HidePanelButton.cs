using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class HidePanelButton : MonoBehaviour
{
    public PanelManager PanelManager;

    public void HidePane()
    {
        PanelManager.HideLastPanel();
    }
    
    public void DoHidePanel()
    {
        PanelModel lastPanel = PanelManager.ListOfShowPanels[PanelManager.ListOfShowPanels.Count - 1];
        
        lastPanel.GameObjectPanel.GetComponent<Animator>().SetTrigger("Close");
        if(lastPanel.BackGround != null)lastPanel.BackGround.GetComponent<Animator>().SetTrigger("Hide");
        Invoke("HidePane", 0.09f);
    }
}
