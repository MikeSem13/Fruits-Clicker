using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class OnClickOfFruitsAnimation : MonoBehaviour
{
   public FruitsController FruitsController;
   
   public List<Animator> AnimatorsOfBasicFruit;

   public void OnClickAnimation()
   {
      AnimatorsOfBasicFruit[FruitsController.CurrentFruitInNumber].SetTrigger("Click");
   }
}
