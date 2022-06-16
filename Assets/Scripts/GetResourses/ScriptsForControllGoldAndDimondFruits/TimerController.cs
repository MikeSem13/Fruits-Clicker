using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerController : MonoBehaviour
{
  public GoldAndDimondBoostController GoldAndDimondBoostController;
  [Header("Текущее время")] 
  public float CurrentTime;

  [Header("Текст таймера")]
  public Text TextOfTimer;

  private void Start()
  {
    GoldAndDimondBoostController = GetComponent<GoldAndDimondBoostController>();
  }
  
  private void FixedUpdate()
  {
    CurrentTime -= Time.deltaTime;
    TimeSpan time = TimeSpan.FromSeconds(CurrentTime);
    if (time.Seconds >= 10) TextOfTimer.text = "0" + time.Minutes + ":" + time.Seconds;
    else TextOfTimer.text = "0" + time.Minutes  + ":" + "0" + time.Seconds;

    if (time.Seconds <= 0)
    {
      CycleOfTimer();
    }
  }

  public void CycleOfTimer()
  {
    if (GoldAndDimondBoostController.BoostActive == false)
    {
      CurrentTime = 30f;
      GoldAndDimondBoostController.BoostActive = true;
    }
    else if (GoldAndDimondBoostController.BoostActive)
    {
      CurrentTime = 600f;
      GoldAndDimondBoostController.BoostActive = false;
    }
    GoldAndDimondBoostController.ControllBoost();
  }
}
