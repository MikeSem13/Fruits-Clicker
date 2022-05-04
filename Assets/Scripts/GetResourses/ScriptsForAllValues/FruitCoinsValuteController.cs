using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UIElements.Experimental;

public class FruitCoinsValuteController : MonoBehaviour, IValuteController
{
    [Header("Тип Валюты")] 
    public Valutes Valute;
    
    public Values CurrentValue;
    public Values CurrentValueOfMulti;

    [Header("Размеры валют")]
    [SerializeField]private float basicValue;
    [SerializeField]private float billionValue;
    [SerializeField]private float quintillionValue;
    
    [Header("Размеры множителей")]
    [SerializeField]private float mainMulti;
    [SerializeField]private float BillionmainMulti;
    [SerializeField]private float QuintillionmainMulti;

    public float BasicValue
    {
        get { return basicValue; }
        set
        {
            basicValue = value;

            if (basicValue < 0) basicValue = 0;
        }
    }

    public float BillionValue
    {
        get { return billionValue;}
        set
        {
            billionValue = value;
            if (billionValue < 0) billionValue = 0;
        }
    }

    public float QuintillionValue
    {
        get { return quintillionValue; }
        set
        {
            quintillionValue = value;

            if (quintillionValue < 0) quintillionValue = 0;
        }
    }

    public float MainMulti
    {
        get { return mainMulti; }
        set
        {
            mainMulti = value;
            if (mainMulti < 0) mainMulti = 0;
        }
    }
    
    public float BillionMainMulti
    {
        get { return BillionmainMulti; }
        set
        {
            BillionmainMulti = value;
            if (BillionmainMulti < 0) BillionmainMulti = 0;
        }
    }
    
    public float QuintillioniMainMulti
    {
        get { return QuintillionmainMulti; }
        set
        {
            QuintillionmainMulti = value;
            if (QuintillionmainMulti < 0) QuintillionmainMulti = 0;
        }
    }

    [Header("Множители для фрукткоинов")]
    
    public int MultiFromClick;
    public int MultiOfBonus;
    public int MultiOfRebirth;
    public int MultiOfFruits;
    public int MultiOfGoldOrDimondsFruits;
    public int MultiFromAwakingFruitCoins;

    private void Start()
    {
        BasicValue = PlayerPrefs.GetInt("FruitCoins");
        BillionValue = PlayerPrefs.GetInt("FruitCoinsBillion");
        QuintillionValue = PlayerPrefs.GetInt("FruitCoinsQuintillion");
        
        MainMulti = PlayerPrefs.GetInt("FruitCoinsMulti");
        MultiFromClick = PlayerPrefs.GetInt("FruitCoinsClickMulti");
        MultiOfBonus = PlayerPrefs.GetInt("FruitCoinsBonusMulti");
        MultiOfRebirth = PlayerPrefs.GetInt("FruitCoinsRebirthMulti");
        MultiOfFruits = PlayerPrefs.GetInt("FruitCoinsFruitMulti");
        MultiOfGoldOrDimondsFruits = PlayerPrefs.GetInt("FruitCoinsGoldAndDimondsMulti");
        MultiFromAwakingFruitCoins = PlayerPrefs.GetInt("FruitCoinsAwakingMulti");

        CheckMultis();
    }

    private void Update()
    {
        SetMainMultiFruitCoins();
    }

    public void SetMainMultiFruitCoins()
    {
        MainMulti = MultiFromClick * MultiOfBonus * MultiOfRebirth * MultiOfFruits * MultiOfGoldOrDimondsFruits * MultiFromAwakingFruitCoins;
    }

    public void ResetAllFruitCoinsAndMultiForRebirth()
    {
        BasicValue = 0;
        BillionValue = 0;
        QuintillionValue = 0;
        
        MultiFromClick = 1;
    }
    
    public void CheckMultis()
    {
        if (MultiFromClick == 0) MultiFromClick = 1;
        if (MultiOfBonus == 0) MultiOfBonus = 1;
        if (MultiOfRebirth == 0) MultiOfRebirth = 1;
        if (MultiOfFruits == 0) MultiOfFruits = 1;
        if (MultiOfGoldOrDimondsFruits == 0) MultiOfGoldOrDimondsFruits = 1;
        if (MultiFromAwakingFruitCoins == 0) MultiFromAwakingFruitCoins = 1;
    }

    public Values GetValuesOfValute()
    {
        return CurrentValue;
    }

    public void SetValuesOfValute(Values Value)
    {
        CurrentValue = Value;
    }

    public Values GetValuesOfMulti()
    {
        return CurrentValueOfMulti;
    }

    public void SetValuesOfMulti(Values Value)
    {
        CurrentValueOfMulti = Value;
    }

    public void AddValute()
    {
        BasicValue += (int)MainMulti; 
        PlayerPrefs.SetFloat("FruitCoins", BasicValue);
        PlayerPrefs.SetFloat("FruitCoinsBillion", BillionValue);
        PlayerPrefs.SetFloat("FruitCoinsQuintillion", QuintillionValue);
    }
}