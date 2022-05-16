using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class UpgradesForMultiFruitCoinsController : MonoBehaviour
{
    public GetLevelForSuchFruit LevelOfFruit;

    public void BuyMultiFruitUpgrades(BuyButtons BuyButton)
    {
        if (BuyButton.TypesOfMultiFruitCoinsUpgrades == TypesOfMultiFruitCoinsUpgrades.UpgradeForMoreLevel)
        {
            if (BuyButton.CurrentLevel < BuyButton.MaxLevel)
            {
                //if (Upgrades.TakeValute.Valute.IMultiFruitCoins.BasicValue >= BuyButton.price[BuyButton.CurrentLevel])
                {
                    //Upgrades.BuyUpgradeWithoutMultiForAnyValue(BuyButton,global::Valutes.MultiFruitCoins,BuyButton.Values,(int)BuyButton.price[BuyButton.CurrentLevel]);
                    LevelOfFruit.AddCountOfScoresForClick();   
                }
            }   
        }

        if (BuyButton.TypesOfMultiFruitCoinsUpgrades == TypesOfMultiFruitCoinsUpgrades.UpgradeForMoreMultiFruitCoins)
        {
            if (BuyButton.CurrentLevel < BuyButton.MaxLevel) 
            {
                //if (Upgrades.TakeValute.Valute.IMultiFruitCoins.BasicValue >= BuyButton.price[BuyButton.CurrentLevel])
                {
                   // Upgrades.BuyUpgradeWithoutMultiForAnyValue(BuyButton,global::Valutes.MultiFruitCoins,BuyButton.Values,(int)BuyButton.price[BuyButton.CurrentLevel]);
                    //Upgrades.TakeValute.Valute.MultiFruitCoins.AddMultiOfMultiFruitCoinsFroRebirth();   
                }
            }   
        }

        if (BuyButton.TypesOfMultiFruitCoinsUpgrades == TypesOfMultiFruitCoinsUpgrades.UpgradeForMoreDimonds2)
        {
            if (BuyButton.CurrentLevel < BuyButton.MaxLevel)
            {
                //if (Upgrades.TakeValute.Valute.IMultiFruitCoins.BasicValue >= BuyButton.price[BuyButton.CurrentLevel])
                {
                   //Upgrades.BuyUpgradeWithoutMultiForAnyValue(BuyButton,global::Valutes.MultiFruitCoins,BuyButton.Values,(int)BuyButton.price[BuyButton.CurrentLevel]);
                   // Upgrades.TakeValute.Valute.AddClickMulti(global::Valutes.MultiFruitCoins,1);   
                }
            }   
        }
    }
}
