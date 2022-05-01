using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChooseFruitInRebirthCount : MonoBehaviour
{
   // NeededClasses
   public ControllCurrentFruitInList CurrentFruitInList;
   public FruitsController FruitsController;
   public BuyFruit BuyFruit;
   private void Start()
   {
      for (int i = 0; i < BuyFruit.AllFruitsDesctiber.Count; i++)
      {
         BuyFruit.AllFruitsDesctiber[i].IsSelected = PlayerPrefs.GetInt( "SelectFruit" + i) != 0;
      }
      CheckSelected();
   }

   private void Update()
   {
      for (int i = 0; i < BuyFruit.AllFruitsDesctiber.Count; i++)
      {
         PlayerPrefs.SetInt("SelectFruit" + i, BuyFruit.AllFruitsDesctiber[i].IsSelected ? 1 : 0);
      }
   }

   // Method To Choose Current fruit, from List of Fruits
   public void SetCurrentFruit()
   {
      FruitsController.CurrentFruitInNumber = CurrentFruitInList.CurrentFruitsInNumberInList;
      FruitsController.CurrentFruitInString = CurrentFruitInList.CurrentFruitsInStringInList;
      ChangeAboolOfSelected();
   }

   public void ChangeAboolOfSelected()
   {
      BuyFruit.AllFruitsDesctiber[BuyFruit.ControllCurrentFruitInList.CurrentFruitsInNumberInList].IsSelected = true;
      for (int i = 0; i < BuyFruit.ControllCurrentFruitInList.CurrentFruitsInNumberInList; i++)
      {
         BuyFruit.Desctiber[i].IsSelected = false;
      }

      for (int i = BuyFruit.ControllCurrentFruitInList.CurrentFruitsInNumberInList + 1; i < BuyFruit.AllFruitsDesctiber.Count; i++)
      {
         BuyFruit.Desctiber[i].IsSelected = false;
      }
   }

   public void CheckSelected()
   {
      int CountOfFalse = 0;
      for (int i = 0; i < BuyFruit.Desctiber.Count; i++)
      {
         if (BuyFruit.Desctiber[i].IsSelected == false)
         {
            CountOfFalse++;
         }
      }

      if (CountOfFalse == BuyFruit.Desctiber.Count) BuyFruit.Desctiber[0].IsSelected = true;
   }
}
