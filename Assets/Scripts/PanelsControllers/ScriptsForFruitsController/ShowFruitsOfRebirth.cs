using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowFruitsOfRebirth : MonoBehaviour
{
  // Needed Classes
  public FruitsController FruitsController;
  public BuyFruit BuyFruit;

  // AllFruits
  public List<GameObject> Fruits;

  // Method To Show Fruit What You Choose
  private void FixedUpdate()
  {
    if (BuyFruit.AllFruitsDesctiber[FruitsController.CurrentFruitInNumber].IsSelected)
    {
      Fruits[FruitsController.CurrentFruitInNumber].SetActive(true);

      for (int i = 0; i < FruitsController.CurrentFruitInNumber; i++)
      {
        Fruits[i].SetActive(false);
      }

      for (int i = FruitsController.CurrentFruitInNumber + 1; i < Fruits.Count; i++)
      {
        Fruits[i].SetActive(false);
      }
    }
  }
}
  
