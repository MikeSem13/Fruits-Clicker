using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextConverter : MonoBehaviour
{
    public void ConvertValuesToText(Text textOfValue, double value, string frontSybwol)
    {
        ConvertValueToText(ref textOfValue, value, 1e+3, "",  frontSybwol);
        ConvertValueToText(ref textOfValue, value, 1e+6, "k",  frontSybwol);
        ConvertValueToText(ref textOfValue, value, 1e+9, "M",  frontSybwol);
        ConvertValueToText(ref textOfValue, value, 1e+12, "B",  frontSybwol);
        ConvertValueToText(ref textOfValue, value, 1e+15, "T",  frontSybwol);
        ConvertValueToText(ref textOfValue, value, 1e+18, "q",  frontSybwol);
        ConvertValueToText(ref textOfValue, value, 1e+21, "Q",  frontSybwol);
        ConvertValueToText(ref textOfValue, value, 1e+24, "Sx",  frontSybwol);
        ConvertValueToText(ref textOfValue, value, 1e+27, "Sp",  frontSybwol);
        ConvertValueToText(ref textOfValue, value, 1e+30, "O",  frontSybwol);
        ConvertValueToText(ref textOfValue, value, 1e+33, "No",  frontSybwol);
        ConvertValueToText(ref textOfValue, value, 1e+36, "D",  frontSybwol);
        ConvertValueToText(ref textOfValue, value, 1e+39, "Ud",  frontSybwol);
        ConvertValueToText(ref textOfValue, value, 1e+42, "Duo",  frontSybwol);
        ConvertValueToText(ref textOfValue, value, 1e+45, "Td",  frontSybwol);
        ConvertValueToText(ref textOfValue, value, 1e+48, "Qt",  frontSybwol);
        ConvertValueToText(ref textOfValue, value, 1e+51, "Qnd",  frontSybwol);
        ConvertValueToText(ref textOfValue, value, 1e+54, "Sd",  frontSybwol);
        ConvertValueToText(ref textOfValue, value, 1e+57, "Spd",  frontSybwol);
        ConvertValueToText(ref textOfValue, value, 1e+60, "Oqd",  frontSybwol);
    }
    
    private void ConvertValueToText(ref Text textOfValue, double value, double board , string sybwolOfValue, string frontSybwol)
    {
        if (value < board / 100 && value >= 1e+3 && value >= board / 1000)
        {
            textOfValue.text = frontSybwol + Math.Floor(value / (board / 1000)) + "." + Math.Floor(value / (board / 10000)).ToString().Remove(0, 1) + sybwolOfValue;
        }
        else if (value < board && value >= board / 1000)
        {
            textOfValue.text = frontSybwol +Math.Floor(value / (board / 1000)) + sybwolOfValue;
        }
    }
}
