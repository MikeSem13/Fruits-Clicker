using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class ControllOnhectsInInformPanelAfterBuy : MonoBehaviour
{
   // classes needed for Change transorm of objects
   public BuyFruit Fruits;
   public FruitsController FruitsController;
   public ControllCurrentFruitInList ControllCurrentFruitInList;

   // Button to buy fruits
   public Button ButtonOfBuyFruits;

   public Image ImageOfBuyButton;
   // Text to buy Fruits
   public Text TextOfBuyButton;

   [Header("Спрайты")]
   public Sprite SpriteOfActiveBuyButton;
   public Sprite SpriteOfNonActiveBuyButton;
   public Sprite SpriteOfActiveSelectButton;
   

   // Method to choose parametres of button
   private void Update()
   {
      if (Fruits.AllFruitsDesctiber[Fruits.ControllCurrentFruitInList.CurrentFruitsInNumberInList].IsBuying & Fruits.AllFruitsDesctiber[Fruits.ControllCurrentFruitInList.CurrentFruitsInNumberInList].IsSelected == false)
      {
         TextOfBuyButton.text = "Выбрать";
         ButtonOfBuyFruits.image.sprite = SpriteOfActiveSelectButton;
         ImageOfBuyButton.gameObject.SetActive(false);
         TextOfBuyButton.fontSize = 92; 
         TextOfBuyButton.gameObject.transform.localPosition = new Vector2(0,0);
         TextOfBuyButton.gameObject.GetComponent<RectTransform>().sizeDelta = new Vector2(93.3107f,137.58f);
         TextOfBuyButton.alignment = TextAnchor.MiddleCenter;
      }
      else if (Fruits.AllFruitsDesctiber[Fruits.ControllCurrentFruitInList.CurrentFruitsInNumberInList].IsBuying & Fruits.AllFruitsDesctiber[Fruits.ControllCurrentFruitInList.CurrentFruitsInNumberInList].IsSelected == true)
      {
         TextOfBuyButton.text = "Выбрано";
         ButtonOfBuyFruits.image.sprite = SpriteOfActiveSelectButton;
         ImageOfBuyButton.gameObject.SetActive(false);
         TextOfBuyButton.fontSize = 92; 
         TextOfBuyButton.gameObject.transform.localPosition = new Vector2(0,0);
         TextOfBuyButton.gameObject.GetComponent<RectTransform>().sizeDelta = new Vector2(433.11f,234.67f);
         TextOfBuyButton.alignment = TextAnchor.MiddleCenter;
      }
      else
      {
         TextOfBuyButton.fontSize = 110;
         TextOfBuyButton.gameObject.transform.localPosition = new Vector2(57.01f,3.051758e-05f);
         TextOfBuyButton.gameObject.GetComponent<RectTransform>().sizeDelta = new Vector2(93.3107f,137.58f);
         TextOfBuyButton.alignment = TextAnchor.MiddleLeft;
         ImageOfBuyButton.gameObject.SetActive(true);
         TextOfBuyButton.text = Fruits.AllFruitsDesctiber[Fruits.ControllCurrentFruitInList.CurrentFruitsInNumberInList].price.ToString();
         
        // if (multiFruitCoinsValueController.BasicValue >= Fruits.AllFruitsDesctiber[Fruits.ControllCurrentFruitInList.CurrentFruitsInNumberInList].price)
         {
            ButtonOfBuyFruits.image.sprite = SpriteOfActiveBuyButton;
         }
         //else
         {
            ButtonOfBuyFruits.image.sprite = SpriteOfNonActiveBuyButton;
         }
      }
   } 
}

