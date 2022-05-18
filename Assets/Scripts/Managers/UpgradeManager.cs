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

   [Space]
   [Header("Символы для размерностей")]
   public List<string> SybwolsOfValue;
   
   [Space]
   [Header("Спрайты для кнопок")]
   public Sprite ActiveSprite;
   public Sprite NonActiveSprite;
   
   private void Start()
   {
      for (int i = 0; i < Upgrades.Count; i++)
      { 
         Upgrades[i].SetNumberOfPrice();
         Upgrades[i].SetNumberOfMulti();
      }
   }

   public void BuyUpgrade(string UpgradeName)
   {
      UpgradeModel upgradeModel = Upgrades.FirstOrDefault(model => model.NameOfUpgrade == UpgradeName);

      if (upgradeModel.CurrentPrice < upgradeModel.Prices.Count)
      {
         accountValutesValriables.TakeValuteForReward(upgradeModel.NameOfValute, upgradeModel.Prices[upgradeModel.CurrentPrice].Price, upgradeModel);
      }
   }
}
