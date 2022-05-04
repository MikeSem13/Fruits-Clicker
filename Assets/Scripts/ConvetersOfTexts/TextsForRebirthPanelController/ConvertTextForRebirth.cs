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
   public MultiFruitCoinsValueController MultiFruitCoins;
   public FruitCoinsValuteController FruitsCoins;

   // All Texts Of Rebirth Panel
   public Text TextForMultiOfFruits;
   public Text TextForCurrentFruit;
   public Text TextOfCountOfRebirth;
   public Text TextOfMultiFruitCoinsAfterPrestige;
   public Text TextOfMultiOfRebirth;
   public Text TextOfMultiFruitCoins;
   
   //Convert All values to Texts of Rebirth
   private void Update()
   {
      ConvertAnyValueOfStatisticPanel(TextForMultiOfFruits, "Множитель Фруктов: ", FruitsCoins.MultiOfFruits);
      ConvertAnyValueOfStatisticPanel(TextOfCountOfRebirth, "Количевство перерождений: ", Rebirth.CountOfRebirth);
      ConvertValuesWithTouch(TextOfMultiOfRebirth, "Множитель перерождений: ", FruitsCoins.MultiOfRebirth);
      ConvertAnyValueOfStatisticPanel(TextOfMultiFruitCoins, "Множитель фрукткоинов: ", FruitsCoins.MultiFromClick);
      ConvertAnyValueOfStatisticPanel(TextOfMultiFruitCoinsAfterPrestige, "", MultiFruitCoins.MultiFruitCoinsAfterRebirth);
      ConvertAnyStringValueOfStatisticPanel(TextForCurrentFruit, "Текущий фрукт: ",Fruits.CurrentFruitInString);
   }

   public void ConvertValuesWithTouch(Text TextMulti, String NameOfString, float multi)
   {
      if (multi <= 999) TextMulti.text = NameOfString + Math.Round(multi, 2);
      if (multi > 999 && multi <= 999999) TextMulti.text = NameOfString + Math.Round(multi / 1000, 2) + "k";
      if (multi > 999999 && multi <= 999999999) TextMulti.text = NameOfString + Math.Round(multi / (1000 * 1000), 2) + "M";
   }
   
   public void ConvertAnyValueOfStatisticPanel(Text TextMulti, String NameOfString, float multi)
   {
      if (multi <= 999) TextMulti.text = NameOfString + multi;
      if (multi > 999 && multi <= 999999) TextMulti.text = NameOfString + (multi / 1000) + "k";
      if (multi > 999999 && multi <= 999999999) TextMulti.text = NameOfString + (multi / (1000 * 1000)) + "M";
   }
   
   public void ConvertAnyStringValueOfStatisticPanel(Text TextStringValue, String NameOfString, String Value)
   {
      TextStringValue.text = NameOfString + Value;
   }
}
