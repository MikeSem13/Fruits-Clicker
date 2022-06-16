using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class RebirthManager : MonoBehaviour
{
   [Header("Классы")]
   [SerializeField] private ValuteManager valuteManager;
   [SerializeField] private UpgradeManager upgradeManager;
   [SerializeField] private MathOperationsManager mathOperations;
   [SerializeField] private PanelManager panelManager;

   [Space]
   [Space]
   [Header("Количевство перерождений")]
   public double Rebirths;
   [Space]
   [Header("Цена за перерождение")]
   public double PriceOfRebirth;

   [Space] 
   [Header("Мультифрукт коины после перерождения")]
   public double MultiFruitCoinsReward;

   private void Update()
   {
      PrepareMultiFruitCoins(valuteManager.GetValute("Fruit Coins").Valute);
   }

   public void BuyRebirth()
   {
      if (upgradeManager.MatchValuteToPrice(valuteManager.GetValute("Fruit Coins").Valute, PriceOfRebirth))
      {
         GetRewardForRebirth();
         TakeForRebirth();
         panelManager.HideLastPanel();  
      }
   }

   public void GetRewardForRebirth()
   {
      mathOperations.add.AddValues(ref Rebirths, 1);
      mathOperations.add.AddValues(ref valuteManager.GetValute("MultiFruit Coins").Valute, MultiFruitCoinsReward);
   }

   public void TakeForRebirth()
   {
      valuteManager.ResetValute("Fruit Coins");
      upgradeManager.ResetUpgrades();
   }

   public void PrepareMultiFruitCoins(double valuteToConvert)
   {
      if (valuteToConvert < 250e+9) MultiFruitCoinsReward = (int)(valuteToConvert / 1e+9);
      else if (valuteToConvert < 100e+10) MultiFruitCoinsReward = (int)(valuteToConvert / 1e+9 * 0.5 + 250);
      else if (valuteToConvert < 1.5e+11) MultiFruitCoinsReward = (int)(valuteToConvert / 1e+9 * 0.5 + 250);
   }
}
