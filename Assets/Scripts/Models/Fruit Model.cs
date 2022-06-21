using System;
using UnityEngine;

[Serializable] public class FruitModel
{
   [Header("Название фрукта")]
   public string FruitName;

   [Space]
   [Header("Цена фрукта")]
   public PriceModel Price;
   
   [Header("Состояния фрукта")]
   public bool IsBuy;
   public bool IsSelected;
   public bool IsAwaking;

   [Space]
   [Header("Спрайты фрукта")]
   public Sprite BasicFruit;
   public Sprite GoldFruit;
   public Sprite DiamondFruit;

   
}
