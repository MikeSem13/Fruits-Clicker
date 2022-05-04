using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;
using UnityEngine.UIElements.Experimental;

public class BuyRebirth : MonoBehaviour
{
   // Nedded Classes
   public FruitCoinsValuteController FruitCoins;
   public MultiFruitCoinsValueController MultiFruitCoins;
   public ValuteController Valutes;
   public ResetAllUpgradeOfFruit ResetUpgrades;

   // Button For Rebirth
   public Button ButtonOfRebirth;

   // Variabels for rebirth parametres
   public int CountOfRebirth;

   // Save All Variables
   private void Start()
   {
      CountOfRebirth = PlayerPrefs.GetInt("Crebirth");
   }

   private void Update()
   {
      PlayerPrefs.SetInt("Crebirth", CountOfRebirth);
   }

   // Method for Start Rebirth
   public void StartRebith()
   {
      if (MultiFruitCoins.MultiFruitCoinsAfterRebirth > 0)
      {
         ResetUpgrades.ResetUpgrades();
         Valutes.IMultiFruitCoins.AddValute();
         CountOfRebirth++;
         FruitCoins.ResetAllFruitCoinsAndMultiForRebirth();
      }
      StartRebirthAnimation();
   }
   
   // Method for Start Rebirth Animation
   public void StartRebirthAnimation()
   {
      ButtonOfRebirth.GetComponent<Animator>().Play("ButtonOfRebirthAnimation");
   }
}
