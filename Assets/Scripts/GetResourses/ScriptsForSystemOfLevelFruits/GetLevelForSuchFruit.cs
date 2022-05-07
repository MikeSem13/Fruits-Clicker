using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetLevelForSuchFruit : MonoBehaviour
{
    // Class needed to defintion current fruit
    public FruitsController FruitsController;
    
    // Classes to describe all fruits
   public List<DescriberForFruitsInList> Describers;

   public int CountOfMinusScores = 1;

   // Save Level and Count of Clicks of Fruits
   private void Start()
   {
       CountOfMinusScores = PlayerPrefs.GetInt("MinusScores");

       if (CountOfMinusScores == 0) CountOfMinusScores = 1;

       for (int i = 0; i < Describers.Count; i++)
       {
           Describers[i].LevelOfFruit = PlayerPrefs.GetInt("CLevelFruit" + i);
       }
       
       for (int i = 0; i < Describers.Count; i++)
       {
           Describers[i].CurrentClickOfLevel = PlayerPrefs.GetInt("CountClicks" + i);
       }
   }

   private void Update()
   {
       for (int i = 0; i < Describers.Count; i++)
       {
           PlayerPrefs.SetInt("CLevelFruit" + i, Describers[i].LevelOfFruit);
       }

       for (int i = 0; i < Describers.Count; i++)
       {
           PlayerPrefs.SetInt("CountClicks" + i, Describers[i].CurrentClickOfLevel);   
       }
   }

   public void AddCountOfScoresForClick()
   {
       CountOfMinusScores++;
       PlayerPrefs.SetInt("MinusScores",CountOfMinusScores);
   }
   
   // Class needed to count clicks to get Level
   public void ClickToGetLevel()
   {
       if (Describers[FruitsController.CurrentFruitInNumber].LevelOfFruit < Describers[FruitsController.CurrentFruitInNumber].MaxLevelOfFruit )
       {
           Describers[FruitsController.CurrentFruitInNumber].CurrentClickOfLevel += CountOfMinusScores;    
           LevelUpFruit();
       }
   }

   // Class needed to count Level Up
   public void LevelUpFruit()
   {
       if (Describers[FruitsController.CurrentFruitInNumber].CurrentClickOfLevel >= Describers[FruitsController.CurrentFruitInNumber].CountOfClicksToLevelUpFruit[Describers[FruitsController.CurrentFruitInNumber].LevelOfFruit])
       {
           Describers[FruitsController.CurrentFruitInNumber].LevelOfFruit++;
           Describers[FruitsController.CurrentFruitInNumber].CurrentClickOfLevel = 0;
       }
   }
}
