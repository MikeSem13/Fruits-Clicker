using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ConvertAnyValueToText : MonoBehaviour
{
    public ValuteController Valutes;
    public Text TextOfFruitCoins;
    public Text TextOfDimonds;
    public Text TextOfMultiFruitCoins;

    // Convert Value Of FruitCoins to text
   private void Update()
   { 
      ConvertValueToTexts(Valutes.IFruitCoins.GetValuesOfValute(),Valutes.IFruitCoins,TextOfFruitCoins);
      ConvertValueToTexts(Valutes.IFruitDimonds.GetValuesOfValute(),Valutes.IFruitDimonds,TextOfDimonds);
      ConvertValueToTexts(Valutes.IMultiFruitCoins.GetValuesOfValute(),Valutes.IMultiFruitCoins,TextOfMultiFruitCoins);
   }

   public void ConvertValueToTexts(Values Values, IValuteController ValuteController, Text TextOfValute)
   {
       switch (Values)
       {
           case Values.Basic:
               if (ValuteController.BasicValue <= 999) TextOfValute.text = ValuteController.BasicValue.ToString();
               if (ValuteController.BasicValue > 999 && ValuteController.BasicValue <= 9999) TextOfValute.text = Math.Round((double)ValuteController.BasicValue / 1000,1) + "k";
               if (ValuteController.BasicValue > 9999 && ValuteController.BasicValue <= 999999) TextOfValute.text = (ValuteController.BasicValue / 1000).ToString() + "k";
               if (ValuteController.BasicValue > 999999 && ValuteController.BasicValue <= 9999999) TextOfValute.text = Math.Round((double)ValuteController.BasicValue / (1000 * 1000),1) + "M";
               if (ValuteController.BasicValue > 9999999 && ValuteController.BasicValue <= 999999999) TextOfValute.text = (ValuteController.BasicValue / (1000 * 1000)) + "M";
               break;
           case Values.Billons:
              ConvertMoreHightValues(ValuteController.BillionValue,TextOfValute,"B","T","q");
               break;
           case Values.Quintillions:
           {
               ConvertMoreHightValues(ValuteController.QuintillionValue,TextOfValute,"Q","S","s");
           }
               break;
       }
   }

   public void ConvertMoreHightValues(int Value, Text TextOfValue, string Firstvalue, string SecondValue, string ThirdValue)
   {
       if (Value > 0 && Value <= 9) TextOfValue.text = Math.Round((double)Value,1) + Firstvalue;
       if (Value > 9 && Value <= 999) TextOfValue.text = (Value) + Firstvalue;
       if (Value > 999 && Value <= 9999) TextOfValue.text =  Math.Round((double)Value / 1000,1) + SecondValue;
       if (Value > 9999 && Value <= 999999) TextOfValue.text = (Value / 1000) + SecondValue;
       if (Value > 999999 && Value <= 9999999) TextOfValue.text =  Math.Round((double)Value / (1000 * 1000),1) + ThirdValue;
       if (Value > 9999999 && Value <= 999999999) TextOfValue.text = (Value / (1000 * 1000)).ToString() + ThirdValue;
   }
}