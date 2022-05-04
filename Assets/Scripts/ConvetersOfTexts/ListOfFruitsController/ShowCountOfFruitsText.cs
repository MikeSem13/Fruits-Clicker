using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowCountOfFruitsText : MonoBehaviour
{
   // Needed Classes
   public FruitsController Fruits;
   public BuyFruit BuyFruit;
   
   public Text TextOfCountFruits;
   
   public int CountOfUnlockedFruits;

   private void Start()
   {
      CountOfUnlockedFruits = 0;
   }

   // Convert Count Of Fruits to Text
   private void Update()
   {
      TextOfCountFruits.text = CountOfUnlockedFruits + "/" + Fruits.AllFruits.Count;
   }

   public void GetUnlockFruits()
   {
      for (int i = 0; i < BuyFruit.AllFruitsDesctiber.Count; i++)
      {
         if (BuyFruit.AllFruitsDesctiber[i].IsUnlocked)
         {
            CountOfUnlockedFruits = i + 1;
         }
      }
   }
}
