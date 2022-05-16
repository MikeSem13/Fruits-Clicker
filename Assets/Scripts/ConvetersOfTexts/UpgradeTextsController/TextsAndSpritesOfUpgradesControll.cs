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
        //switch (BuyButton.Values)
       // {
          //  case Values.Basic:
            {
               ConvertPriceOfBasicValueText(i);
            }
               // break;
          //  case Values.Billons:
                ConvertPriceOfBiggerValuesText(i,"B","T","q");
                //break;
           // case Values.Quintillions:
                ConvertPriceOfBiggerValuesText(i,"Q","S", "s");
                //break;
        //}
    }

    public void ConvertPriceOfBasicValueText(int i)
    {
        if (Buttons[i].price[Buttons[i].CurrentLevel] <= 999)
        {
            TextsOfPrice[i].text = Buttons[i].price[Buttons[i].CurrentLevel].ToString();
            TextsOfPrice[i].fontSize = 102;
        }
        if (Buttons[i].price[Buttons[i].CurrentLevel] > 999) TextsOfPrice[i].text = Math.Round(Buttons[i].price[Buttons[i].CurrentLevel] / 1000, 1) + "k";
        if (Buttons[i].price[Buttons[i].CurrentLevel] > 9999) TextsOfPrice[i].text = Buttons[i].price[Buttons[i].CurrentLevel] / 1000 + "k";
        if(Buttons[i].price[Buttons[i].CurrentLevel] > 99999) TextsOfPrice[i].fontSize = 90;
        if (Buttons[i].price[Buttons[i].CurrentLevel] > 999999) TextsOfPrice[i].text = Math.Round(Buttons[i].price[Buttons[i].CurrentLevel] / (1000 * 1000), 1) + "M";
        if (Buttons[i].price[Buttons[i].CurrentLevel] > 99999999)
        {
            TextsOfPrice[i].text = Buttons[i].price[Buttons[i].CurrentLevel] / (1000 * 1000)+ "M";
            TextsOfPrice[i].fontSize = 80;
        }
    }

    public void ConvertPriceOfBiggerValuesText(int i, string _firstSymbwol, string _secondSymbwol, string _thirdSymbwol)
    {
        if (Buttons[i].price[Buttons[i].CurrentLevel] <= 9)
        {
            TextsOfPrice[i].text = Buttons[i].price[Buttons[i].CurrentLevel] + _firstSymbwol;
            TextsOfPrice[i].fontSize = 97;
        }
        if (Buttons[i].price[Buttons[i].CurrentLevel] > 9)
        {
            TextsOfPrice[i].text = Buttons[i].price[Buttons[i].CurrentLevel] + _firstSymbwol;
            TextsOfPrice[i].fontSize = 102;
        }

        if (Buttons[i].price[Buttons[i].CurrentLevel] > 99)
        {
            TextsOfPrice[i].fontSize = 87;
        }
    }

    public void ConvertMultiOfUpgradeToText(int i)
    {
        if (Buttons[i].TypeOfUpgrade == TypesOfUpgrades.CoinsUpgrade)
        {
            if(Buttons[i].multi[Buttons[i].CurrentLevel] <= 999) TextsOfMulti[i].text = "+" + Buttons[i].multi[Buttons[i].CurrentLevel];   
            if(Buttons[i].multi[Buttons[i].CurrentLevel] > 999) TextsOfMulti[i].text = "+" + Math.Round((float)Buttons[i].multi[Buttons[i].CurrentLevel] / 1000, 1) + "k";
            if(Buttons[i].multi[Buttons[i].CurrentLevel] > 9999) TextsOfMulti[i].text = "+" + Buttons[i].multi[Buttons[i].CurrentLevel] / 1000;   
            if(Buttons[i].multi[Buttons[i].CurrentLevel] > 999999) TextsOfMulti[i].text = "+" + Math.Round((float)Buttons[i].multi[Buttons[i].CurrentLevel] / (1000 * 1000), 1) + "M";
            if(Buttons[i].multi[Buttons[i].CurrentLevel] > 9999999) TextsOfMulti[i].text = "+" + Buttons[i].multi[Buttons[i].CurrentLevel] / (1000 / 1000) + "M";
        }
    }
}
