using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class ValuteManager : MonoBehaviour
{
   public DemisionsOfValutes DemisionsOfValutes;
   
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
      
      ValueControll(valutesModel);
      MultiControll(valutesModel);
      ConvertValuteToText(valutesModel);
   }

   public void ValueControll(ValutesModel valutesModel)
   {
      for (int i = 0; i < valutesModel.Values.Length; i++)
      {
         if (valutesModel.Values[i].Valute > 0)
         {
            valutesModel.NumberOfValue = Array.IndexOf(valutesModel.Values, valutesModel.Values[i]);
         }
         
         if (valutesModel.Values[i].Valute >= 1000 && i != valutesModel.Values.Length - 1)
         {
            valutesModel.Values[i].Valute -= 1000;
            valutesModel.Values[i + 1].Valute += 1;
         }
      }
   }

   public void MultiControll(ValutesModel valutesModel)
   {
      for (int i = 0; i < valutesModel.Values.Length; i++)
      {
         if (valutesModel.Values[i].MultiOfValute > 0)
         {
            valutesModel.NumberOfMulti = Array.IndexOf(valutesModel.Values, valutesModel.Values[i]);
         }
         
         if (valutesModel.Values[i].MultiOfValute >= 1000 && i != valutesModel.Values.Length - 1)
         {
            valutesModel.Values[i].MultiOfValute -= 1000;
            valutesModel.Values[i + 1].MultiOfValute += 1;
         }
      }

    
   }
   
   public void ConvertValuteToText(ValutesModel valutesModel)
   {

      if (valutesModel.Values[valutesModel.NumberOfValue].Valute >= 0 && valutesModel.NumberOfValue == 0)
      {
         valutesModel.TextOfValute.text = valutesModel.Values[valutesModel.NumberOfValue].Valute + DemisionsOfValutes.SybwolsOfValutes[valutesModel.NumberOfValue].Sybwol;  
      }
               
      if (valutesModel.Values[valutesModel.NumberOfValue].Valute >= 0 && valutesModel.NumberOfValue > 0 && valutesModel.Values[valutesModel.NumberOfValue - 1].Valute / 100 >= 1)
      {
         valutesModel.TextOfValute.text = valutesModel.Values[valutesModel.NumberOfValue].Valute + "." + Mathf.Floor(valutesModel.Values[valutesModel.NumberOfValue - 1].Valute / 100) + DemisionsOfValutes.SybwolsOfValutes[valutesModel.NumberOfValue];
      }
               
      if (valutesModel.Values[valutesModel.NumberOfValue].Valute >= 0 && valutesModel.NumberOfValue > 0 && valutesModel.Values[valutesModel.NumberOfValue - 1].Valute / 100 < 1)
      {
         valutesModel.TextOfValute.text = valutesModel.Values[valutesModel.NumberOfValue].Valute + DemisionsOfValutes.SybwolsOfValutes[valutesModel.NumberOfValue].Sybwol;
      }
               
      if (valutesModel.Values[valutesModel.NumberOfValue].Valute >= 10)
      {
         valutesModel.TextOfValute.text = valutesModel.Values[valutesModel.NumberOfValue].Valute + DemisionsOfValutes.SybwolsOfValutes[valutesModel.NumberOfValue].Sybwol;  
      }
   }
}
