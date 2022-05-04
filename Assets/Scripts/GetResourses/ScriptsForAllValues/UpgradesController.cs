using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradesController : MonoBehaviour
{
    public ValuteController Valute;

    public void BuyUpgradeWithMultiForAnyValue(BuyButtons BuyButtons, Valutes valute, Values Value, int price, int multi)
    {
        switch (Value)
        {
            case Values.Basic:
                if (Valute.IFruitCoins.BasicValue > price)
                {
                    BuyButtons.CurrentLevel++;
                    Valute.TakeAnyValueOfValute(Valutes.FruitCoins, Value, price);
                    Valute.AddClickMulti(valute, multi);
                }

                break;
            case Values.Billons:
                if (Valute.IFruitCoins.BillionValue > price)
                {
                    BuyButtons.CurrentLevel++;
                    Valute.TakeAnyValueOfValute(Valutes.FruitCoins, Value, price);
                    Valute.AddClickMulti(valute, multi);
                }

                break;
            case Values.Quintillions:
                if (Valute.IFruitCoins.QuintillionValue > price)
                {
                    BuyButtons.CurrentLevel++;
                    Valute.TakeAnyValueOfValute(Valutes.FruitCoins, Value, price);
                    Valute.AddClickMulti(valute, multi);
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
                Valute.TakeAnyValueOfValute(valute,Value,price);   
                break;
            case Values.Billons:
                Valute.TakeAnyValueOfValute(valute,Value,price);   
                break;
            case Values.Quintillions:
                Valute.TakeAnyValueOfValute(valute,Value,price);   
                break;
        }
    }
}
