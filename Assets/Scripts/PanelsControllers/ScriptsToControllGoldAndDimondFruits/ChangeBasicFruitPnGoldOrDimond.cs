using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeBasicFruitPnGoldOrDimond : MonoBehaviour
{
   public FruitsController FruitsController;
   public GoldAndDimondBoostController GoldBoost;
   public ValuteController Valutes;
   
   public List<GameObject> Fruits;
   
   public List<Sprite> BasicSpritesOfFruits;
   public List<Sprite> GoldSpritesOfFruits;
   public List<Sprite> DimondSpritesOfFruits;
   

   private void Update()
   {
      ChangeFruitsOnGold();
   }

   public void ChangeFruitsOnGold()
   {
      if (GoldBoost.BoostActive == true)
      {
         Fruits[FruitsController.CurrentFruitInNumber].GetComponent<Image>().sprite = GoldSpritesOfFruits[FruitsController.CurrentFruitInNumber];
         if (Valutes.FruitCoins.MultiOfGoldOrDimondsFruits == 100)
         {
            Fruits[FruitsController.CurrentFruitInNumber].GetComponent<Image>().sprite = DimondSpritesOfFruits[FruitsController.CurrentFruitInNumber];
         }
         else
         {
            Fruits[FruitsController.CurrentFruitInNumber].GetComponent<Image>().sprite = GoldSpritesOfFruits[FruitsController.CurrentFruitInNumber];
         }  
      }
      else
      {
         Fruits[FruitsController.CurrentFruitInNumber].GetComponent<Image>().sprite = BasicSpritesOfFruits[FruitsController.CurrentFruitInNumber];
      }
   }
}
