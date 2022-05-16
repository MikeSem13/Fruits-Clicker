using System;
using System.Collections.Generic;
using UnityEngine.Serialization;
using UnityEngine.UI;

[Serializable] public class ValutesModel
{
  public string NameOfValute;

  public List<Text> TextsOfValute;
  public List<ValuesModel> Values;

  public List<string> SybwolsOfValue;
  public int NumberOfValue;
  public int NumberOfMulti;
}
