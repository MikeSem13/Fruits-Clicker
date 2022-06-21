
using UnityEngine;


public class ClickManager : MonoBehaviour
{
   [Header("Нужные классы")]
   [SerializeField] private ValuteManager valuteManager;
   [SerializeField] private BoostsFromUpgrades boostsFromUpgrades;
   [SerializeField] private CreateATextsOfFruitCoins SpawnerOfTexts;
   
   public void ClickOnFruit()
   {
      GetRewardForClick();
      SpawnTexts();
   }

   private void GetRewardForClick()
   {
      TryGetDoubleBoost(ref valuteManager.GetValute("Fruit Coins").GetMultiBoost("Double Boost").Boost, boostsFromUpgrades.PercentOfDoubleCoins);

      valuteManager.GetValute("Fruit Coins").ConectAllBoostsToMulti();
      valuteManager.GetValute("Fruit Dimonds").ConectAllBoostsToMulti();
      
      valuteManager.valutesMathOperations.AddValute("Fruit Coins", valuteManager.GetValute("Fruit Coins").ValuteMultiplier);
      valuteManager.valutesMathOperations.AddValuteWithChance("Fruit Dimonds", valuteManager.GetValute("Fruit Dimonds").ValuteMultiplier,boostsFromUpgrades.PercentOfMoreDimonds);
   }

   private void TryGetDoubleBoost(ref double boost, double percent)
   {
      double Chance = Random.Range(0, 100);
      if (Chance < percent) boost = 2;
      else boost = 1;
   }
   
   private void SpawnTexts()
   {
      SpawnerOfTexts.SpawnOnClick();
   }
}
