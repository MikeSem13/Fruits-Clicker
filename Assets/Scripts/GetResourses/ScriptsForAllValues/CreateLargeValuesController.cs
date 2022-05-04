using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class CreateLargeValuesController : MonoBehaviour
{
    public ValuteController Valutes;

    public int BoardOfAddValutes;

    private void FixedUpdate()
    {
       AllControllsOfConvetValues();
    }

    public void AllControllsOfConvetValues()
    {
        AllConvertsOfValues();
        AllControllersOfTypesValue();
        ControllTypeOfValueAnyValute(Valutes.IFruitCoins);
    }

    public void AllControllersOfTypesValue()
    {
        ControllValueOfValute(Valutes.FruitCoins.Valute);
        ControllValueOfValute(Valutes.FruitDimonds.Valute);
        ControllValueOfValute(Valutes.MultiFruitCoins.Valute);
    }
    
    public void AllConvertsOfValues()
    {
        ConvertValueOfValuteToNext(Valutes.FruitCoins.Valute);
        ConvertValueOfValuteToNext(Valutes.FruitDimonds.Valute);
        ConvertValueOfValuteToNext(Valutes.MultiFruitCoins.Valute);
    }

    public void ConvertValueOfValuteToNext(Valutes valute)
    {
        switch (valute)
        {
            case global::Valutes.FruitCoins:
            {
                StartOfConvertToNextValues(Valutes.IFruitCoins);
                ConvertAfterStartNextValues(Valutes.FruitCoins);
            }
                break;
            case global::Valutes.FruitDimonds:
            {
                StartOfConvertToNextValues(Valutes.IFruitDimonds);
                ConvertAfterStartNextValues(Valutes.FruitDimonds);
            }
                break;
            case global::Valutes.MultiFruitCoins:
            {
                StartOfConvertToNextValues(Valutes.IMultiFruitCoins);
                ConvertAfterStartNextValues(Valutes.MultiFruitCoins);
            }
                break;
        }
    }
    
    
    public void StartOfConvertToNextValues(IValuteController Valute)
    {
        if (Valute.BasicValue >= BoardOfAddValutes && Valute.BillionValue < 1)
        {
            Valute.BillionValue += 1;
            Valute.BasicValue -= BoardOfAddValutes;
        }
        if (Valute.BillionValue >= BoardOfAddValutes && Valute.QuintillionValue < 1)
        { 
            Valute.QuintillionValue += 1; 
            Valute.BillionValue -= BoardOfAddValutes;
        }
    }

    public void ConvertAfterStartNextValues(IValuteController Valute)
    {
        if (Valute.BillionValue >= 1)
        {
            if (Valute.BasicValue >= 100000000)
            {
                Valute.BillionValue += 0.1f;
                Valute.BasicValue += -100000000;
            }
        }
        if (Valute.QuintillionValue >= 1)
        {
            if (Valute.BillionValue >= 100000000)
            {
                Valute.QuintillionValue += 0.1f;
                Valute.BillionValue += -100000000;
            }
        }
    }
    
    public void ControllValueOfValute(Valutes Valute)
    {
        switch (Valute)
        {
            case global::Valutes.FruitCoins:
                ControllTypeOfValueAnyValute(Valutes.IFruitCoins);
                break;
            case global::Valutes.FruitDimonds:
                ControllTypeOfValueAnyValute(Valutes.IFruitDimonds);
                break;
            case global::Valutes.MultiFruitCoins:
                ControllTypeOfValueAnyValute(Valutes.IMultiFruitCoins);
                break;
        }
    }
    
    public void ControllTypeOfValueAnyValute(IValuteController ValuteController)
    {
        // FruitСoins Values
        if (ValuteController.BillionValue < 1) ValuteController.SetValuesOfValute(Values.Basic);
        if (ValuteController.BillionValue >= 1) ValuteController.SetValuesOfValute(Values.Billons);
        if (ValuteController.QuintillionValue >= 1) ValuteController.SetValuesOfValute(Values.Quintillions);
    }
}

public enum Values
{
    Basic,
    Billons,
    Quintillions
}