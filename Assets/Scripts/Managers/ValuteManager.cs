using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ValuteManager : MonoBehaviour
{
   public List<ValutesModel> Valutes;

   private void Update()
   {
      ControllValuesOfValute("Fruit Coins");
      ControllValuesOfValute("Fruit Dimonds");
      ControllValuesOfValute("MultiFruit Coins");
   }

   public void ControllValuesOfValute(string ValuteName)
   {
      ValutesModel valutesModel = Valutes.FirstOrDefault(model => model.NameOfValute == ValuteName);
      
      ValueControll(valutesModel);
      ConvertValuteToText(valutesModel);
   }

   public void ValueControll(ValutesModel valutesModel)
   {
      for (int i = 0; i < valutesModel.Values.Count - 1; i++)
      {
         if (valutesModel.Values[i].Valute >= 1000)
         {
            valutesModel.Values[i].Valute -= 1000;
            valutesModel.Values[i + 1].Valute++;
            if (i == valutesModel.NumberOfValue) valutesModel.NumberOfValue++;
         }
      }

      if (valutesModel.Values[valutesModel.NumberOfValue].Valute <= 0 && valutesModel.NumberOfValue > 0)
      {
         valutesModel.NumberOfValue--;
      }
   }


   public void ConvertValuteToText(ValutesModel valutesModel)
   {
      for (int i = 0; i < valutesModel.TextsOfValute.Count; i++)
      {
          if (valutesModel.Values[valutesModel.NumberOfValue].Valute >= 0 && valutesModel.NumberOfValue == 0)
          {
             valutesModel.TextsOfValute[i].text = valutesModel.Values[valutesModel.NumberOfValue].Valute + valutesModel.SybwolsOfValue[valutesModel.NumberOfValue];  
          }
               
          if (valutesModel.Values[valutesModel.NumberOfValue].Valute >= 0 && valutesModel.NumberOfValue > 0 && valutesModel.Values[valutesModel.NumberOfValue - 1].Valute / 100 >= 1)
          {
             valutesModel.TextsOfValute[i].text = valutesModel.Values[valutesModel.NumberOfValue].Valute + "." + Mathf.Floor(valutesModel.Values[valutesModel.NumberOfValue - 1].Valute / 100) + valutesModel.SybwolsOfValue[valutesModel.NumberOfValue];
          }
               
          if (valutesModel.Values[valutesModel.NumberOfValue].Valute >= 0 && valutesModel.NumberOfValue > 0 && valutesModel.Values[valutesModel.NumberOfValue - 1].Valute / 100 < 1)
          {
             valutesModel.TextsOfValute[i].text = valutesModel.Values[valutesModel.NumberOfValue].Valute + valutesModel.SybwolsOfValue[valutesModel.NumberOfValue];
          }
               
          if (valutesModel.Values[valutesModel.NumberOfValue].Valute >= 10)
          {
             valutesModel.TextsOfValute[i].text = valutesModel.Values[valutesModel.NumberOfValue].Valute + valutesModel.SybwolsOfValue[valutesModel.NumberOfValue];  
          }
      }
   }
}
