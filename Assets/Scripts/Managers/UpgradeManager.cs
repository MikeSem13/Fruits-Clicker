using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Serialization;

public class UpgradeManager : MonoBehaviour
{
   [Header("Classes")]
   [SerializeField] private ValuteManager valuteManager;
   [SerializeField] private ValutesMathOperations valutesMathOperations;
   [SerializeField] private MathOperationsManager mathOperationsManager;
   private BoostsFromUpgrades boostsFromUpgrades;
   
   [Space]
   [Header("Seriaseble Classes")]
   public UpgradeModel [] Upgrades;

   [Space]
   [Header("Спрайты для кнопок")]
   public Sprite ActiveSprite;
   public Sprite NonActiveSprite;

   private void Awake()
   {
      boostsFromUpgrades = GetComponent<BoostsFromUpgrades>();
   }
   
   public void BuyUpgrade(string UpgradeName)
   {
      UpgradeModel upgradeModel = Upgrades.FirstOrDefault(model => model.NameOfUpgrade == UpgradeName);
      ValutesModel valutesModel = valuteManager.GetValute(upgradeModel.NameOfValute);

      if (upgradeModel.CurrentPrice < upgradeModel.Prices.Length)
      {
         RunActionsAfterUpgrade(valutesModel, upgradeModel);
      }
   }

   public void RunActionsAfterUpgrade(ValutesModel valutesModel, UpgradeModel upgradeModel)
   {
      if ( MatchValuteToPrice(valutesModel.Valute, upgradeModel.Prices[upgradeModel.CurrentPrice].Price) )
      {
         valutesMathOperations.TakeValute(valutesModel.NameOfValute, upgradeModel.Prices[upgradeModel.CurrentPrice]);
         ChooseRewardOfUpgrade(valutesModel, upgradeModel);
         upgradeModel.CurrentPrice++;
      }
   }

   public void ChooseRewardOfUpgrade(ValutesModel valutesModel, UpgradeModel upgradeModel)
   {
      if (!upgradeModel.SpecialReward) valutesMathOperations.AddMultiplierBoost(valutesModel.NameOfValute,"Click Boost", upgradeModel.NameOfUpgrade);
      else DefineSpecialReward(upgradeModel);
   }

   public void DefineSpecialReward(UpgradeModel upgradeModel)
   {
      switch (upgradeModel.TypeOfSpecialUpgrade)
      {
         case SpecialUpgradesEnum.DoubleCoinsChance:
            mathOperationsManager.add.AddValues(ref boostsFromUpgrades.PercentOfDoubleCoins, upgradeModel.SpecialRewards[upgradeModel.CurrentPrice].SpecialReward);
            break;
         case SpecialUpgradesEnum.MoreDimondsChance:
            mathOperationsManager.add.AddValues(ref boostsFromUpgrades.PercentOfMoreDimonds, upgradeModel.SpecialRewards[upgradeModel.CurrentPrice].SpecialReward);
            break;
         case SpecialUpgradesEnum.MoreTimeForGoldBoost:
            mathOperationsManager.add.AddValues(ref boostsFromUpgrades.GoldBoostTime, upgradeModel.SpecialRewards[upgradeModel.CurrentPrice].SpecialReward);
            break;
         case SpecialUpgradesEnum.MoreDimondFruitsChance:
            mathOperationsManager.add.AddValues(ref boostsFromUpgrades.PercentOfDimondFruits, upgradeModel.SpecialRewards[upgradeModel.CurrentPrice].SpecialReward);
            break;
         case SpecialUpgradesEnum.MoreLevelFruit:
            mathOperationsManager.add.AddValues(ref boostsFromUpgrades.PercentOfLevelFruit, upgradeModel.SpecialRewards[upgradeModel.CurrentPrice].SpecialReward);
            break;
         case SpecialUpgradesEnum.MoreMultiFruitCoins:
            mathOperationsManager.add.AddValues(ref boostsFromUpgrades.PercentOfMultiFruitCoins, upgradeModel.SpecialRewards[upgradeModel.CurrentPrice].SpecialReward);
            break;
         case SpecialUpgradesEnum.DoubleDimondsChance:
            mathOperationsManager.add.AddValues(ref boostsFromUpgrades.PercentOfDoubleDimonds, upgradeModel.SpecialRewards[upgradeModel.CurrentPrice].SpecialReward);
            break;
      }
   }
   
   public bool MatchValuteToPrice(double valute, double price)
   {
      if (valute >= price) return true;
      else return false;
   }

   public void ResetUpgrades()
   {
      foreach (var Upgrade in Upgrades)  Upgrade.CurrentPrice = 0;
   }
}
