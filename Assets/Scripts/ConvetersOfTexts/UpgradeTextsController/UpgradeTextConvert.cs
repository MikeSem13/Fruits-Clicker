using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeTextConvert : MonoBehaviour
{
  [SerializeField] private UpgradeManager UpgradeManager;
  [SerializeField] private TextConverter textConverter;

  private void Update()
  {
    for (int i = 0; i < UpgradeManager.Upgrades.Length; i++)
    {
      ConvertTextsOfUpgrades(UpgradeManager.Upgrades[i].NameOfUpgrade); 
    }
  }
  public void ConvertTextsOfUpgrades(string NameOfUpgrade)
  {
    UpgradeModel upgradeModel = UpgradeManager.Upgrades.FirstOrDefault(model => model.NameOfUpgrade == NameOfUpgrade);

    if (upgradeModel.CurrentPrice < upgradeModel.Prices.Length)
    {
      textConverter.ConvertValuesToText(upgradeModel.Button.TextOfPrice, upgradeModel.Prices[upgradeModel.CurrentPrice].Price, "");
      if(!upgradeModel.SpecialReward) textConverter.ConvertValuesToText(upgradeModel.TextOfMulti, upgradeModel.RewardMultis[upgradeModel.CurrentPrice].RewardMulti,"+");
      ControllFontSizeAndPositionOfPriceText(upgradeModel.Button.TextOfPrice, upgradeModel.Prices[upgradeModel.CurrentPrice].Price);
    }
    else
    {
      SetPriceTextToMaxStage(upgradeModel.Button.TextOfPrice);
      SetMultiTextToMaxStage(upgradeModel.TextOfMulti, upgradeModel);
    }
  }

  public void SetPriceTextToMaxStage(Text textPrice)
  {
    textPrice.text = "Max";
    textPrice.gameObject.transform.localPosition = new Vector2(0,0);
    textPrice.fontSize = 110;
  }

  public void SetMultiTextToMaxStage(Text textMulti, UpgradeModel upgradeModel)
  {
    float sum = 0;

    foreach (var price in upgradeModel.Prices)
    {
      sum += price.Price;
    }

    textConverter.ConvertValuesToText(textMulti, sum, "+");
  }
  
  public void ControllFontSizeAndPositionOfPriceText(Text textOfPrice, double price)
  {
    textOfPrice.gameObject.transform.localPosition = new Vector2(78.43535f,0);

    if (price < 1e+5) textOfPrice.fontSize = 100;
    else if (price < 1e+7) textOfPrice.fontSize = 85;
    else if (price < 1e+8) textOfPrice.fontSize = 95;
    else if (price < 1e+9) textOfPrice.fontSize = 75;
    else if (price < 1e+11) textOfPrice.fontSize = 90;
    else if (price < 1e+12) textOfPrice.fontSize = 80;
  }
}
