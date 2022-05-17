using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class AccountValutesValriables : MonoBehaviour
{
  private ValuteManager _valuteManager;

  private void Start()
  {
    _valuteManager = GetComponent<ValuteManager>();
  }

  public void AddValute(string ValuteName)
  {
    ValutesModel valuteModel = _valuteManager.Valutes.FirstOrDefault(model => model.NameOfValute == ValuteName);

    for (int i = 0; i <= valuteModel.NumberOfMulti; i++)
    {
      valuteModel.Values[i].Valute += valuteModel.Values[i].MultiOfValute;
      PlayerPrefs.SetFloat(i + "Valute", valuteModel.Values[i].Valute);
    }
  }

  public void AddMulti(string ValuteName, UpgradeModel Upgrade)
  {
      ValutesModel valuteModel = _valuteManager.Valutes.FirstOrDefault(model => model.NameOfValute == ValuteName);

      valuteModel.Values[Upgrade.Multis[Upgrade.CurrentPrice].NumberOfValueMulti].MultiOfValute += Upgrade.Multis[Upgrade.CurrentPrice].Multi;
      PlayerPrefs.SetFloat("Multi", valuteModel.Values[Upgrade.Multis[Upgrade.CurrentPrice].NumberOfValueMulti].MultiOfValute);
  }
  
  public void TakeValuteForReward(string ValuteName, float price, UpgradeModel Upgrade)
  {
      ValutesModel valuteModel = _valuteManager.Valutes.FirstOrDefault(model => model.NameOfValute == ValuteName);
      
      if (valuteModel.Values[Upgrade.Prices[Upgrade.CurrentPrice].NumberOfValuePrice].Valute >= price)
      {
          valuteModel.Values[Upgrade.Prices[Upgrade.CurrentPrice].NumberOfValuePrice].Valute -= price;
          AddMulti(ValuteName, Upgrade);
          Upgrade.CurrentPrice++;
          PlayerPrefs.SetInt("PriceOfUpgrade", Upgrade.CurrentPrice);
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
                  AddMulti(ValuteName, Upgrade);
                  Upgrade.CurrentPrice++;
                  PlayerPrefs.SetInt("PriceOfUpgrade", Upgrade.CurrentPrice);
              }
          }
      }
  }
}
