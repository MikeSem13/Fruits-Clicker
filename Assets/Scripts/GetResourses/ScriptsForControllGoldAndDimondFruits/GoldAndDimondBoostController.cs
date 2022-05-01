using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using Random = UnityEngine.Random;

public class GoldAndDimondBoostController : MonoBehaviour
{
    public ValuteController Valutes;

    public float Chance;
    public float ProcentOfDimondBoost = 0.1f;
    
    public bool BoostActive;

    private void Start()
    {
        BoostActive = (PlayerPrefs.GetInt("ActiveBoost") != 0);
        ProcentOfDimondBoost = PlayerPrefs.GetFloat("prozBMD");
        if (ProcentOfDimondBoost == 0) ProcentOfDimondBoost = 0.1f;
    }

    private void FixedUpdate()
    {
        PlayerPrefs.SetInt("ActiveBoost", BoostActive ? 1 : 0);
    }

    public void AddProcent()
    {
        ProcentOfDimondBoost += 0.1f;
        PlayerPrefs.SetFloat("prozBMD", ProcentOfDimondBoost);
    }
    
    public void ControllBoost()
    {
        if (BoostActive == false)
        {
            Valutes.FruitCoins.MultiOfGoldOrDimondsFruits = 1;
        }
        if (BoostActive)
        {
            Chance = Random.Range(0f, 100f);
            if (Chance < ProcentOfDimondBoost) Valutes.FruitCoins.MultiOfGoldOrDimondsFruits = 100;
            else Valutes.FruitCoins.MultiOfGoldOrDimondsFruits = 10;
        }
        PlayerPrefs.SetInt("FruitCoinsGoldAndDimondsMulti", Valutes.FruitCoins.MultiOfGoldOrDimondsFruits);
    }
}
