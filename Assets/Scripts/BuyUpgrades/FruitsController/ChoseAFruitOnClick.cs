using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChoseAFruitOnClick : MonoBehaviour
{
   // Needed Classes
   public ChooseFruitInRebirthCount ChooseFruitInRebirthCount;
   public BuyFruit BuyFruit;
   
   // Method which select Fruit
   public void SelectFruit()
   {
      if (BuyFruit.AllFruitsDesctiber[BuyFruit.ControllCurrentFruitInList.CurrentFruitsInNumberInList].IsBuying == true)
      {
         ChooseFruitInRebirthCount.SetCurrentFruit();
      }
   }
}
