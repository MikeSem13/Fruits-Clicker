using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuyAwaking : MonoBehaviour
{
   public ChancesOfAwaking Chance;
   public BuyFruit Fruits;
   public ConvertAwakingMultiController ConvertAwakingMultiController;
   public HidePanelButton HidePanel;
   
   
   private void Start()
   {
      for (int i = 0; i < Fruits.AllFruitsDesctiber.Count; i++)
      {
         Fruits.AllFruitsDesctiber[i].IsAwaking = PlayerPrefs.GetInt("IsAwake" + i) != 0;
      }
      
      for (int i = 0; i < Fruits.AllFruitsDesctiber.Count; i++)
      {
         Fruits.AllFruitsDesctiber[i].CountOfMultiAwaking = PlayerPrefs.GetInt("CountOfAwaking" + i);
      }
   }

   private void Update()
   {
      for (int i = 0; i < Fruits.AllFruitsDesctiber.Count; i++)
      {
        PlayerPrefs.SetInt("IsAwake" + i, Fruits.AllFruitsDesctiber[i].IsAwaking ? 1 : 0);
      }
      
      for (int i = 0; i < Fruits.AllFruitsDesctiber.Count; i++)
      {
         PlayerPrefs.SetInt("CountOfAwaking" + i, Fruits.AllFruitsDesctiber[i].CountOfMultiAwaking);
      }
   }

   public void StartAwaking()
   {
      if (Fruits.AllFruitsDesctiber[Fruits.ControllCurrentFruitInList.CurrentFruitsInNumberInList].IsAwaking == false)
      {
         Chance.GenerateATypeOfBoost();
         ConvertAwakingMultiController.SetMultisOfAwaking();
         Fruits.AllFruitsDesctiber[Fruits.ControllCurrentFruitInList.CurrentFruitsInNumberInList].IsAwaking = true;
         HidePanel.DoHidePanel();
      }
   }
}

public enum TypesOfAwaking
{
   None,
   FruitCoinsAwaking,
   FruitDimondsAwaking,
   MultiFruitCoinsAwaking
}