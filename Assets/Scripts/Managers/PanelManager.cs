using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PanelManager : Singleton<PanelManager>
{
    public List<PanelModel> PanelModels = new List<PanelModel>();

    private List<PanelModel> ListOfShowPanels = new List<PanelModel>();
    public void ShowPanel(string panelId)
    {
        PanelModel panelModel = PanelModels.FirstOrDefault(model => model.PanelId == panelId);

        if (panelModel != null)
        {
            panelModel.GameObjectPanel.SetActive(true);
            panelModel.Animator.SetTrigger("Apear");
            panelModel.BackGround.SetActive(true);
            panelModel.BackGround.GetComponent<Animator>().SetTrigger("Apear");
            panelModel.IsShowing = true;

            ListOfShowPanels.Add(new PanelModel()
            {
                PanelId = panelId,
                GameObjectPanel = gameObject,
                BackGround = gameObject,
                IsShowing = isActiveAndEnabled
            });
        }
    }

    public void HideLastPanel()
    {
        PanelModel lastPanel = ListOfShowPanels[ListOfShowPanels.Count - 1];

        Debug.Log("asdas");
        
        lastPanel.GameObjectPanel.SetActive(false);
        lastPanel.BackGround.SetActive(false);
        lastPanel.IsShowing = false;
    }
}
