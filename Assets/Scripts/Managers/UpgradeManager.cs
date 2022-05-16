using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class UpgradeManager : MonoBehaviour
{
   [SerializeField] private AccountValutes AccountValutes;
   public List<UpgradeModel> Upgrades;

   public void BuyUpgrade(string UpgradeName)
   {
      UpgradeModel upgradeModel = Upgrades.FirstOrDefault(model => model.NameOfUpgrade == UpgradeName);

      if (upgradeModel.CurrentPrice < upgradeModel.Prices.Count)
      {
         upgradeModel.SetNumberOfValuePrice();
         AccountValutes.TakeValute(upgradeModel.NameOfValute, upgradeModel.Prices[upgradeModel.CurrentPrice].Price, upgradeModel);  
      }
   }
}
