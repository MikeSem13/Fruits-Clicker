using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using Random = UnityEngine.Random;

public class GoldAndDimondBoostController : MonoBehaviour
{
    [SerializeField] private ValuteManager ValuteManager;

    [SerializeField] private float Chance;
    [SerializeField] private float ProcentOfDimondBoost = 0.1f;
    
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

    public void ControllBoost()
    {
        if (BoostActive == false)
        {
            
        }
        if (BoostActive)
        {
            Chance = Random.Range(0f, 100f);
            if (Chance < ProcentOfDimondBoost);
            else ;
        }
    }
}
