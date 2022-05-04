
using UnityEngine;

public class ShowPanelButton : MonoBehaviour
{
    public PanelManager PanelManager;
    public string PanelId;

    public void DoShowPanel()
    {
        PanelManager.ShowPanel(PanelId);
    }
}
