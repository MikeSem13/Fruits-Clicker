using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradesController : MonoBehaviour
{
    public TakeValuteController TakeValute;

    public void BuyUpgradeWithMultiForAnyValue(BuyButtons BuyButtons, Valutes valute, Values Value, int price, int multi)
    {
        switch (Value)
        {
            case Values.Basic:
                if (TakeValute.Valute.IFruitCoins.BasicValue > price)
                {
                    BuyButtons.CurrentLevel++;
                    ChooseValueToTakeForUpgrades(Valutes.FruitCoins, Value, BuyButtons, price);
                    TakeValute.Valute.AddClickMulti(valute, multi);
                }

                break;
            case Values.Billons:
                if (TakeValute.Valute.IFruitCoins.BillionValue > price)
                {
                    BuyButtons.CurrentLevel++;
                    ChooseValueToTakeForUpgrades(Valutes.FruitCoins, Value, BuyButtons, price);
                    TakeValute.Valute.AddClickMulti(valute, multi);
                }

                break;
            case Values.Quintillions:
                if (TakeValute.Valute.IFruitCoins.QuintillionValue > price)
                {
                    BuyButtons.CurrentLevel++;
                    ChooseValueToTakeForUpgrades(Valutes.FruitCoins, Value, BuyButtons, price);
                    TakeValute.Valute.AddClickMulti(valute, multi);
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
                ChooseValueToTakeForUpgrades(valute,Value,BuyButtons,price);
            } 
                break;
            case Valutes.MultiFruitCoins:
            {
                BuyButtons.CurrentLevel++;
                ChooseValueToTakeForUpgrades(valute,Value,BuyButtons,price);
            } 
                break;
        }
    }

    public void ChooseValueToTakeForUpgrades(Valutes valute,Values Value,BuyButtons buyButtons,int price)
    {
        switch (Value)
        {
            case Values.Basic:
                TakeValute.TakeAnyValueOfValute(valute,Value,buyButtons.Values,price);   
                break;
            case Values.Billons:
                TakeValute.TakeAnyValueOfValute(valute,Value,buyButtons.Values,price);   
                break;
            case Values.Quintillions:
                TakeValute.TakeAnyValueOfValute(valute,Value,buyButtons.Values,price);   
                break;
        }
    }
}
