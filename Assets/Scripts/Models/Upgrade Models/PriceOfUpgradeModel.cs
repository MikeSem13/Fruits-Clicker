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
   public float LastPrice;
   
   [Space]
   [Header("Размерность цены")]
   public ValuesEnum Value;


   public int NumberOfValuePrice;
}
