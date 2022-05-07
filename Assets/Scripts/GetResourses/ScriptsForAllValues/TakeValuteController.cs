using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakeValuteController : MonoBehaviour
{
    public ValuteController Valute;

    private int _differenceOfValues = 1000000000;
    
    public void TakeAnyValueOfValute(Valutes valute,Values ValueOfValute,Values ValueOfPrice,int price)
    {
        switch (valute)
        {
            case Valutes.FruitCoins:
                TakeAnyValue(Valute.IFruitCoins,ValueOfValute,ValueOfPrice,price);
                Valute.FruitCoins.SaveAllValues();
                break;
            case Valutes.FruitDimonds:
                TakeAnyValue(Valute.IFruitDimonds,ValueOfValute,ValueOfPrice,price);
                Valute.FruitDimonds.SaveAllValues();
                break;
            case Valutes.MultiFruitCoins:
                TakeAnyValue(Valute.IMultiFruitCoins,ValueOfValute,ValueOfPrice,price);
                Valute.MultiFruitCoins.SaveAllValues();
                break;
        }
    }
    
    public void TakeAnyValue(IValuteController Valute,Values ValueOfValute,Values ValueOfPrice,int price)
    {
        switch (ValueOfValute)
        {
            case Values.Basic:
                SelectAValuesForTake(Valute,ValueOfValute,ValueOfPrice,price);
                break;
            case Values.Billons:
                Valute.BillionValue -= price;
                break;
            case Values.Quintillions:
                Valute.QuintillionValue -= price;
                break;
        }
    }

    public void SelectAValuesForTake(IValuteController Valute,Values ValueOfValute,Values ValueOfPrice,int price)
    {
        switch (ValueOfPrice)
        { 
            case Values.Basic:
                Valute.BasicValue -= price; 
                break;
            case Values.Billons:
                Valute.BillionValue -= price / _differenceOfValues;
                break;
            case Values.Quintillions:
                Valute.QuintillionValue -= price / (_differenceOfValues * _differenceOfValues);
                break;
        }
    }
}
