using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

[Serializable] public class ValuesModel
{
  [Header("Название размерности")]
  public string ValueName;
  
  [Space]
  [Header("Валюта")]
  public float Valute;
  
  [FormerlySerializedAs("MultiOfValue")]
  [Space]
  [Header("Множители валют")]
  public float MultiOfValute;
}
