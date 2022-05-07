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
               if (ValuteController.BasicValue < 1000) TextOfValute.text = ValuteController.BasicValue.ToString("0");
               if (ValuteController.BasicValue >= 1000) TextOfValute.text = (ValuteController.BasicValue / 1000).ToString("#.#") + "k";
               if (ValuteController.BasicValue >= 10000) TextOfValute.text = (ValuteController.BasicValue / 1000).ToString("0") + "k";
               if (ValuteController.BasicValue >= 999500) TextOfValute.text = (ValuteController.BasicValue / (1000 * 1000)).ToString("#.#") + "M";
               if (ValuteController.BasicValue >= 10000000) TextOfValute.text = (ValuteController.BasicValue / (1000 * 1000)).ToString("0") + "M";
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

   public void ConvertMoreHightValues(float Value, Text TextOfValue, string Firstvalue, string SecondValue, string ThirdValue)
   {
       if (Value >= 1) TextOfValue.text = Value.ToString("#.#") + Firstvalue;
       if (Value >= 10) TextOfValue.text = (Value).ToString("0") + Firstvalue;
       if (Value >= 1000) TextOfValue.text =  (Value / 1000).ToString("#.#") + SecondValue;
       if (Value >= 10000) TextOfValue.text = (Value / 1000).ToString("0") + SecondValue;
       if (Value >= 999500) TextOfValue.text = (Value / (1000 * 1000)).ToString("#.#") + ThirdValue;
       if (Value >= 10000000) TextOfValue.text = (Value / (1000 * 1000)).ToString("0") + ThirdValue;
   }
}