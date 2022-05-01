using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class AddUpgrdesAfterBuyFruits : MonoBehaviour
{
   public BuyFruit BuyFruit;
   public GameObject Content;
   
   public List<GameObject> AddUpgrades;

   private void Update()
   {
       AddUpgrade();
   }

   public void AddUpgrade()
   {
       for (int i = 1; i < BuyFruit.AllFruitsDesctiber.Count; i++)
       {
           if (BuyFruit.AllFruitsDesctiber[i].IsBuying)
           {
               AddUpgrades[i - 1].SetActive(true);
               SetContet(i);
           }
           else
           {
               AddUpgrades[i - 1].SetActive(false);
           }
           
       }
   }

   public void SetContet(int i)
   {
       if(BuyFruit.AllFruitsDesctiber[i].fruits == Fruits.Apple) Content.GetComponent<RectTransform>().sizeDelta = new Vector2(1201.1f,1093.2f);
       if(BuyFruit.AllFruitsDesctiber[i].fruits == Fruits.Banana) Content.GetComponent<RectTransform>().sizeDelta = new Vector2(1201.1f,1396.971f);
       if(BuyFruit.AllFruitsDesctiber[i].fruits == Fruits.Orange) Content.GetComponent<RectTransform>().sizeDelta = new Vector2(1201.1f,1737.575f);
   }
}