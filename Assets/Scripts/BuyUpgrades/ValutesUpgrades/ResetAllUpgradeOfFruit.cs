using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class ResetAllUpgradeOfFruit : MonoBehaviour
{
   // Needed Classes
   public BuyUpgrades Upgrades;
   
   // Method to Reset All Upgrades After Rebirth
   public void ResetUpgrades()
   {
      for (int i = 0; i < Upgrades.Buttons.Count; i++)
      {
         if (Upgrades.Buttons[i].TypeOfUpgrade == TypesOfUpgrades.CoinsUpgrade)
         {
            Upgrades.Buttons[i].CurrentLevel = 0;  
         }
      }
   }
}
