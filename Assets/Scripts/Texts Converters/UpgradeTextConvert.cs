using System;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

[Serializable] public class UpgradeTextConvert 
{
  [SerializeField] private UpgradeManager UpgradeManager;
  [SerializeField] private TextConvertManager textConvertManager;

  public void ConvertAllTextOfUpgradesToText()
  {
    foreach (UpgradeModel upgrade in UpgradeManager.Upgrades) ConvertTextsOfUpgrades(upgrade.NameOfUpgrade); 
  }
  
  private void ConvertTextsOfUpgrades(string NameOfUpgrade)
  {
    UpgradeModel upgradeModel = UpgradeManager.Upgrades.FirstOrDefault(model => model.NameOfUpgrade == NameOfUpgrade);

    if (upgradeModel.CurrentPrice < upgradeModel.Prices.Length)
    {
      textConvertManager.ValuesToText.ConvertValueToText(upgradeModel.Button.TextOfPrice, upgradeModel.Prices[upgradeModel.CurrentPrice].Price, "");
      if(!upgradeModel.SpecialReward) textConvertManager.ValuesToText.ConvertValueToText(upgradeModel.TextOfMulti, upgradeModel.RewardMultis[upgradeModel.CurrentPrice].RewardMulti,"+");
      ControllFontSizeAndPositionOfPriceText(upgradeModel.Button.TextOfPrice, upgradeModel.Prices[upgradeModel.CurrentPrice].Price);
    }
    else
    {
      SetPriceTextToMaxStage(upgradeModel.Button.TextOfPrice);
      SetMultiTextToMaxStage(upgradeModel.TextOfMulti, upgradeModel);
    }
  }

  private void SetPriceTextToMaxStage(Text textPrice)
  {
    textPrice.text = "Max";
    textPrice.gameObject.transform.localPosition = new Vector2(0,0);
    textPrice.fontSize = 110;
  }

  private void SetMultiTextToMaxStage(Text textMulti, UpgradeModel upgradeModel)
  {
    double sum = 0;

    foreach (var price in upgradeModel.Prices)
    {
      sum += price.Price;
    }

    textConvertManager.ValuesToText.ConvertValueToText(textMulti, sum, "+");
  }
  
  private void ControllFontSizeAndPositionOfPriceText(Text textOfPrice, double price)
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
