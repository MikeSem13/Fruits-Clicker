using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class BuyFruit : MonoBehaviour
{
   // Needed Classes
   public FruitCoinsValuteController FruitCoins;
   public ValuteController Valutes;
   public ControllCurrentFruitInList ControllCurrentFruitInList;
   public FruitsController ControllFruits;
   public List<DescriberForFruitsInList> Desctiber;
   public List<DescriberForFruitsInList> AllFruitsDesctiber;

   public void Subscribe(DescriberForFruitsInList describer)
   {
      if (Desctiber == null)
      {
         Desctiber = new List<DescriberForFruitsInList>();
      }
      Desctiber.Add(describer);
   }

   // Method Of Buy Fruits
   public void BuyFruits()
   {
      if (Valutes.IMultiFruitCoins.BasicValue >= Desctiber[ControllCurrentFruitInList.CurrentFruitsInNumberInList].price & Desctiber[ControllCurrentFruitInList.CurrentFruitsInNumberInList].IsBuying == false)
      {
         Valutes.TakeAnyValueOfValute(global::Valutes.MultiFruitCoins, Desctiber[ControllCurrentFruitInList.CurrentFruitsInNumberInList].ValueOfPriceFruit, Desctiber[ControllCurrentFruitInList.CurrentFruitsInNumberInList].price);
         SetMultiOfFruits();
         Desctiber[ControllCurrentFruitInList.CurrentFruitsInNumberInList].IsBuying = true;
      }
   }

   public void SetMultiOfFruits()
   {
      FruitCoins.MultiOfFruits = Desctiber[ControllCurrentFruitInList.CurrentFruitsInNumberInList].multi;
      PlayerPrefs.SetInt("FruitCoinsFruitMulti", FruitCoins.MultiOfFruits);
   }
   
   private void Start()
   {
      for (int i = 0; i < AllFruitsDesctiber.Count; i++)
      {
         AllFruitsDesctiber[i].IsBuying = PlayerPrefs.GetInt( "ByingFruit" + i) != 0;
      }
      
      for (int i = 0; i < AllFruitsDesctiber.Count; i++)
      {
         AllFruitsDesctiber[i].CountOfMultiAwaking = PlayerPrefs.GetInt( "MultiAwake" + i);
      }
   }

   private void Update()
   {
      for (int i = 0; i < AllFruitsDesctiber.Count; i++)
      {
         PlayerPrefs.SetInt("ByingFruit" + i, AllFruitsDesctiber[i].IsBuying ? 1 : 0);
      }
      
      for (int i = 0; i < AllFruitsDesctiber.Count; i++)
      {
         PlayerPrefs.SetInt("MultiAwake" + i, AllFruitsDesctiber[i].CountOfMultiAwaking);
      }
   }
}
