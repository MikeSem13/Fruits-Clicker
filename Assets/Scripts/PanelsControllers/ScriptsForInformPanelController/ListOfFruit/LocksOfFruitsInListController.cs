using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LocksOfFruitsInListController : MonoBehaviour
{
   // Class needed for change Locks
   public BuyRebirth Rebirth;

   public BuyFruit BuyFruit;
   // Locks with Texts
   public List<GameObject> Locks;
   public List<Text> TextsOfFruits;

   public List<int> BoardsOfUnlock;

   private void Update()
   {
       for (int i = 0; i < BuyFruit.AllFruitsDesctiber.Count; i++)
       {
           SetCountUnlockedFruits(BuyFruit.AllFruitsDesctiber[i]);   
       }
   }

   // Method to Show Locks follow count of rebirth
   public void SetCountUnlockedFruits(DescriberForFruitsInList Describer)
   {
       for (int i = 0; i < BoardsOfUnlock.Count; i++)
       {
           if (Rebirth.CountOfRebirth >= BoardsOfUnlock[i])
           {
               Locks[i].SetActive(false);
               TextsOfFruits[i].gameObject.SetActive(true);
               Describer.IsUnlocked = true;
           }
           else
           {
               Locks[i].SetActive(true);
               TextsOfFruits[i].gameObject.SetActive(false);
               Describer.IsUnlocked = false;
           }
       }
   }
}
