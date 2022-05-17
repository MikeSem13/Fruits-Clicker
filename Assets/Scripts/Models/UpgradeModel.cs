using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

[Serializable] public class UpgradeModel
{
  [Header("Название апгрейда")]
  public string NameOfUpgrade;
  [Space]
  [Header("Название размерности апгрейда")]
  public string NameOfValute;
  
  [Space]
  [Header("Цены")]
  public List<PriceOfUpgradeModel> Prices;

  [Space] 
  [Header("Множитель")] 
  public List<RewardMultiOfUpgradeModel> Multis;
  
  [Space]
  [Header("Дополнительные параметры")]
  public ValuesEnum[] ValuesOfUpgrade;
  public List<string> SybwolsOfValue;
  public int CurrentPrice;
  
  [Space]
  [Header("Текста")]
  public Text TextOfPrice;
  public Text TextOfMulti;
  public void SetNumberOfPrice()
  {
    for (int i = 0; i < Prices.Count; i++)
    {
      Prices[i].NumberOfValuePrice = (int)ValuesOfUpgrade.FirstOrDefault(value => Prices[i].PriceValue == value); 
    }
  }
  
  public void SetNumberOfMulti()
  {
    for (int i = 0; i < Multis.Count; i++)
    {
      Multis[i].NumberOfValueMulti = (int)ValuesOfUpgrade.FirstOrDefault(value => Multis[i].RewardMultiValue == value); 
    }
  }
}