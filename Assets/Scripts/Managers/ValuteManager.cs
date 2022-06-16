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
   public TextConverter textConverter;
   public ValutesMathOperations valutesMathOperations;
   
   [Space]
   [Header("Seiazble Classes")]
   public ValutesModel [] Valutes;

   private void Update()
   {
      ControllValuesOfValute("Fruit Coins");
      ControllValuesOfValute("Fruit Dimonds");
      ControllValuesOfValute("MultiFruit Coins");
   }

   public ValutesModel GetValute(string ValuteName)
   {
      ValutesModel valutesModel = Valutes.FirstOrDefault(model => model.NameOfValute == ValuteName);
      return valutesModel;
   }
   
   public void ControllValuesOfValute(string ValuteName)
   {
      ValutesModel valutesModel = Valutes.FirstOrDefault(model => model.NameOfValute == ValuteName);
      
      textConverter.ConvertValuesToText(valutesModel.TextOfValute, valutesModel.Valute, "");
   }

   public void ResetValute(string valuteName)
   {
      ValutesModel valutesModel = Valutes.FirstOrDefault(model => model.NameOfValute == valuteName);

      valutesModel.Valute = 0;
      valutesModel.ValuteMultiplier = 1;
   }
}
