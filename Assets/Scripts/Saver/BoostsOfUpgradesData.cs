using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable] public class BoostsOfUpgradesData
{
    public float ChanceOfDoubleCoins;
    public float ChanceOfMoreDimonds;
    public float GoldBoostTime;
    public float ChanceOfDimondFruits;
    public float PerzentOfLevelFruit;
    public float PerzentOfMultiFruitCoins;
    public float ChanceOfDoubleDimonds;

    public void TakeToSave(BoostsOfUpgrades boostsOfUpgrades)
    {
        ChanceOfDoubleCoins = boostsOfUpgrades.ChanceOfDoubleCoins;
        ChanceOfMoreDimonds = boostsOfUpgrades.ChanceOfMoreDimonds;
        GoldBoostTime = boostsOfUpgrades.GoldBoostTime;
        ChanceOfDimondFruits = boostsOfUpgrades.ChanceOfDimondFruits;
        PerzentOfLevelFruit = boostsOfUpgrades.PerzentOfLevelFruit;
        PerzentOfMultiFruitCoins = boostsOfUpgrades.PerzentOfMultiFruitCoins;
        ChanceOfDoubleDimonds = boostsOfUpgrades.ChanceOfDoubleDimonds;
    }

    public void ReturnSave(BoostsOfUpgrades boostsOfUpgrades)
    {
        boostsOfUpgrades.ChanceOfDoubleCoins = ChanceOfDoubleCoins;
        boostsOfUpgrades.ChanceOfMoreDimonds = ChanceOfMoreDimonds;
        boostsOfUpgrades.GoldBoostTime = GoldBoostTime;
        boostsOfUpgrades.ChanceOfDimondFruits = ChanceOfDimondFruits;
        boostsOfUpgrades.PerzentOfLevelFruit = PerzentOfLevelFruit;
        boostsOfUpgrades.PerzentOfMultiFruitCoins = PerzentOfMultiFruitCoins;
        boostsOfUpgrades.ChanceOfDoubleDimonds = ChanceOfDoubleDimonds;
    }
}
