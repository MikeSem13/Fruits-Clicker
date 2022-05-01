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
   [SerializeField]private int basicValue;
   [SerializeField]private int billionValue;
   [SerializeField]private int quintillionValue;
   
   [Header("Размеры множителей")]
   [SerializeField]private int mainMulti;
   [SerializeField]private int BillionmainMulti;
   [SerializeField]private int QuintillionmainMulti;
   
   public int BasicValue
   {
      get { return basicValue; }
      set
      {
         basicValue = value;

         if (basicValue < 0) basicValue = 0;
      }
   }

   public int BillionValue
   {
      get { return billionValue;}
      set
      {
         billionValue = value;
         if (billionValue < 0) billionValue = 0;
      }
   }

   public int QuintillionValue
   {
      get { return quintillionValue; }
      set
      {
         quintillionValue = value;

         if (quintillionValue < 0) quintillionValue = 0;
      }
   }

   public int MainMulti
   {
      get { return mainMulti; }
      set
      {
         mainMulti = value;
         if (mainMulti < 0) quintillionValue = 0;
      }
   }
   
   public int BillionMainMulti
   {
      get { return BillionmainMulti; }
      set
      {
         BillionmainMulti = value;
         if (BillionmainMulti < 0) BillionmainMulti = 0;
      }
   }
    
   public int QuintillioniMainMulti
   {
      get { return QuintillionmainMulti; }
      set
      {
         QuintillionmainMulti = value;
         if (QuintillionmainMulti < 0) QuintillionmainMulti = 0;
      }
   }

   [Header("Множители для МультифруктКоинов")]
   public int MultiOfMultiFruitCoinsForRebirth;
   
   public int MultiFromAwakingMultiFruit;
   
   public int MultiFruitCoinsAfterRebirth;

   private void Start()
   {
      BasicValue = PlayerPrefs.GetInt("MultiFruitCoins");
      BillionValue = PlayerPrefs.GetInt("MultiFruitCoinsBillion");
      QuintillionValue = PlayerPrefs.GetInt("MultiFruitCoinsQuintillion");
      
      MultiOfMultiFruitCoinsForRebirth = PlayerPrefs.GetInt("MultiMultoFruitCoinsOfRebirth");
      MultiFromAwakingMultiFruit = PlayerPrefs.GetInt("MultiAwakingMultiFruit");
      
      CheckMultisOfMultiFruitCoins();
   }

   private void Update()
   {
      SetMainMultiMultiFruitCoins();
   }

   public void AddMultiOfMultiFruitCoinsFroRebirth()
   {
      MultiOfMultiFruitCoinsForRebirth++;
      PlayerPrefs.SetInt("MultiMultoFruitCoinsOfRebirth", MultiOfMultiFruitCoinsForRebirth);
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
      BasicValue += MultiFruitCoinsAfterRebirth;
      PlayerPrefs.SetInt("MultiFruitCoins", BasicValue);
   }
}
