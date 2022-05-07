using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class RebirthBoostMulti : MonoBehaviour
{
   // Needed Classes
   public ValuteController Valute;

   // Method to define multi of Rebirth
   public void SetMultiOfRebirth()
   { 
      Valute.FruitCoins.MultiOfRebirth = (Valute.MultiFruitCoins.BasicValue / 100);
   }
}
