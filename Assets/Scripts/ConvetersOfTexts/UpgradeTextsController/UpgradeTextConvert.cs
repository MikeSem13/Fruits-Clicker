using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeTextConvert : MonoBehaviour
{
  [SerializeField] private UpgradeManager UpgradeManager;

  private void Update()
  {
    for (int i = 0; i < UpgradeManager.Upgrades.Count; i++)
    {
      ConvertTextsOfUpgrades(UpgradeManager.Upgrades[i].NameOfUpgrade); 
    }
  }

  public void ConvertTextsOfUpgrades(string NameOfUpgrade)
  {
    UpgradeModel upgradeModel = UpgradeManager.Upgrades.FirstOrDefault(model => model.NameOfUpgrade == NameOfUpgrade);

    for (int i = 0; i < upgradeModel.Prices.Count; i++)
    {
      ConvertValuesOfTexts(upgradeModel.Prices[i].Price, upgradeModel.Prices[i - 1].Price, upgradeModel.TextOfPrice, upgradeModel.Prices[i].NumberOfValuePrice, upgradeModel.SybwolsOfValue[upgradeModel.Prices[upgradeModel.CurrentPrice].NumberOfValuePrice]);
    }
    
    for (int i = 0; i < upgradeModel.Multis.Count; i++)
    {
      ConvertValuesOfTexts(upgradeModel.Multis[i].Multi, upgradeModel.Multis[i - 1].Multi, upgradeModel.TextOfMulti, upgradeModel.Multis[i].NumberOfValueMulti, upgradeModel.SybwolsOfValue[upgradeModel.Multis[upgradeModel.CurrentPrice].NumberOfValueMulti]);
    }
  }

  public void ConvertValuesOfTexts(float price,float OldPrice,Text text, int numberOfValue, string SybwolOfText)
  {
    if (price == 0)
    {
      text.text = price + SybwolOfText;  
    }
               
    if (price >= 0 && numberOfValue > 0 && OldPrice / 100 >= 1)
    {
      text.text = price + "." + Mathf.Floor(OldPrice / 100) + SybwolOfText;
    }
               
    if (price >= 0 && numberOfValue > 0 && OldPrice / 100 < 1)
    {
      text.text = price + SybwolOfText;
    }
               
    if (price >= 10)
    {
      text.text = price + SybwolOfText;
    }
  }
}
