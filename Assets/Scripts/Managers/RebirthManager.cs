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
   [SerializeField] private double PriceOfRebirth;

   [Space] 
   [Header("Мультифрукт коины после перерождения")]
   [SerializeField] private double MultiFruitCoinsReward; 

   private void Update()
   {
      GetMultiFruitCoinsReward(valuteManager.GetValute("Fruit Coins").Valute);
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
      valuteManager.valutesMathOperations.AddValute(valuteManager.GetValute("MultiFruit Coins").NameOfValute, MultiFruitCoinsReward);
   }

   public void TakeForRebirth()
   {
      valuteManager.ResetValute("Fruit Coins", "Click Boost");
      upgradeManager.ResetUpgrades();
   }

   public void GetMultiFruitCoinsReward(double valute)
   {
      if (valute >= 1e+9) MultiFruitCoinsReward = valute / 1e+9;
      if (valute >= 2.5e+11) MultiFruitCoinsReward = (valute / 1e+9) * 0.5 + 250 * (1 - 0.5);
   }
}
