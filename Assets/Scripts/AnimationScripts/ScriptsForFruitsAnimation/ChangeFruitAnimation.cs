using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.Serialization;

public class ChangeFruitAnimation : MonoBehaviour
{
  public TimerController Timer;
  public OnClickOfFruitsAnimation OnClickAnimation;

  private void FixedUpdate()
  {
    if (Timer.CurrentTime < 0.4f)
    {
      OnClickAnimation.AnimatorsOfBasicFruit[OnClickAnimation.FruitsController.CurrentFruitInNumber].SetBool("Changing", true);
    }
    else
    {
      OnClickAnimation.AnimatorsOfBasicFruit[OnClickAnimation.FruitsController.CurrentFruitInNumber].SetBool("Changing", false);
    }
  }
}
