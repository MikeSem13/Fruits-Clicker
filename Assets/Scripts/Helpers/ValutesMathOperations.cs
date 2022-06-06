using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Serialization;

public class ValutesMathOperations : MonoBehaviour
{
    private ValuteManager valuteManager;
    [SerializeField] private UpgradeManager upgradeManager;
    [SerializeField] private MathOperationsManager mathOperations;

    private void Start()
    {
        valuteManager = GetComponent<ValuteManager>();
    }

    public void AddValute(string ValuteName)
    {
        ValutesModel valuteModel = valuteManager.Valutes.FirstOrDefault(model => model.NameOfValute == ValuteName);

        foreach (var values in valuteModel.Values) mathOperations.add.AddValues(ref values.Valute, values.MultiOfValute);;
    }

    public void AddValuteWithChance(string ValuteName, float percent)
    {
        ValutesModel valuteModel = valuteManager.Valutes.FirstOrDefault(model => model.NameOfValute == ValuteName);
        
        foreach (var values in valuteModel.Values) mathOperations.add.AddValuesWithChance(ref values.Valute, values.MultiOfValute, percent);
    }

    public void AddMulti(string ValuteName, string UpgradeName)
    {
        ValutesModel valuteModel = valuteManager.Valutes.FirstOrDefault(model => model.NameOfValute == ValuteName);
        UpgradeModel upgradeModel = upgradeManager.Upgrades.FirstOrDefault(model => model.NameOfUpgrade == UpgradeName);

        foreach (var values in valuteModel.Values) mathOperations.add.AddValues(ref values.MultiOfValute, upgradeModel.RewardMultis[upgradeModel.CurrentPrice].RewardMulti);
    }
    
    public void TakeValuteForUpgrade(string valuteName, PriceOfUpgradeModel price, UpgradeModel upgrade)
    {
        ValutesModel valuteModel = valuteManager.Valutes.FirstOrDefault(model => model.NameOfValute == valuteName);
      
        mathOperations.take.TakeValues(ref valuteModel.Values[upgrade.Prices[upgrade.CurrentPrice].NumberOfValuePrice].Valute, price.Price);
        AccountLastPrice(valuteModel, price, upgrade);
    }
    
    public void TakeFromFarValutes(string ValuteName, PriceOfUpgradeModel price, UpgradeModel upgrade, ref bool reward)
    {
        ValutesModel valuteModel = valuteManager.Valutes.FirstOrDefault(model => model.NameOfValute == ValuteName);
       
        for (int i = upgrade.Prices[upgrade.CurrentPrice].NumberOfValuePrice + 1; i < valuteModel.Values.Length; i++)
        {
            if (valuteModel.Values[i].Valute >= 1)
            {
                if (i == upgrade.Prices[upgrade.CurrentPrice].NumberOfValuePrice + 1)
                {
                    mathOperations.take.TakeValues(ref valuteModel.Values[i].Valute, 1);
                    mathOperations.add.AddValues(ref valuteModel.Values[i - 1].Valute, 1000 - price.Price);
                    AccountLastPrice(valuteModel, upgrade.Prices[upgrade.CurrentPrice], upgrade);
                }
                else
                {
                    
                    mathOperations.take.TakeValues(ref valuteModel.Values[i].Valute, 1);
                    for (int j = i - 1; j > upgrade.Prices[upgrade.CurrentPrice].NumberOfValuePrice; j--)
                    {
                        mathOperations.add.AddValues(ref valuteModel.Values[j].Valute, 999);
                    }
                    mathOperations.add.AddValues(ref valuteModel.Values[upgrade.Prices[upgrade.CurrentPrice].NumberOfValuePrice].Valute, 1000 - price.Price);
                    AccountLastPrice(valuteModel, upgrade.Prices[upgrade.CurrentPrice], upgrade);
                }
                reward = true;
            }
        }
    }
    
    public void AccountLastPrice(ValutesModel valuteModel, PriceOfUpgradeModel price, UpgradeModel Upgrade)
    {
        if (price.LastPrice > 0)
        {
            if (valuteModel.Values[Upgrade.Prices[Upgrade.CurrentPrice].NumberOfValuePrice - 1].Valute > price.LastPrice)
            {
                valuteModel.Values[Upgrade.Prices[Upgrade.CurrentPrice].NumberOfValuePrice - 1].Valute -= price.LastPrice;
            }
            else
            {
                valuteModel.Values[Upgrade.Prices[Upgrade.CurrentPrice].NumberOfValuePrice].Valute -= 1;
                valuteModel.Values[Upgrade.Prices[Upgrade.CurrentPrice].NumberOfValuePrice - 1].Valute = ((1000 + valuteModel.Values[Upgrade.Prices[Upgrade.CurrentPrice].NumberOfValuePrice - 1].Valute) - price.LastPrice);
            }
        }
    }
}
