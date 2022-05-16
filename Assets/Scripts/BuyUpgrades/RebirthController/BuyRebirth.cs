using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;
using UnityEngine.UIElements.Experimental;

public class BuyRebirth : MonoBehaviour
{
   // Nedded Classes
   public ResetAllUpgradeOfFruit ResetUpgrades;
   public HidePanelButton HideButton;

   // Button For Rebirth
   public Button ButtonOfRebirth;

   // Variabels for rebirth parametres
   public float CountOfRebirth;

   // Save All Variables
   private void Start()
   {
      CountOfRebirth = PlayerPrefs.GetFloat("Crebirth");
   }

   private void Update()
   {
      PlayerPrefs.SetFloat("Crebirth", CountOfRebirth);
   }

   // Method for Start Rebirth
   public void StartRebith()
   {
     // if (MultiFruitCoins.MultiFruitCoinsAfterRebirth > 0)
      {
         HideButton.DoHidePanel();
         ResetUpgrades.ResetUpgrades();
        // Valutes.IMultiFruitCoins.AddValute();
         CountOfRebirth++;
        // FruitCoins.ResetAllFruitCoinsAndMultiForRebirth();
      }
      StartRebirthAnimation();
   }
   
   // Method for Start Rebirth Animation
   public void StartRebirthAnimation()
   {
      ButtonOfRebirth.GetComponent<Animator>().Play("ButtonOfRebirthAnimation");
   }
}
