using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using Random = UnityEngine.Random;

public class GetBonusMulti : MonoBehaviour
{
    // Classes needed for other multis 
    public FruitCoinsValuteController FruitCoins;
    
    // Variables for chances
    public int Chance;
    public int prozent = 0;

    // Method to Get Bonus Multi
    public void GetMultiBonus()
    {
        Chance = Random.Range(0, 100);
        if (Chance < prozent)
        {
            FruitCoins.MultiOfBonus = 2;
        }
        else
        {
            FruitCoins.MultiOfBonus = 1;
        }
    }
    
    // Save Chances
    private void Start()
    {
        prozent = PlayerPrefs.GetInt("ProcentOfBonus");
    }

    public void AddProcent()
    {
        prozent++;
        PlayerPrefs.SetInt("ProcentOfBonus", prozent);
    }
}
