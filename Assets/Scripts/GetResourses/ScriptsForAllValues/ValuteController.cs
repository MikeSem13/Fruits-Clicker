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
}

public enum Valutes
{
    FruitCoins,
    FruitDimonds,
    MultiFruitCoins
}

public interface IValuteController
{
    public float BasicValue { get; set; }
    
    public float BillionValue { get; set; }
    
    public float QuintillionValue { get; set; }
    
    public float MainMulti { get; set; }
    
    public float BillionMainMulti { get; set; }
    
    public float QuintillioniMainMulti { get; set; }
    
    public Values GetValuesOfValute();
    public void SetValuesOfValute(Values Value);

    public Values GetValuesOfMulti();

    public void SetValuesOfMulti(Values Value);
    
    public void AddValute();
}
