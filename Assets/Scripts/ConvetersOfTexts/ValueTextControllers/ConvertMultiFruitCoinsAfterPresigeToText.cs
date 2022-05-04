using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class ConvertMultiFruitCoinsAfterPresigeToText : MonoBehaviour
{
    // CLass Needed to convert Texts
    public FruitCoinsValuteController FruitCoins;

    // Texts to Convert
    public Text TextOfMultiFruitCoinsAfterPrestige;

    // Convert Value Of MultiFruitCoins to text
    private void SetMultiFruitCoinsAfterPrestige()
    {
        TextOfMultiFruitCoinsAfterPrestige.text = (FruitCoins.BasicValue / (1000 * 1000)).ToString();
    }
}
