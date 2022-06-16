using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerPositionController : MonoBehaviour
{
   public BuyFruit BuyFruit;
   public GameObject Spawner;

   private void Update()
   {
      SetPosSpawner(BuyFruit.AllFruitsDesctiber[BuyFruit.ControllFruits.CurrentFruitInNumber]);
   }

   public void SetPosSpawner(DescriberForFruitsInList Describer)
   {
      if (Describer.fruits == Fruits.Banana && Describer.IsSelected == true) Spawner.transform.localPosition = new Vector2(-151.8f, 0f);
      else Spawner.transform.localPosition = new Vector2();
   }
}
