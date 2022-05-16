using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangerBuyPanelsController : MonoBehaviour
{
   // Button For Rebirth
   [SerializeField]private Button buyRebirthButton;

   public Sprite ActiveBuyRebirthButton;
   public Sprite NonActiveBuyRebirthButton;
   
   // Needed Class for change color

   // Chnage Color Of Button follow count of Coins
   private void Update()
   {
      //if (FruitCoins.BillionValue > 0)
      {
         buyRebirthButton.image.sprite = ActiveBuyRebirthButton;
      }
      //else
      {
         buyRebirthButton.image.sprite = NonActiveBuyRebirthButton;
      }
   }
}
