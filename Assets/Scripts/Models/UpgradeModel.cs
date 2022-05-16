using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[Serializable] public class UpgradeModel
{
  public string NameOfUpgrade;
  public string NameOfValute;
  
  public List<PriceOfUpgradeModel> Prices;
  public ValuesEnum[] ValuesOfUpgrade;
  public int CurrentPrice;
  
  public void SetNumberOfValuePrice()
  {
    for (int i = 0; i < Prices.Count; i++)
    {
      Prices[i].NumberOfValuePrice = (int)ValuesOfUpgrade.FirstOrDefault(value => Prices[i].Value == value); 
    }
  }
}