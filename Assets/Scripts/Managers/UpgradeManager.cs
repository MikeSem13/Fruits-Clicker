using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Serialization;

public class UpgradeManager : MonoBehaviour
{
   [SerializeField] private AccountValutesValriables accountValutesValriables;
   public List<UpgradeModel> Upgrades;

   public void BuyUpgrade(string UpgradeName)
   {
      UpgradeModel upgradeModel = Upgrades.FirstOrDefault(model => model.NameOfUpgrade == UpgradeName);

      if (upgradeModel.CurrentPrice < upgradeModel.Prices.Count)
      {
         upgradeModel.SetNumberOfPrice();
         upgradeModel.SetNumberOfMulti();
         accountValutesValriables.TakeValuteForReward(upgradeModel.NameOfValute, upgradeModel.Prices[upgradeModel.CurrentPrice].Price, upgradeModel);
      }
   }
}
