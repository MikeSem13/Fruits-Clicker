using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class AccountValutes : MonoBehaviour
{
  private ValuteManager ValuteManager;

  private void Start()
  {
    ValuteManager = GetComponent<ValuteManager>();
  }

  public void AddValute(string ValuteName)
  {
    ValutesModel valuteModel = ValuteManager.Valutes.FirstOrDefault(model => model.NameOfValute == ValuteName);

    for (int i = 0; i >= valuteModel.NumberOfMulti; i--)
    {
      valuteModel.Values[i].Valute += valuteModel.Values[i].MultiOfValue;
    }
  }

  public void TakeValute(string ValuteName, float price, UpgradeModel Upgrade)
  {
      ValutesModel valuteModel = ValuteManager.Valutes.FirstOrDefault(model => model.NameOfValute == ValuteName);
      
      if (valuteModel.Values[Upgrade.Prices[Upgrade.CurrentPrice].NumberOfValuePrice].Valute >= price)
      {
          valuteModel.Values[Upgrade.Prices[Upgrade.CurrentPrice].NumberOfValuePrice].Valute -= price;
          Upgrade.CurrentPrice++;
      }
      else
      {
          for (int i = Upgrade.Prices[Upgrade.CurrentPrice].NumberOfValuePrice + 1; i < valuteModel.Values.Count; i++)
          {
              if (valuteModel.Values[i].Valute >= 1)
              {
                  if (i <= valuteModel.NumberOfValue + 1)
                  {
                      valuteModel.Values[i].Valute--;
                      valuteModel.Values[i - 1].Valute += (1000 - price);
                  }
                  if (i > valuteModel.NumberOfValue + 1)
                  {
                      for (int j = i; j >= Upgrade.Prices[Upgrade.CurrentPrice].NumberOfValuePrice; j--)
                      {
                          if (j == i) valuteModel.Values[j].Valute--;
                          if (j < i && j != Upgrade.Prices[Upgrade.CurrentPrice].NumberOfValuePrice) valuteModel.Values[j].Valute += 999;
                          if (j == Upgrade.Prices[Upgrade.CurrentPrice].NumberOfValuePrice) valuteModel.Values[j].Valute += price;
                      }
                  }
                  Upgrade.CurrentPrice++;
              }
          }
      }
  }
}
