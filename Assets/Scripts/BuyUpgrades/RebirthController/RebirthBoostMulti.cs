using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class RebirthBoostMulti : MonoBehaviour
{
   // Needed Classes
   public BuyRebirth Rebith;
   public FruitCoinsValuteController FruitCoins;

   // Method to define multi of Rebirth
   public void Update()
   { 
      FruitCoins.MultiOfRebirth = (Rebith.CountOfRebirth / 100) + 1;
   }
}
