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
                ConvertToNextValues(Valutes.IFruitCoins);
            }
                break;
            case global::Valutes.FruitDimonds:
            {
                ConvertToNextValues(Valutes.IFruitDimonds);
            }
                break;
            case global::Valutes.MultiFruitCoins:
            {
                ConvertToNextValues(Valutes.IMultiFruitCoins);
            }
                break;
        }
    }
    
    public void ConvertToNextValues(IValuteController Valute)
    {
        if (Valute.BasicValue >= BoardOfAddValutes)
        {
            Valute.BillionValue += 1;
            Valute.BasicValue -= BoardOfAddValutes;
        }
        if (Valute.BillionValue >= BoardOfAddValutes)
        { 
            Valute.QuintillionValue += 1; 
            Valute.BillionValue -= BoardOfAddValutes;
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
        if (ValuteController.BillionValue == 0) ValuteController.SetValuesOfValute(Values.Basic);
        if (ValuteController.BillionValue > 0) ValuteController.SetValuesOfValute(Values.Billons);
        if (ValuteController.QuintillionValue > 0) ValuteController.SetValuesOfValute(Values.Quintillions);
    }
}

public enum Values
{
    Basic,
    Billons,
    Quintillions
}