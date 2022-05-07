using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class UpgradesForDimondsController : MonoBehaviour
{
    // Classes Needed For Upgrades
    public UpgradesController Upgrades;
    public GetBonusMulti BonusMulti;
    public TimerController TimerController;
    public GoldAndDimondBoostController GoldBoost;

    // Methods Of Upgrade for Dimonds
    public void BuyDimondUpgrades(BuyButtons BuyButton)
    {
        if (BuyButton.TypesOfDinondsUpgrades == TypesOfDinondsUpgrades.UpgradeForMoreCoins)
        {
            if (BuyButton.CurrentLevel < BuyButton.MaxLevel)
            {
                if (Upgrades.TakeValute.Valute.IFruitDimonds.BasicValue >= (int)BuyButton.price[BuyButton.CurrentLevel])
                {
                    Upgrades.BuyUpgradeWithoutMultiForAnyValue(BuyButton,Upgrades.TakeValute.Valute.FruitDimonds.Valute,BuyButton.Values,(int)BuyButton.price[BuyButton.CurrentLevel]);
                    BonusMulti.AddProcent();   
                }
            }
        }

        if (BuyButton.TypesOfDinondsUpgrades == TypesOfDinondsUpgrades.UpgradeForMoreDimonds)
        {
            if (BuyButton.CurrentLevel < BuyButton.MaxLevel) 
            { 
                if (Upgrades.TakeValute.Valute.IFruitDimonds.BasicValue >= (int)BuyButton.price[BuyButton.CurrentLevel])
                {
                    Upgrades.BuyUpgradeWithoutMultiForAnyValue(BuyButton,Upgrades.TakeValute.Valute.FruitDimonds.Valute,BuyButton.Values,(int)BuyButton.price[BuyButton.CurrentLevel]);
                    Upgrades.TakeValute.Valute.FruitDimonds.AddPercentForUpgrade();   
                }
            }   
        }

        if (BuyButton.TypesOfDinondsUpgrades == TypesOfDinondsUpgrades.UpgradeForMoreTimeForBoost)
        {
            if (BuyButton.CurrentLevel < BuyButton.MaxLevel)
            {
                if (Upgrades.TakeValute.Valute.IFruitDimonds.BasicValue >= (int)BuyButton.price[BuyButton.CurrentLevel])
                {
                    Upgrades.BuyUpgradeWithoutMultiForAnyValue(BuyButton,Upgrades.TakeValute.Valute.FruitDimonds.Valute,BuyButton.Values,(int)BuyButton.price[BuyButton.CurrentLevel]);
                    TimerController.AddBoostSeconds();
                }
            }   
        }

        if (BuyButton.TypesOfDinondsUpgrades == TypesOfDinondsUpgrades.UpgradeForMoreDimondFruits)
        {
            if (BuyButton.CurrentLevel < BuyButton.MaxLevel)
            {
                if (Upgrades.TakeValute.Valute.IFruitDimonds.BasicValue >= (int)BuyButton.price[BuyButton.CurrentLevel])
                {
                    Upgrades.BuyUpgradeWithoutMultiForAnyValue(BuyButton,Upgrades.TakeValute.Valute.FruitDimonds.Valute,BuyButton.Values,(int)BuyButton.price[BuyButton.CurrentLevel]);
                    GoldBoost.AddProcent();
                }
            }   
        }
    }
}
