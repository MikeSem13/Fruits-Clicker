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

    if (upgradeModel.CurrentPrice < upgradeModel.Prices.Count)
    {
      ConvertValuesOfPriceTexts(upgradeModel.Prices[upgradeModel.CurrentPrice].Price, upgradeModel.Button.TextOfPrice, UpgradeManager.SybwolsOfValue[upgradeModel.Prices[upgradeModel.CurrentPrice].NumberOfValuePrice]);
      ConvertValuesOfMultiTexts(upgradeModel.Multis[upgradeModel.CurrentPrice].Multi, upgradeModel.TextOfMulti, UpgradeManager.SybwolsOfValue[upgradeModel.Multis[upgradeModel.CurrentPrice].NumberOfValueMulti]); 
      ControllFontSizeAndPositionOfPriceText(upgradeModel.Button.TextOfPrice, upgradeModel.Prices[upgradeModel.CurrentPrice].Price, UpgradeManager.SybwolsOfValue[upgradeModel.Prices[upgradeModel.CurrentPrice].NumberOfValuePrice]);
    }
    else
    {
      SetTextsToMaxStage(upgradeModel.Button.TextOfPrice);
    }
  }

  public void ConvertValuesOfPriceTexts(float price, Text text, string SybwolOfText)
  {
    text.text = price + SybwolOfText;
  }
  
  public void ConvertValuesOfMultiTexts(float price,Text text, string SybwolOfText)
  {
    text.text = "+" + price + SybwolOfText;
  }

  public void SetTextsToMaxStage(Text textPrice)
  {
    textPrice.text = "Max";
    textPrice.gameObject.transform.localPosition = new Vector2(0,0);
    textPrice.fontSize = 110;
  }

  public void ControllFontSizeAndPositionOfPriceText(Text textOfPrice, float price, string SybwolOfText)
  {
    if(SybwolOfText.Length == 0)
    {
      if (price > 0) textOfPrice.fontSize = 105;
      if (price > 100) textOfPrice.fontSize = 100; 
    }
    else if (SybwolOfText.Length > 0)
    {
      textOfPrice.fontSize = 90; 
    }

    textOfPrice.gameObject.transform.localPosition = new Vector2(78.43f,0);
  }
}
