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

    public void AddValute(string ValuteName, double addValue)
    {
        ValutesModel valuteModel = valuteManager.Valutes.FirstOrDefault(model => model.NameOfValute == ValuteName);

        mathOperations.add.AddValues(ref valuteModel.Valute, addValue);;
    }

    public void AddValuteWithChance(string ValuteName, double addValue , double percent)
    {
        ValutesModel valuteModel = valuteManager.Valutes.FirstOrDefault(model => model.NameOfValute == ValuteName);
        
        mathOperations.add.AddValuesWithChance( ref valuteModel.Valute, addValue, percent);
    }

    public void AddMultiplierBoost(string valuteName,string boostName, string UpgradeName)
    {
        ValutesModel valuteModel = valuteManager.Valutes.FirstOrDefault(model => model.NameOfValute == valuteName);
        UpgradeModel upgradeModel = upgradeManager.Upgrades.FirstOrDefault(model => model.NameOfUpgrade == UpgradeName);

        mathOperations.add.AddValues(ref valuteModel.GetMultiBoost(boostName).Boost, upgradeModel.RewardMultis[upgradeModel.CurrentPrice].RewardMulti);
    }
    
    public void TakeValute(string valuteName, PriceModel price)
    {
        ValutesModel valuteModel = valuteManager.Valutes.FirstOrDefault(model => model.NameOfValute == valuteName);
      
        mathOperations.take.TakeValues(ref valuteModel.Valute, price.Price);
    }
}
