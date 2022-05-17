using System;
using System.Collections;
using UnityEngine;
using System.Collections.Generic;
using System.Linq;
using UnityEngine.Serialization;
using UnityEngine.UI;

[Serializable] public class PriceOfUpgradeModel
{
   [Header("Цена")]
   public float Price;
   
   [Space]
   [Header("Размерность цены")]
   public ValuesEnum PriceValue;
   
   [Space]
   [Header("Дополнительные параметры")]
   public int NumberOfValuePrice;
}
