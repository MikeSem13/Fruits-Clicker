using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class TextMaxControllerForUpgrades : MonoBehaviour
{
    // Nedded Class
    public TextsAndSpritesOfUpgradesControll Converter;

    // Convert Text And Set Transform Of Upgrade Panels
    public void SetMaxTexts(int i)
    {
        Converter.TextsOfPrice[i].text = "Max";
        Converter.TextsOfPrice[i].gameObject.transform.localPosition = new Vector2();
        Converter.TextsOfPrice[i].fontSize = 102;
        Converter.ImagesOFButtons[i].gameObject.SetActive(false);
        if (Converter.Buttons[i].TypeOfUpgrade == TypesOfUpgrades.CoinsUpgrade)
        {
            if(Converter.Buttons[i].multi.Sum() < 999)Converter.TextsOfMulti[i].text = "+" + Converter.Buttons[i].multi.Sum();   
            if(Converter.Buttons[i].multi.Sum() > 999)Converter.TextsOfMulti[i].text = "+" + (Converter.Buttons[i].multi.Sum() / 1000)+ "k";   
        }
    }
}