using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadAndSaveValuteManager : MonoBehaviour
{
    [SerializeField] private ValuteManager ValuteManager; 
    
    public void Start()
    {
        LoadValutes();
        LoadMultis();
        LoadNumbers();
    }

    public void SaveValutes()
    {
        for (int i = 0; i < ValuteManager.Valutes.Count; i++)
        {
            for (int j = 0; j < ValuteManager.Valutes[i].Values.Count; j++)
            {
                PlayerPrefs.SetFloat(i + j + "Valute", ValuteManager.Valutes[i].Values[j].Valute);
            }
        }
    }

    public void SaveMultis()
    {
        for (int i = 0; i < ValuteManager.Valutes.Count; i++)
        {
            for (int j = 0; j < ValuteManager.Valutes[i].Values.Count; j++)
            {
                PlayerPrefs.SetFloat(i + j + "Multi", ValuteManager.Valutes[i].Values[j].MultiOfValute);
            }
        }
    }

    public void SaveNumberOfValue()
    {
        for (int i = 0; i < ValuteManager.Valutes.Count; i++)
        {
            PlayerPrefs.SetInt(i + "ValueNumber", ValuteManager.Valutes[i].NumberOfValue);
        }
    }
    
    public void SaveNumberOfMulti()
    {
        for (int i = 0; i < ValuteManager.Valutes.Count; i++)
        {
            PlayerPrefs.SetInt(i + "MultiNumber", ValuteManager.Valutes[i].NumberOfValue);
        }
    }
    
    private void LoadNumbers()
    {
        for (int i = 0; i < ValuteManager.Valutes.Count; i++)
        {
            ValuteManager.Valutes[i].NumberOfValue = PlayerPrefs.GetInt( i + "ValueNumber");
        }
    }
    
    private void LoadValutes()
    {
        for (int i = 0; i < ValuteManager.Valutes.Count; i++)
        {
            for (int j = 0; j < ValuteManager.Valutes[i].Values.Count; j++)
            {
                ValuteManager.Valutes[i].Values[j].Valute = PlayerPrefs.GetFloat(i + j + "Valute");
            }
        }
    }

    private void LoadMultis()
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
