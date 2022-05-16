using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class ConvertTextForRebirth : MonoBehaviour
{
   // Needed Classes
   public BuyRebirth Rebirth;
   public FruitsController Fruits;
   // All Texts Of Rebirth Panel
   public Text TextForMultiOfFruits;
   public Text TextForCurrentFruit;
   public Text TextOfCountOfRebirth;
   public Text TextOfMultiFruitCoinsAfterPrestige;
   public Text TextOfMultiOfRebirth;
   public Text TextOfMultiFruitCoins;
   
   //Convert All values to Texts of Rebirth
   public void SetAllStatisticValues()
   {
      //ConvertAnyValueOfRebirthPanel(TextForMultiOfFruits, "Множитель Фруктов: ", FruitsCoins.MultiOfFruits);
      ConvertAnyValueOfRebirthPanel(TextOfCountOfRebirth, "Количевство перерождений: ", Rebirth.CountOfRebirth);
     //ConvertAnyValueOfRebirthPanel(TextOfMultiFruitCoins, "Множитель фрукткоинов: ", FruitsCoins.MultiFromClick);
      ConvertAnyStringValueOfStatisticPanel(TextForCurrentFruit, "Текущий фрукт: ",Fruits.CurrentFruitInString);
   }

   public void SetAllMainRebirthPanelValues()
   {
     // ConvertValuesWithTouch(TextOfMultiOfRebirth, "Множитель перерождений: ", FruitsCoins.MultiOfRebirth);
      //ConvertAnyValueOfRebirthPanel(TextOfMultiFruitCoinsAfterPrestige, "", MultiFruitCoins.MultiFruitCoinsAfterRebirth);
   }
   
   public void ConvertValuesWithTouch(Text TextMulti, String NameOfString, float multi)
   {
      if (multi <= 999) TextMulti.text = NameOfString + Math.Round(multi,1);
      if (multi > 999) TextMulti.text = NameOfString + Math.Round(multi / 1000, 1) + "k";
      if (multi > 999999) TextMulti.text = NameOfString + Math.Round(multi / (1000 * 1000), 1) + "M";
   }
   
   public void ConvertAnyValueOfRebirthPanel(Text TextMulti, String NameOfString, float multi)
   {
      if (multi <= 999) TextMulti.text = NameOfString + (int)multi;
      if (multi > 999) TextMulti.text = NameOfString + (int)(multi / 1000) + "k";
      if (multi > 999999) TextMulti.text = NameOfString + (int)(multi / (1000 * 1000)) + "M";
   }
   
   public void ConvertAnyStringValueOfStatisticPanel(Text TextStringValue, String NameOfString, String Value)
   {
      TextStringValue.text = NameOfString + Value;
   }
}
