using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.Serialization;
using Random = UnityEngine.Random;

public class ValuteController : MonoBehaviour
{
    public FruitCoinsValuteController FruitCoins;
    public FruitDimondsValueController FruitDimonds;
    public MultiFruitCoinsValueController MultiFruitCoins;

    
    public IValuteController IFruitCoins;
    public IValuteController IFruitDimonds;
    public IValuteController IMultiFruitCoins;

    private void Start()
    {
        FruitCoins = GetComponent<FruitCoinsValuteController>();
        FruitDimonds = GetComponent<FruitDimondsValueController>();
        MultiFruitCoins = GetComponent<MultiFruitCoinsValueController>();
        
        IFruitCoins = GetComponent<FruitCoinsValuteController>();
        IFruitDimonds = GetComponent<FruitDimondsValueController>();
        IMultiFruitCoins = GetComponent<MultiFruitCoinsValueController>();
    }

    public void AddClickMulti(Valutes valute,int RewardMulti)
    {
        switch (valute)
        {
            case Valutes.FruitCoins:
                GetComponent<FruitCoinsValuteController>().MultiFromClick += RewardMulti;
                PlayerPrefs.SetInt("FruitCoinsClickMulti",  GetComponent<FruitCoinsValuteController>().MultiFromClick);
                break;
            case Valutes.FruitDimonds:
                GetComponent<FruitDimondsValueController>().MultiDimondsFromClick += RewardMulti;
                PlayerPrefs.SetInt("FruitDimondsClickMulti", GetComponent<FruitDimondsValueController>().MultiDimondsFromClick);
                break;
        }
    }

    public void TakeAnyValueOfValute(Valutes valute,Values Value,int price)
    {
        switch (valute)
        {
            case Valutes.FruitCoins:
                TakeAnyValue(IFruitCoins,Value,price);
                break;
            case Valutes.FruitDimonds:
                TakeAnyValue(IFruitDimonds,Value,price);
                break;
            case Valutes.MultiFruitCoins:
                TakeAnyValue(IMultiFruitCoins,Value,price);
                break;
        }
    }
    
    public void TakeAnyValue(IValuteController Valute,Values Value,int price)
    {
        switch (Value)
        {
            case Values.Basic:
                Valute.BasicValue += -price;
                PlayerPrefs.SetInt("FruitCoins", IFruitCoins.BasicValue);
                break;
            case Values.Billons:
                Valute.BillionValue += -price;
                PlayerPrefs.SetInt("FruitCoinsBillion", IFruitCoins.BillionValue);
                break;
            case Values.Quintillions:
                Valute.QuintillionValue += -price;
                PlayerPrefs.SetInt("FruitCoinsQuintillion", IFruitCoins.QuintillionValue);
                break;
        }
    }

    public void BuyUpgradeWithMultiForAnyValue(BuyButtons BuyButtons, Valutes valute, Values Value, int price, int multi)
    {
        switch (Value)
        {
            case Values.Basic:
                if (IFruitCoins.BasicValue > price)
                {
                    BuyButtons.CurrentLevel++;
                    TakeAnyValueOfValute(Valutes.FruitCoins, Value, price);
                    AddClickMulti(valute, multi);
                }

                break;
            case Values.Billons:
                if (IFruitCoins.BillionValue > price)
                {
                    BuyButtons.CurrentLevel++;
                    TakeAnyValueOfValute(Valutes.FruitCoins, Value, price);
                    AddClickMulti(valute, multi);
                }

                break;
            case Values.Quintillions:
                if (IFruitCoins.QuintillionValue > price)
                {
                    BuyButtons.CurrentLevel++;
                    TakeAnyValueOfValute(Valutes.FruitCoins, Value, price);
                    AddClickMulti(valute, multi);
                }
                break;
        }
    }

    public void BuyUpgradeWithoutMultiForAnyValue(BuyButtons BuyButtons,Valutes valute,Values Value,int price)
    {
        switch (valute)
        {
            case Valutes.FruitDimonds:
            {
                BuyButtons.CurrentLevel++;
                ChooseValueToTakeForUpgrades(valute,Value,price);
            } 
                break;
            case Valutes.MultiFruitCoins:
            {
                BuyButtons.CurrentLevel++;
                ChooseValueToTakeForUpgrades(valute,Value,price);
            } 
                break;
        }
    }

    public void ChooseValueToTakeForUpgrades(Valutes valute,Values Value,int price)
    {
        switch (Value)
        {
            case Values.Basic:
                TakeAnyValueOfValute(valute,Value,price);   
                break;
            case Values.Billons:
                TakeAnyValueOfValute(valute,Value,price);   
                break;
            case Values.Quintillions:
                TakeAnyValueOfValute(valute,Value,price);   
                break;
        }
    }
}

public enum Valutes
{
    FruitCoins,
    FruitDimonds,
    MultiFruitCoins
}

public interface IValuteController
{
    public int BasicValue { get; set; }
    
    public int BillionValue { get; set; }
    
    public int QuintillionValue { get; set; }
    
    public int MainMulti { get; set; }
    
    public int BillionMainMulti { get; set; }
    
    public int QuintillioniMainMulti { get; set; }
    
    public Values GetValuesOfValute();
    public void SetValuesOfValute(Values Value);

    public Values GetValuesOfMulti();

    public void SetValuesOfMulti(Values Value);
    
    public void AddValute();
}
