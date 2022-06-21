
using UnityEngine;
using System;
using UnityEngine.UI;

public class TimerManager : MonoBehaviour
{
    [Header("Классы")]
    [SerializeField] private ValuteManager ValuteManager;
    [SerializeField] private BoostsFromUpgrades boostsFromUpgrades;

    [Space]
    [Header("Состояние буста")]
    public bool BoostActive;

    [Space]
    [Header("Текущее время")] 
    public float CurrentTime;
    
    [Space]
    [Header("Текст таймера")]
    public Text TextOfTimer;
    
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
      if (BoostActive == false)
      {
        CurrentTime = 30f;
        BoostActive = true;
      }
      else if (BoostActive)
      {
        CurrentTime = 600f;
        BoostActive = false;
      }
      ControllBoost();
    }

    public void ControllBoost()
    {
        if (BoostActive == false)
        {
            ValuteManager.GetValute("Fruit Coins").GetMultiBoost("Gold&Dimond Fruits Boost").Boost = 1;
        }
        if (BoostActive)
        {
            double Chance = UnityEngine.Random.Range(0, 100);
            if (Chance < boostsFromUpgrades.PercentOfDimondFruits) ValuteManager.GetValute("Fruit Coins").GetMultiBoost("Gold&Dimond Fruits Boost").Boost = 100;
            else ValuteManager.GetValute("Fruit Coins").GetMultiBoost("Gold&Dimond Fruits Boost").Boost = 10;
        }
    }
}
