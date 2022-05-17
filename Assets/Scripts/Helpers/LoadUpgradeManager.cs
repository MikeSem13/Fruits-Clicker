using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadUpgradeManager : MonoBehaviour
{
    public UpgradeManager UpgradeManager;
    void Start()
    {
        LoadCurrentLevel();
    }

    public void LoadCurrentLevel()
    {
        for (int i = 0; i < UpgradeManager.Upgrades.Count; i++)
        {
            UpgradeManager.Upgrades[i].CurrentPrice = PlayerPrefs.GetInt(i + "PriceOfUpgrade");
        }
    }
}
