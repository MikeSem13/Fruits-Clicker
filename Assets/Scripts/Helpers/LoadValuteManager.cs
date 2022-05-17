using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadValuteManager : MonoBehaviour
{
    [SerializeField] private ValuteManager ValuteManager; 
    
    public void Start()
    {
        LoadValutes();
        LoadMultis();
        LoadNumbers();
    }
    

    public void LoadNumbers()
    {
        for (int i = 0; i < ValuteManager.Valutes.Count; i++)
        {
            ValuteManager.Valutes[i].NumberOfValue = PlayerPrefs.GetInt( i + "ValueNumber");
        }
    }
    
    public void LoadValutes()
    {
        for (int i = 0; i < ValuteManager.Valutes.Count; i++)
        {
            for (int j = 0; j < ValuteManager.Valutes[i].Values.Count; j++)
            {
                ValuteManager.Valutes[i].Values[j].Valute = PlayerPrefs.GetFloat(i + j + "Valute");
            }
        }
    }

    public void LoadMultis()
    {
        for (int i = 0; i < ValuteManager.Valutes.Count; i++)
        {
            for (int j = 0; j < ValuteManager.Valutes[i].Values.Count; j++)
            {
                ValuteManager.Valutes[i].Values[j].MultiOfValute = PlayerPrefs.GetFloat(i + j + "Multi");
                if (ValuteManager.Valutes[i].Values[0].MultiOfValute == 0) ValuteManager.Valutes[i].Values[j].MultiOfValute = 1;
            }
        }
    }
}
