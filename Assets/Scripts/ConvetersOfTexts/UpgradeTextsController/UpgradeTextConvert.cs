using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeTextConvert : MonoBehaviour
{
  [SerializeField] private UpgradeManager UpgradeManager;
  [SerializeField] private DemisionsOfValutes DemisionsOfValutes;

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
      ConvertValuesOfPriceTexts(upgradeModel.Prices[upgradeModel.CurrentPrice], upgradeModel.Button.TextOfPrice, DemisionsOfValutes.SybwolsOfValutes[upgradeModel.Prices[upgradeModel.CurrentPrice].NumberOfValuePrice]);
      if(!upgradeModel.SpecialReward) ConvertValuesOfMultiTexts(upgradeModel.RewardMultis[upgradeModel.CurrentPrice], upgradeModel.TextOfMulti, DemisionsOfValutes.SybwolsOfValutes[upgradeModel.RewardMultis[upgradeModel.CurrentPrice].NumberOfValueRewardMulti]); 
      ControllFontSizeAndPositionOfPriceText(upgradeModel.Button.TextOfPrice, upgradeModel.Prices[upgradeModel.CurrentPrice].Price, DemisionsOfValutes.SybwolsOfValutes[upgradeModel.Prices[upgradeModel.CurrentPrice].NumberOfValuePrice]);
    }
    else
    {
      SetPriceTextToMaxStage(upgradeModel.Button.TextOfPrice);
      SetMultiTextToMaxStage(upgradeModel.TextOfMulti, upgradeModel, DemisionsOfValutes.SybwolsOfValutes[upgradeModel.RewardMultis[upgradeModel.CurrentPrice - 1].NumberOfValueRewardMulti]);
    }
  }

  public void ConvertValuesOfPriceTexts(PriceOfUpgradeModel price, Text text, SybwolModel sybwol)
  {
    if (price.Price < 10  && price.LastPrice >= 100) text.text = price.Price + "." + Mathf.Floor(price.LastPrice / 100) + sybwol.Sybwol;
    else if (price.Price < 1000) text.text = price.Price + sybwol.Sybwol;
  }
  
  public void ConvertValuesOfMultiTexts(MultiRewardOfUpgradeModel multi,Text text, SybwolModel sybwol)
  {
    if (multi.RewardMulti < 10 && multi.LastRewardMulti >= 100) text.text = "+" + multi.RewardMulti + "." + Mathf.Floor(multi.LastRewardMulti / 100) + sybwol.Sybwol;
    else if (multi.RewardMulti < 1000) text.text = "+" + multi.RewardMulti + sybwol.Sybwol;
  }

  public void SetPriceTextToMaxStage(Text textPrice)
  {
    textPrice.text = "Max";
    textPrice.gameObject.transform.localPosition = new Vector2(0,0);
    textPrice.fontSize = 110;
  }

  public void SetMultiTextToMaxStage(Text textMulti, UpgradeModel upgradeModel, SybwolModel sybwol)
  {
    float sum = 0;
    float LastSum = 0;
    
    for (int i = 0; i < upgradeModel.RewardMultis.Length; i++)
    {
      if (upgradeModel.RewardMultis[i].NumberOfValueRewardMulti == upgradeModel.RewardMultis[upgradeModel.RewardMultis.Length - 1].NumberOfValueRewardMulti)
      {
         sum += upgradeModel.RewardMultis[i].RewardMulti;
         if (upgradeModel.RewardMultis[i].LastRewardMulti > 0) LastSum += upgradeModel.RewardMultis[i].LastRewardMulti;
      }
      else if (upgradeModel.RewardMultis[i].NumberOfValueRewardMulti == upgradeModel.RewardMultis[upgradeModel.RewardMultis.Length - 2].NumberOfValueRewardMulti)
      {
        LastSum += upgradeModel.RewardMultis[i].RewardMulti; 
      }
    }

    if (sum < 10) textMulti.text = "+" + sum + "." + Mathf.Floor(LastSum/ 100) + sybwol.Sybwol;
    else if (sum < 1000) textMulti.text = "+" + sum + sybwol.Sybwol;
  }
  
  public void ControllFontSizeAndPositionOfPriceText(Text textOfPrice, float price, SybwolModel sybwol)
  {
    if (sybwol.Sybwol == " ")
    {
      textOfPrice.fontSize = 100;
    }
    else if (sybwol.Sybwol.Length > 0)
    {
      if (sybwol.HugeWord)
      {
        
      }
      else
      {
        
      }
    }

    textOfPrice.gameObject.transform.localPosition = new Vector2(78.43f,0);
  }
}
