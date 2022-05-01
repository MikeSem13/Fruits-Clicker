using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class TextsAndSpritesOfUpgradesControll : MonoBehaviour
{
    public List<BuyButtons> Buttons;
    public TextMaxControllerForUpgrades TextMax;

    // All Texts of Coins Upgrades
    public List<Text> TextsOfPrice;
    public List<Text> TextsOfMulti;
    public List<Image> ImagesOFButtons;

    // Save CurrentLevel Of Upgrades
    private void Start()
    {
        for (int i = 0; i < Buttons.Count; i++)
        {
            Buttons[i].CurrentLevel = PlayerPrefs.GetInt("CLevel" + i);
        }
    }

    private void Update()
    {
        ConvertAllTextsOfUpgrades();
    }

    public void ConvertAllTextsOfUpgrades()
    {
        // ConvertTexts
        for (int i = 0; i < TextsOfPrice.Count; i++)
        {
            if (Buttons[i].CurrentLevel <= Buttons[i].MaxLevel - 1)
            {
                ConvertValueOfPriceToText(Buttons[i],i);
                ConvertMultiOfUpgradeToText(i);
                ImagesOFButtons[i].gameObject.SetActive(true);
                TextsOfPrice[i].gameObject.transform.localPosition = new Vector2(78.43535f,-0.00039959f);
            }
            else if(Buttons[i].CurrentLevel == Buttons[i].MaxLevel)
            {
                TextMax.SetMaxTexts(i);
                ImagesOFButtons[i].gameObject.SetActive(false);
            }
        }
        
        // Save CurrentLevel Of Upgrades

        for (int i = 0; i < Buttons.Count; i++)
        {
            PlayerPrefs.SetInt("CLevel" + i, Buttons[i].CurrentLevel);
        }
    }
    
    
    public void ConvertValueOfPriceToText(BuyButtons BuyButton,int i)
    {
        switch (BuyButton.Values)
        {
            case Values.Basic:
            {
                if(Buttons[i].price[Buttons[i].CurrentLevel] < 999)TextsOfPrice[i].text = Buttons[i].price[Buttons[i].CurrentLevel].ToString();
                if (Buttons[i].price[Buttons[i].CurrentLevel] > 999) TextsOfPrice[i].text = Math.Round(Buttons[i].price[Buttons[i].CurrentLevel] / 1000, 1).ToString() + "k";
                if (Buttons[i].price[Buttons[i].CurrentLevel] > 9999 ) TextsOfPrice[i].text = Math.Round(Buttons[i].price[Buttons[i].CurrentLevel] / 1000, 0).ToString() + "k";
                if (Buttons[i].price[Buttons[i].CurrentLevel] > 99999 &&  Buttons[i].price[Buttons[i].CurrentLevel] <= 99999999) TextsOfPrice[i].fontSize = 90;
                if (Buttons[i].price[Buttons[i].CurrentLevel] > 99999999) TextsOfPrice[i].fontSize = 80;
                if (Buttons[i].price[Buttons[i].CurrentLevel] > 999999) TextsOfPrice[i].text = Math.Round(Buttons[i].price[Buttons[i].CurrentLevel] / (1000 * 1000), 1).ToString() + "M";
            }
                break;
            case Values.Billons:
                TextsOfPrice[i].text = Buttons[i].price[Buttons[i].CurrentLevel] + "B";
                if (Buttons[i].price[Buttons[i].CurrentLevel] > 999) TextsOfPrice[i].text = Math.Round(Buttons[i].price[Buttons[i].CurrentLevel] / 1000, 1).ToString() + "T";
                if (Buttons[i].price[Buttons[i].CurrentLevel] > 9999 ) TextsOfPrice[i].text = Math.Round(Buttons[i].price[Buttons[i].CurrentLevel] / 1000, 0).ToString() + "T";
                if (Buttons[i].price[Buttons[i].CurrentLevel] > 99999 &&  Buttons[i].price[Buttons[i].CurrentLevel] <= 99999999) TextsOfPrice[i].fontSize = 90;
                if (Buttons[i].price[Buttons[i].CurrentLevel] > 99999999 ) TextsOfPrice[i].fontSize = 80;
                if (Buttons[i].price[Buttons[i].CurrentLevel] > 999999) TextsOfPrice[i].text = Math.Round(Buttons[i].price[Buttons[i].CurrentLevel] / (1000 * 1000), 1).ToString() + "q";
                break;
            case Values.Quintillions:
                TextsOfPrice[i].text = Buttons[i].price[Buttons[i].CurrentLevel] + "Q";
                if (Buttons[i].price[Buttons[i].CurrentLevel] > 999) TextsOfPrice[i].text = Math.Round(Buttons[i].price[Buttons[i].CurrentLevel] / 1000, 1).ToString() + "S";
                if (Buttons[i].price[Buttons[i].CurrentLevel] > 9999 ) TextsOfPrice[i].text = Math.Round(Buttons[i].price[Buttons[i].CurrentLevel] / 1000, 0).ToString() + "S";
                if (Buttons[i].price[Buttons[i].CurrentLevel] > 99999 &&  Buttons[i].price[Buttons[i].CurrentLevel] <= 99999999) TextsOfPrice[i].fontSize = 90;
                if (Buttons[i].price[Buttons[i].CurrentLevel] > 99999999) TextsOfPrice[i].fontSize = 80;
                if (Buttons[i].price[Buttons[i].CurrentLevel] > 999999) TextsOfPrice[i].text = Math.Round(Buttons[i].price[Buttons[i].CurrentLevel] / (1000 * 1000), 1).ToString() + "s";
                break;
        }
    }

    public void ConvertMultiOfUpgradeToText(int i)
    {
        if (Buttons[i].TypeOfUpgrade == TypesOfUpgrades.CoinsUpgrade)
        {
            if(Buttons[i].multi[Buttons[i].CurrentLevel] <= 999) TextsOfMulti[i].text = "+" + Buttons[i].multi[Buttons[i].CurrentLevel].ToString();   
            if(Buttons[i].multi[Buttons[i].CurrentLevel] > 999) TextsOfMulti[i].text = "+" + Math.Round((float)Buttons[i].multi[Buttons[i].CurrentLevel] / 1000, 1) + "k";   
        }
    }
}
