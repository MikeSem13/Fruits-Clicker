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
   private BoostsOfUpgrades Boosts;
   
   [Space]
   [Header("Seriaseble Classes")]
   public UpgradeModel [] Upgrades;

   [Space]
   [Header("Спрайты для кнопок")]
   public Sprite ActiveSprite;
   public Sprite NonActiveSprite;

   private void Awake()
   {
      Boosts = GetComponent<BoostsOfUpgrades>();
   }

   private void Start()
   {
      SetNumbersOfValueInUpgrade();
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
      if ( MatchValuteToPrice(valutesModel.Values[upgradeModel.Prices[upgradeModel.CurrentPrice].NumberOfValuePrice].Valute, upgradeModel.Prices[upgradeModel.CurrentPrice].Price) )
      {
         valutesMathOperations.TakeValuteForUpgrade(valutesModel.NameOfValute, upgradeModel.Prices[upgradeModel.CurrentPrice],upgradeModel);
         ChooseRewardOfUpgrade(valutesModel, upgradeModel);
         upgradeModel.CurrentPrice++;
      }
      else
      {
         bool GetReward = false;
         valutesMathOperations.TakeFromFarValutes(valutesModel.NameOfValute, upgradeModel.Prices[upgradeModel.CurrentPrice],upgradeModel, ref GetReward);
         if (GetReward)
         {
            valutesMathOperations.AddMulti(valutesModel.NameOfValute, upgradeModel.NameOfUpgrade);
            upgradeModel.CurrentPrice++;
         }
      }
   }

   public void ChooseRewardOfUpgrade(ValutesModel valutesModel, UpgradeModel upgradeModel)
   {
      if (!upgradeModel.SpecialReward) valutesMathOperations.AddMulti(valutesModel.NameOfValute, upgradeModel.NameOfValute);
      else DefineSpecialReward(upgradeModel);
   }

   public void DefineSpecialReward(UpgradeModel upgradeModel)
   {
      switch (upgradeModel.TypeOfSpecialUpgrade)
      {
         case SpecialUpgradesEnum.DoubleCoinsChance:
            mathOperationsManager.add.AddValues(ref Boosts.ChanceOfDoubleCoins, upgradeModel.SpecialRewards[upgradeModel.CurrentPrice].SpecialReward);
            break;
         case SpecialUpgradesEnum.MoreDimondsChance:
            mathOperationsManager.add.AddValues(ref Boosts.ChanceOfMoreDimonds, upgradeModel.SpecialRewards[upgradeModel.CurrentPrice].SpecialReward);
            break;
         case SpecialUpgradesEnum.MoreTimeForGoldBoost:
            mathOperationsManager.add.AddValues(ref Boosts.GoldBoostTime, upgradeModel.SpecialRewards[upgradeModel.CurrentPrice].SpecialReward);
            break;
         case SpecialUpgradesEnum.MoreDimondFruitsChance:
            mathOperationsManager.add.AddValues(ref Boosts.ChanceOfDimondFruits, upgradeModel.SpecialRewards[upgradeModel.CurrentPrice].SpecialReward);
            break;
         case SpecialUpgradesEnum.MoreLevelFruit:
            mathOperationsManager.add.AddValues(ref Boosts.PerzentOfLevelFruit, upgradeModel.SpecialRewards[upgradeModel.CurrentPrice].SpecialReward);
            break;
         case SpecialUpgradesEnum.MoreMultiFruitCoins:
            mathOperationsManager.add.AddValues(ref Boosts.PerzentOfMultiFruitCoins, upgradeModel.SpecialRewards[upgradeModel.CurrentPrice].SpecialReward);
            break;
         case SpecialUpgradesEnum.DoubleDimondsChance:
            mathOperationsManager.add.AddValues(ref Boosts.ChanceOfDoubleDimonds, upgradeModel.SpecialRewards[upgradeModel.CurrentPrice].SpecialReward);
            break;
      }
   }
   
   public bool MatchValuteToPrice(float valute, float price)
   {
      if (valute >= price) return true;
      else return false;
   }

   public void SetNumbersOfValueInUpgrade()
   {
      foreach (var Upgrade in Upgrades)
      {
         foreach (var Price in Upgrade.Prices)
         {
            Price.NumberOfValuePrice = (int) Price.Value;
         }
      }

      foreach (var Upgrade in Upgrades)
      {
         foreach (var Reward in Upgrade.RewardMultis)
         {
            Reward.NumberOfValueRewardMulti = (int) Reward.Value;
         }
      }
   }
}
