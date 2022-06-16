using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PanelManager : Singleton<PanelManager>
{
    public List<PanelModel> PanelModels = new List<PanelModel>();

    private List<PanelModel> _listOfShowPanels = new List<PanelModel>();

    public List<PanelModel> ListOfShowPanels { get { return _listOfShowPanels; } }
        
    public void ShowPanel(string panelId)
    {
        PanelModel panelModel = PanelModels.FirstOrDefault(model => model.PanelId == panelId);

        if (panelModel != null)
        {
            panelModel.GameObjectPanel.SetActive(true);
            panelModel.Animator.SetTrigger("Apear");
            if(panelModel.BackGround != null) panelModel.BackGround.SetActive(true);
            panelModel.IsShowing = true;

            ListOfShowPanels.Add(new PanelModel()
            {
                PanelId = panelId,
                GameObjectPanel = panelModel.GameObjectPanel,
                BackGround = panelModel.BackGround,
                IsShowing = panelModel.IsShowing
            });
        }
    }

    public void HideLastPanel()
    {
        PanelModel lastPanel = ListOfShowPanels[ListOfShowPanels.Count - 1];
        
        lastPanel.GameObjectPanel.SetActive(false);
        if(lastPanel.BackGround != null) lastPanel.BackGround.SetActive(false);
        lastPanel.IsShowing = false;
        
        ListOfShowPanels.Remove(lastPanel);
    }
}
