using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class LoadAllValuesOfRebirthPanel : MonoBehaviour
{
    public RebirthBoostMulti BoostMulti;
    public ConvertingMultiFruitCoins ConverterMultiFruitCoins;
    public ConvertTextForRebirth ConverterOfRebirthPanel;

    public void LoadValuesOfRebirthPanel()
    {
        BoostMulti.SetMultiOfRebirth();
        ConverterMultiFruitCoins.ConvertFruitCoinsToMultiFruitCoins();
        ConverterOfRebirthPanel.SetAllMainRebirthPanelValues();
    }

    public void LoadStatisticValues()
    {
        ConverterOfRebirthPanel.SetAllStatisticValues();
    }
}
