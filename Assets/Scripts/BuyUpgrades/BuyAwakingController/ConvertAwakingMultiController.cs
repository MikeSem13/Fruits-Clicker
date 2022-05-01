using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class ConvertAwakingMultiController : MonoBehaviour
{
   public FruitCoinsValuteController FruitCoins;
   public FruitDimondsValueController FruitDimonds;
   public MultiFruitCoinsValueController MultiFruitCoins;
   public BuyFruit Fruits;

   public void SetMultisOfAwaking()
   {
      for (int i = 0; i < Fruits.AllFruitsDesctiber.Count; i++)
      {
         if (Fruits.AllFruitsDesctiber[i].Awaking == TypesOfAwaking.FruitCoinsAwaking)
         {
            FruitCoins.MultiFromAwakingFruitCoins += Fruits.AllFruitsDesctiber[i].CountOfMultiAwaking - 1;  
            PlayerPrefs.SetInt("FruitCoinsAwakingMulti", FruitCoins.MultiFromAwakingFruitCoins);
         }
         if (Fruits.AllFruitsDesctiber[i].Awaking == TypesOfAwaking.FruitDimondsAwaking)
         {
            FruitDimonds.MultiFromAwakingFruitDimonds += Fruits.AllFruitsDesctiber[i].CountOfMultiAwaking - 1;  
            PlayerPrefs.SetInt("FruitDimondsAwakingMulti", FruitDimonds.MultiFromAwakingFruitDimonds);
         }
         if (Fruits.AllFruitsDesctiber[i].Awaking == TypesOfAwaking.MultiFruitCoinsAwaking)
         {
            MultiFruitCoins.MultiFromAwakingMultiFruit += Fruits.AllFruitsDesctiber[i].CountOfMultiAwaking - 1;  
            PlayerPrefs.SetInt("MultiAwakingMultiFruit", MultiFruitCoins.MultiFromAwakingMultiFruit);
         }
      }
   }
}

