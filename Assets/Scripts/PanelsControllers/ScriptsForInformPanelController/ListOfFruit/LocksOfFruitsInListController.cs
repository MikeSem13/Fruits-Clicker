using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LocksOfFruitsInListController : MonoBehaviour
{
    public BuyFruit BuyFruit;
   // Locks with Texts
   public List<GameObject> Locks;
   public List<Text> TextsOfFruits;

   public List<int> BoardsOfUnlock;

   private void Update()
   {
      SetEnableLocksOfFruits();
   }


   public void SetEnableLocksOfFruits()
   {
       SetCountUnlockedFruits();
       
       for (int i = 1; i < BuyFruit.AllFruitsDesctiber.Count; i++)
       {
           if (BuyFruit.AllFruitsDesctiber[i].IsUnlocked)
           {
               Locks[i - 1].SetActive(false);
               TextsOfFruits[i - 1].gameObject.SetActive(true);
           }
           else
           {
               Locks[i - 1].SetActive(true);
               TextsOfFruits[i - 1].gameObject.SetActive(false);
           }
       }
   }
   
   public void SetCountUnlockedFruits()
   {
       for (int i = 0; i < BuyFruit.AllFruitsDesctiber.Count; i++)
       {
          /* if (Rebirth.CountOfRebirth >= BoardsOfUnlock[i])
           {
               BuyFruit.AllFruitsDesctiber[i].IsUnlocked = true;
           }
           else
           {
               BuyFruit.AllFruitsDesctiber[i].IsUnlocked = false;
           }*/
       }
   }
}
