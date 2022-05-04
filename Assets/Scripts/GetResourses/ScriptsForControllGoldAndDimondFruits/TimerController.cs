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

  [Header("Переменные стартового времени")]
  public float StartMinets;

  public float BoostSeconds;
  
  [Header("Текст таймера")]
  public Text TextOfTimer;

  private void Start()
  {
    GoldAndDimondBoostController = GetComponent<GoldAndDimondBoostController>();
    CurrentTime = PlayerPrefs.GetFloat("Time");
    BoostSeconds = PlayerPrefs.GetFloat("BoostTime");

    if (!PlayerPrefs.HasKey("IsFirstPlay"))
    {
      PlayerPrefs.SetInt("IsFirstPlay", 1);
    }
    else
    {
      PlayerPrefs.SetInt("IsFirstPlay", 0);
    }

    if (PlayerPrefs.GetInt("IsFirstPlay") == 1)
    {
      CurrentTime = 600;
    }
  }
  
  private void FixedUpdate()
  {
    PlayerPrefs.SetFloat("Time", CurrentTime);
    
    CurrentTime -= Time.deltaTime;
    TimeSpan time = TimeSpan.FromSeconds(CurrentTime);
    if (time.Seconds >= 10) TextOfTimer.text = "0" + time.Minutes + ":" + time.Seconds;
    else TextOfTimer.text = "0" + time.Minutes  + ":" + "0" + time.Seconds;

    if (CurrentTime <= 0)
    {
      CycleOfTimer();
      CurrentTime = StartMinets * 60;
    }
  }

  public void CycleOfTimer()
  {
    if (GoldAndDimondBoostController.BoostActive == false)
    {
      StartMinets = 0.5f + BoostSeconds;
      GoldAndDimondBoostController.BoostActive = true;
    }
    else if (GoldAndDimondBoostController.BoostActive)
    {
      StartMinets = 10f;
      GoldAndDimondBoostController.BoostActive = false;
    }
    GoldAndDimondBoostController.ControllBoost();
  }
  
  public void AddBoostSeconds()
  {
    BoostSeconds += 0.16f;
    PlayerPrefs.SetFloat("BoostTime", BoostSeconds);
  }
}
