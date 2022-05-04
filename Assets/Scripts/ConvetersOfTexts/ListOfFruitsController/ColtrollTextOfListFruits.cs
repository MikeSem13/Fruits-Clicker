using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ColtrollTextOfListFruits : MonoBehaviour
{
   // Classes needed for Describe Fruits
   public List<DescriberForFruitsInList> Describers;
   // Texts For levels of Fruit
   public List<Text> TextsForLevels;

   // Convert Text to Level of Fruit
   private void Update()
   {
      for (int i = 0; i < Describers.Count; i++)
      {
         TextsForLevels[i].text = "Level " + (Describers[i].LevelOfFruit + 1).ToString();
         if (Describers[i].LevelOfFruit == Describers[i].MaxLevelOfFruit)
         {
            TextsForLevels[i].text = "Max";
         }
      }
   }
}
