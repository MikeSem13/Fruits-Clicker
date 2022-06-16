using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

[Serializable] public class ValutesModel
{
  [Header("Название Валюты")]
  public string NameOfValute;

  [Space] 
  [Header("Валюта")] 
  public double Valute;

  [Space] 
  [Header("Множитель валюты")]
  public double ValuteMultiplier = 1;
  
  [Space] 
  [Header("Бусты множителя")] 
  public MultiplierBoostModel[] MultiplierBoosts;

  [Space] 
  [Header("Текст валюты")] 
  public Text TextOfValute;

  public void ConectAllBoostsToMulti()
  {
    double Sum = 1;
    
    foreach (var multiplierBoost in MultiplierBoosts)
    {
      Sum *= multiplierBoost.Boost;
    }

    ValuteMultiplier = Sum;
  }
  
  public MultiplierBoostModel GetMultiBoost(string nameOfBooost)
  {
    return MultiplierBoosts.FirstOrDefault(boost => boost.NameOfBoost == nameOfBooost);
  }
}
