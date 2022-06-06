using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickManager : MonoBehaviour
{
   [SerializeField] private ValutesMathOperations valutesMathOperations;
   [SerializeField] private BoostsOfUpgrades boostsOfUpgrades;
   [SerializeField] private CreateATextsOfFruitCoins SpawnerOfTexts;
   
   public void ClickOnFruit()
   {
      GetRewardForClick();
      SpawnTexts();
   }

   private void GetRewardForClick()
   {
      valutesMathOperations.AddValute("Fruit Coins");
      valutesMathOperations.AddValuteWithChance("Fruit Dimonds", boostsOfUpgrades.ChanceOfMoreDimonds);
   }

   private void SpawnTexts()
   {
      SpawnerOfTexts.SpawnOnClick();
   }
}
