using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadAndSaveUpgradeManager : MonoBehaviour
{
    public UpgradeManager UpgradeManager;
    void Start()
    {
        LoadCurrentLevel();
    }

    public void SaveCurrentLevel()
    {
        for (int i = 0; i < UpgradeManager.Upgrades.Count; i++)
        {
           PlayerPrefs.SetInt(i + "PriceOfUpgrade", UpgradeManager.Upgrades[i].CurrentPrice);
        }
    }
    
    private void LoadCurrentLevel()
    {
        for (int i = 0; i < UpgradeManager.Upgrades.Count; i++)
        {
            UpgradeManager.Upgrades[i].CurrentPrice = PlayerPrefs.GetInt(i + "PriceOfUpgrade");
        }
    }
}
