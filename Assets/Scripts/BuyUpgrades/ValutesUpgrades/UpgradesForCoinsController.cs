using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class UpgradesForCoinsController : MonoBehaviour
{

    // Method to Buy Upgrade For Coins
   public void BuyFruitCoinsUpgrade(BuyButtons BuyButton)
   {
      if (BuyButton.CurrentLevel < BuyButton.MaxLevel)
      {
         //Upgrades.BuyUpgradeWithMultiForAnyValue(BuyButton,global::Valutes.FruitCoins,BuyButton.Values,(int)BuyButton.price[BuyButton.CurrentLevel],BuyButton.multi[BuyButton.CurrentLevel]);
      }
   }
}
