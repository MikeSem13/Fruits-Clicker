using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RebirthManager : MonoBehaviour
{
   [SerializeField] private ValuteManager valuteManager;
   [SerializeField] private MathOperationsManager mathOperations;

   public float Rebirths;
   
   public void BuyRebirth()
   {
      GetRewardForRebirth();
      TakeForRebirth();
   }

   public void GetRewardForRebirth()
   {
      mathOperations.add.AddValues(ref Rebirths, 1);
   }

   public void TakeForRebirth()
   {
      
   }
}
