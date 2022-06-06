using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

[Serializable] public class ValutesModel
{
  [Header("Название Валюты")]
  public string NameOfValute;
  
  [Space]
  [Header("Размерности валют")]
  public ValuesModel [] Values;
  public Text TextOfValute;
  
  [Space]
  [Header("Дополнительные параметры")]
  public int NumberOfValue;
  public int NumberOfMulti;
}
