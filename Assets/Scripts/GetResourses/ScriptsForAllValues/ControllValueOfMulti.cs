using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllValueOfMulti : MonoBehaviour
{
    public ValuteController Valutes;

    public int BoardOfAddValutes;

    private void Update()
    {
        AllControllersToMultiValue();
    }

    public void AllControllersToMultiValue()
    {
        ControllAllTypesOfMulti();
        ControllAllValuesOfMulti();
    }
    
    public void ControllAllValuesOfMulti()
    {
        ControllValuesOfValutesMulti(Valutes.FruitCoins.Valute);
        ControllValuesOfValutesMulti(Valutes.FruitDimonds.Valute);
        ControllValuesOfValutesMulti(Valutes.MultiFruitCoins.Valute);
    }

    public void ControllAllTypesOfMulti()
    {
        ControllValueOfValute(Valutes.FruitCoins.Valute);
        ControllValueOfValute(Valutes.FruitDimonds.Valute);
        ControllValueOfValute(Valutes.MultiFruitCoins.Valute);
    }

    public void ControllValuesOfValutesMulti(Valutes Valute)
    {
        switch (Valute)
        {
            case global::Valutes.FruitCoins:
                ControllValuesOfMulti(Valutes.IFruitCoins);
                break;
            case global::Valutes.FruitDimonds:
                ControllValuesOfMulti(Valutes.IFruitDimonds);
                break;
            case global::Valutes.MultiFruitCoins:
                ControllValuesOfMulti(Valutes.IMultiFruitCoins);
                break;
        }
    }

    public void ControllValuesOfMulti(IValuteController Valute)
    {
        if (Valute.MainMulti >= BoardOfAddValutes)
        {
            Valute.BillionMainMulti += 1;
            Valute.MainMulti -= BoardOfAddValutes;
        }

        if (Valute.BillionMainMulti >= BoardOfAddValutes)
        {
            Valute.QuintillioniMainMulti += 1;
            Valute.BillionMainMulti -= BoardOfAddValutes;
        }
    }
    
    public void ControllValueOfValute(Valutes Valute)
    {
        switch (Valute)
        {
            case global::Valutes.FruitCoins:
                ControllTypeOfValueAnyMulti(Valutes.IFruitCoins);
                break;
            case global::Valutes.FruitDimonds:
                ControllTypeOfValueAnyMulti(Valutes.IFruitDimonds);
                break;
            case global::Valutes.MultiFruitCoins:
                ControllTypeOfValueAnyMulti(Valutes.IMultiFruitCoins);
                break;
        }
    }
    
    public void ControllTypeOfValueAnyMulti(IValuteController ValuteController)
    {
        // FruitСoins Values
        if (ValuteController.BillionMainMulti == 0) ValuteController.SetValuesOfMulti(Values.Basic);
        if (ValuteController.BillionMainMulti > 0) ValuteController.SetValuesOfMulti(Values.Billons);
        if (ValuteController.QuintillioniMainMulti > 0) ValuteController.SetValuesOfMulti(Values.Quintillions);
    }
}
