using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class ValuteManager : MonoBehaviour
{
   [Header("Классы")]
   public TextConvertManager TextConvertManager;
   public ValutesMathOperations valutesMathOperations;
   
   [Space]
   [Header("Seiazble Classes")]
   public ValutesModel [] Valutes;

   private void Update()
   {
      ConvertValuteToText("Fruit Coins");
      ConvertValuteToText("Fruit Dimonds");
      ConvertValuteToText("MultiFruit Coins");
   }

   public ValutesModel GetValute(string ValuteName)
   {
      ValutesModel valutesModel = Valutes.FirstOrDefault(model => model.NameOfValute == ValuteName);
      return valutesModel;
   }
   
   public void ConvertValuteToText(string ValuteName)
   {
      ValutesModel valutesModel = Valutes.FirstOrDefault(model => model.NameOfValute == ValuteName);
      
      TextConvertManager.ValuesToText.ConvertValueToText(valutesModel.TextOfValute, valutesModel.Valute, "");
   }

   public void ResetValute(string valuteName, string nameOfBoost)
   {
      ValutesModel valutesModel = Valutes.FirstOrDefault(model => model.NameOfValute == valuteName);
      MultiplierBoostModel multiplierBoost = valutesModel.MultiplierBoosts.FirstOrDefault(boost => boost.NameOfBoost == nameOfBoost);

      valutesModel.Valute -= valutesModel.Valute;
      multiplierBoost.Boost -= multiplierBoost.Boost - 1;
   }
}
