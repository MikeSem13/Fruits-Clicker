using System;
using UnityEngine.UI;

[Serializable] public class ConvertValuesToText
{
    public void ConvertValueToText(Text textOfValue, double value, string frontSybwol)
    {
        ConvertValueDemossionsToText(ref textOfValue, value, 1e+3, "",  frontSybwol);
        ConvertValueDemossionsToText(ref textOfValue, value, 1e+6, "k",  frontSybwol);
        ConvertValueDemossionsToText(ref textOfValue, value, 1e+9, "M",  frontSybwol);
        ConvertValueDemossionsToText(ref textOfValue, value, 1e+12, "B",  frontSybwol);
        ConvertValueDemossionsToText(ref textOfValue, value, 1e+15, "T",  frontSybwol);
        ConvertValueDemossionsToText(ref textOfValue, value, 1e+18, "q",  frontSybwol);
        ConvertValueDemossionsToText(ref textOfValue, value, 1e+21, "Q",  frontSybwol);
        ConvertValueDemossionsToText(ref textOfValue, value, 1e+24, "Sx",  frontSybwol);
        ConvertValueDemossionsToText(ref textOfValue, value, 1e+27, "Sp",  frontSybwol);
        ConvertValueDemossionsToText(ref textOfValue, value, 1e+30, "O",  frontSybwol);
        ConvertValueDemossionsToText(ref textOfValue, value, 1e+33, "No",  frontSybwol);
        ConvertValueDemossionsToText(ref textOfValue, value, 1e+36, "D",  frontSybwol);
        ConvertValueDemossionsToText(ref textOfValue, value, 1e+39, "Ud",  frontSybwol);
        ConvertValueDemossionsToText(ref textOfValue, value, 1e+42, "Duo",  frontSybwol);
        ConvertValueDemossionsToText(ref textOfValue, value, 1e+45, "Td",  frontSybwol);
        ConvertValueDemossionsToText(ref textOfValue, value, 1e+48, "Qt",  frontSybwol);
        ConvertValueDemossionsToText(ref textOfValue, value, 1e+51, "Qnd",  frontSybwol);
        ConvertValueDemossionsToText(ref textOfValue, value, 1e+54, "Sd",  frontSybwol);
        ConvertValueDemossionsToText(ref textOfValue, value, 1e+57, "Spd",  frontSybwol);
        ConvertValueDemossionsToText(ref textOfValue, value, 1e+60, "Oqd",  frontSybwol);
    }
    
    private void ConvertValueDemossionsToText(ref Text textOfValue, double value, double board , string sybwolOfValue, string frontSybwol)
    {
        if (value < board / 100 && value >= 1e+3 && value >= board / 1000)
        {
            textOfValue.text = frontSybwol + Math.Floor(value / (board / 1000)) + "." + Math.Floor(value / (board / 10000)).ToString().Remove(0, 1) + sybwolOfValue;
        }
        else if (value < board && value >= board / 1000)
        {
            textOfValue.text = frontSybwol + Math.Floor(value / (board / 1000)) + sybwolOfValue;
        }
        else if (value == 0) textOfValue.text = frontSybwol + 0;
    }
}
