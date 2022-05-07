using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using UnityEngine.Serialization;

public class MultiFruitCoinsValueController : MonoBehaviour, IValuteController
{
   [Header("Тип Валюты")] 
   public Valutes Valute;
   
   public Values CurrentValue;
   public Values CurrentValueOfMulti;

   [Header("Размеры валют")]
   [SerializeField]private float basicValue;
   [SerializeField]private float billionValue;
   [SerializeField]private float quintillionValue;
   
   [Header("Размеры множителей")]
   [SerializeField]private float mainMulti;
   [SerializeField]private float BillionmainMulti;
   [SerializeField]private float QuintillionmainMulti;
   
   public float BasicValue
   {
      get { return basicValue; }
      set
      {
         basicValue = value;

         if (basicValue < 0) basicValue = 0;
      }
   }

   public float BillionValue
   {
      get { return billionValue;}
      set
      {
         billionValue = value;
         if (billionValue < 0) billionValue = 0;
      }
   }

   public float QuintillionValue
   {
      get { return quintillionValue; }
      set
      {
         quintillionValue = value;

         if (quintillionValue < 0) quintillionValue = 0;
      }
   }

   public float MainMulti
   {
      get { return mainMulti; }
      set
      {
         mainMulti = value;
         if (mainMulti < 0) quintillionValue = 0;
      }
   }
   
   public float BillionMainMulti
   {
      get { return BillionmainMulti; }
      set
      {
         BillionmainMulti = value;
         if (BillionmainMulti < 0) BillionmainMulti = 0;
      }
   }
    
   public float QuintillioniMainMulti
   {
      get { return QuintillionmainMulti; }
      set
      {
         QuintillionmainMulti = value;
         if (QuintillionmainMulti < 0) QuintillionmainMulti = 0;
      }
   }

   [Header("Множители для МультифруктКоинов")]
   public float MultiOfMultiFruitCoinsForRebirth;
   
   public float MultiFromAwakingMultiFruit;
   
   public float MultiFruitCoinsAfterRebirth;

   private void Start()
   {
      LoadAllValues();
      
      MultiOfMultiFruitCoinsForRebirth = PlayerPrefs.GetFloat("MultiMultoFruitCoinsOfRebirth");
      MultiFromAwakingMultiFruit = PlayerPrefs.GetFloat("MultiAwakingMultiFruit");
      
      CheckMultisOfMultiFruitCoins();
   }
   public void SaveAllValues()
   {
      PlayerPrefs.SetFloat("MultiFruitCoins", BasicValue);
      PlayerPrefs.SetFloat("MultiFruitCoinsBillion", BillionValue);
      PlayerPrefs.SetFloat("MultiFruitCoinsQuintillion", QuintillionValue);
   }

   public void LoadAllValues()
   {
      BasicValue = PlayerPrefs.GetFloat("MultiFruitCoins");
      BillionValue = PlayerPrefs.GetFloat("MultiFruitCoinsBillion");
      QuintillionValue = PlayerPrefs.GetFloat("MultiFruitCoinsQuintillion");
   }
   
   public void AddMultiOfMultiFruitCoinsFroRebirth()
   {
      MultiOfMultiFruitCoinsForRebirth++;
      PlayerPrefs.SetFloat("MultiMultoFruitCoinsOfRebirth", MultiOfMultiFruitCoinsForRebirth);
   }
   
   public void SetMainMultiMultiFruitCoins()
   {
      MainMulti = MultiOfMultiFruitCoinsForRebirth * MultiFromAwakingMultiFruit;
   }
   
   public void CheckMultisOfMultiFruitCoins()
   {
      if (MultiOfMultiFruitCoinsForRebirth == 0) MultiOfMultiFruitCoinsForRebirth = 1;
      if (MultiFromAwakingMultiFruit == 0) MultiFromAwakingMultiFruit = 1;
   }

   public Values GetValuesOfValute()
   {
      return CurrentValue;
   }

   public void SetValuesOfValute(Values Value)
   {
      CurrentValue = Value;
   }
   
   public Values GetValuesOfMulti()
   {
      return CurrentValueOfMulti;
   }

   public void SetValuesOfMulti(Values Value)
   {
      CurrentValueOfMulti = Value;
   }

   public void AddValute()
   {
      SetMainMultiMultiFruitCoins();
      
      BasicValue += MultiFruitCoinsAfterRebirth;
      SaveAllValues();
   }
}
