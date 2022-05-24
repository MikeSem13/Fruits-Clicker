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
  public List<ValuesModel> Values;

  [Space]
  [Header("Дополнительный множитель")]
  
  
  [Space]
  [Header("Дополнительные параметры")]
  public List<Text> TextsOfValute;
  public List<string> SybwolsOfValue;
  public int NumberOfValue;
  public int NumberOfMulti;
}
