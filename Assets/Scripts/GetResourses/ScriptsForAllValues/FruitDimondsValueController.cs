using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using Random = UnityEngine.Random;

public class FruitDimondsValueController : MonoBehaviour, IValuteController
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
   
   [Header("Множители для фруитдаймондов")]
   public int MultiDimondsFromClick;
   public int MultiFromAwakingFruitDimonds;

   [Header("Дополнительные переменные")] 
   public float Chance;
   public float percent;

   private void Start()
   {
      BasicValue = PlayerPrefs.GetInt("FruitDimonds");
      BillionValue = PlayerPrefs.GetInt("FruitDimondsBillion");
      QuintillionValue = PlayerPrefs.GetInt("FruitDimondsQuintillion");
      
      MainMulti = PlayerPrefs.GetInt("FruitDimondsMulti");
      MultiDimondsFromClick = PlayerPrefs.GetInt("FruitDimondsClickMulti");
      MultiFromAwakingFruitDimonds = PlayerPrefs.GetInt("FruitDimondsAwakingMulti");
      percent = PlayerPrefs.GetFloat("PersentOfDimonds");

      CheckMultisAndpercent();
   }

   private void Update()
   {
      SetMainMultiFruitDimonds();
   }

   public void SetMainMultiFruitDimonds()
   {
      MainMulti = MultiDimondsFromClick * MultiFromAwakingFruitDimonds;
   }
   
   public void CheckMultisAndpercent()
   {
      if (MultiDimondsFromClick == 0) MultiDimondsFromClick = 1;
      if (MultiFromAwakingFruitDimonds == 0) MultiFromAwakingFruitDimonds = 1;
      if (percent == 0) percent = 1;
   }

   public void AddPercentForUpgrade()
   {
      percent += 1; 
      PlayerPrefs.SetFloat("PersentOfDimonds", percent);
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
      Chance = Random.Range(0, 100);
      if (Chance < percent) BasicValue += MainMulti;
      
      PlayerPrefs.SetInt("FruitDimonds", BasicValue);
      PlayerPrefs.SetInt("FruitDimondsBillion", BillionValue);
      PlayerPrefs.SetInt("FruitDimondsQuintillion", QuintillionValue);
   }
}