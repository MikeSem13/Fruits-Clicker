using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextConvertManager : MonoBehaviour
{
    public ConvertValuesToText ValuesToText;
    public UpgradeTextConvert UpgradeTextConvert;
    public StatisticPanelTextConver statisticTextConver;

    public void Update()
    {
        PermanentConverters();
    }

    public void PermanentConverters()
    {
        UpgradeTextConvert.ConvertAllTextOfUpgradesToText();
        statisticTextConver.ConvertStatisticValuesToText();
    }
}
