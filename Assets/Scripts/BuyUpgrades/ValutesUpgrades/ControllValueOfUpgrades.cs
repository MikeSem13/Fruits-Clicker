using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class ControllValueOfUpgrades : MonoBehaviour
{
   private BuyButtons BuyButton;

   public int BoardOfStartBillionValues;
   public int BoardOfStartQuintillionValues;

   private void Start()
   {
      BuyButton = GetComponent<BuyButtons>();
   }

   private void Update()
   {
      ControllValueOfUpgrade();
   }

   public void ControllValueOfUpgrade()
   {
      SetValueOfUpgrade(BoardOfStartBillionValues,Values.Billons);
      SetValueOfUpgrade(BoardOfStartQuintillionValues,Values.Quintillions);
   }

   public void SetValueOfUpgrade(int Board,  Values Value)
   {
      if (BuyButton.CurrentLevel >= Board && Board != 0) BuyButton.Values = Value;
      else if (BuyButton.CurrentLevel < BoardOfStartBillionValues) BuyButton.Values = Values.Basic;
   }
}
