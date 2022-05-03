using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class RebirthBoostMulti : MonoBehaviour
{
   // Needed Classes
   public ValuteController Valute;
   public FruitCoinsValuteController FruitCoins;

   // Method to define multi of Rebirth
   public void Update()
   { 
      FruitCoins.MultiOfRebirth = (int)(Valute.IMultiFruitCoins.BasicValue / 10) + 1;
   }
}
