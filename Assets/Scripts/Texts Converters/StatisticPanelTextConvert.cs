using System;
using UnityEngine;
using UnityEngine.UI;

[Serializable] public class StatisticPanelTextConver
{
   [Header("Классы")]
   [SerializeField] private TextConvertManager textConvertManager;
   [SerializeField] private ValuteManager valuteManager;
   [SerializeField] private RebirthManager rebirthManager;
   [SerializeField] private FruitsManager fruitsManager;

   [Space]
   [Header("Текста")]

   [SerializeField] private Text fruitsMultiprierText;
   [SerializeField] private Text selectedFruitText;
   [SerializeField] private Text rebirthCountText;
   [SerializeField] private Text fruitCoinsMultiprierText;

   public void ConvertStatisticValuesToText()
   {
       textConvertManager.ValuesToText.ConvertValueToText(fruitsMultiprierText, valuteManager.GetValute("Fruit Coins").GetMultiBoost("Fruits Boost").Boost, "");
       textConvertManager.ValuesToText.ConvertValueToText(rebirthCountText, rebirthManager.Rebirths, "");
       textConvertManager.ValuesToText.ConvertValueToText(fruitCoinsMultiprierText, valuteManager.GetValute("Fruit Coins").ValuteMultiplier, "");
       selectedFruitText.text = selectedFruitText.text.ToString() + fruitsManager.SelectedFruit.FruitName;
   }
}
