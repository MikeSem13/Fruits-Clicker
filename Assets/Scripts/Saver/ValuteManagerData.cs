using System;

[Serializable] public class ValuteManagerData
{
  public ValutesModel [] Valutes;

  public void TakeToSave(ValuteManager valuteManager)
  {
      for (int i = 0; i < valuteManager.Valutes.Length; i++)
      {
          Valutes[i].Values = valuteManager.Valutes[i].Values;
          Valutes[i].NumberOfValue = valuteManager.Valutes[i].NumberOfValue;
          Valutes[i].NumberOfMulti = valuteManager.Valutes[i].NumberOfMulti;
      }
  }

  public void ReturnSave(ValuteManager valuteManager)
  {
      for (int i = 0; i < valuteManager.Valutes.Length; i++)
      {
          valuteManager.Valutes[i].Values = Valutes[i].Values;
          valuteManager.Valutes[i].NumberOfValue = Valutes[i].NumberOfValue;
          valuteManager.Valutes[i].NumberOfMulti = Valutes[i].NumberOfMulti;
      }
  }
}
