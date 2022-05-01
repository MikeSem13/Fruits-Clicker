using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class UpgradesForMultiFruitCoinsController : MonoBehaviour
{
    public ValuteController Valutes;
    public GetLevelForSuchFruit LevelOfFruit;

    public void BuyMultiFruitUpgrades(BuyButtons BuyButton)
    {
        if (BuyButton.TypesOfMultiFruitCoinsUpgrades == TypesOfMultiFruitCoinsUpgrades.UpgradeForMoreLevel)
        {
            if (BuyButton.CurrentLevel < BuyButton.MaxLevel)
            {
                if (Valutes.IMultiFruitCoins.BasicValue >= BuyButton.price[BuyButton.CurrentLevel])
                {
                    Valutes.BuyUpgradeWithoutMultiForAnyValue(BuyButton,global::Valutes.MultiFruitCoins,BuyButton.Values,(int)BuyButton.price[BuyButton.CurrentLevel]);
                    LevelOfFruit.AddCountOfScoresForClick();   
                }
            }   
        }

        if (BuyButton.TypesOfMultiFruitCoinsUpgrades == TypesOfMultiFruitCoinsUpgrades.UpgradeForMoreMultiFruitCoins)
        {
            if (BuyButton.CurrentLevel < BuyButton.MaxLevel) 
            {
                if (Valutes.IMultiFruitCoins.BasicValue >= BuyButton.price[BuyButton.CurrentLevel])
                {
                    Valutes.BuyUpgradeWithoutMultiForAnyValue(BuyButton,global::Valutes.MultiFruitCoins,BuyButton.Values,(int)BuyButton.price[BuyButton.CurrentLevel]);
                    Valutes.MultiFruitCoins.AddMultiOfMultiFruitCoinsFroRebirth();   
                }
            }   
        }

        if (BuyButton.TypesOfMultiFruitCoinsUpgrades == TypesOfMultiFruitCoinsUpgrades.UpgradeForMoreDimonds2)
        {
            if (BuyButton.CurrentLevel < BuyButton.MaxLevel)
            {
                if (Valutes.IMultiFruitCoins.BasicValue >= BuyButton.price[BuyButton.CurrentLevel])
                {
                    Valutes.BuyUpgradeWithoutMultiForAnyValue(BuyButton,global::Valutes.MultiFruitCoins,BuyButton.Values,(int)BuyButton.price[BuyButton.CurrentLevel]);
                    Valutes.AddClickMulti(global::Valutes.MultiFruitCoins,1);   
                }
            }   
        }
    }
}
