using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using Random = UnityEngine.Random;

public class GoldAndDimondBoostController : MonoBehaviour
{
    [SerializeField] private ValuteManager ValuteManager;
    
    [SerializeField] private float ProcentOfDimondBoost = 0.1f;
    
    public bool BoostActive;

    private void Start()
    {
        if (ProcentOfDimondBoost == 0) ProcentOfDimondBoost = 0.1f;
    }

    public void ControllBoost()
    {
        if (BoostActive == false)
        {
            ValuteManager.GetValute("Fruit Coins").GetMultiBoost("Gold&Dimond Fruits Boost").Boost = 1;
        }
        if (BoostActive)
        {
            double Chance = Random.Range(0f, 100f);
            if (Chance < ProcentOfDimondBoost) ValuteManager.GetValute("Fruit Coins").GetMultiBoost("Gold&Dimond Fruits Boost").Boost = 100;
            else ValuteManager.GetValute("Fruit Coins").GetMultiBoost("Gold&Dimond Fruits Boost").Boost = 10;
        }
    }
}
