using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeButonsManager : MonoBehaviour
{ 
    [SerializeField] private ValuteManager valuteManager;
    [SerializeField] private UpgradeManager upgradeManager;

    private void Update()
    {
        for (int i = 0; i < upgradeManager.Upgrades.Count; i++)
        {
            ImageOfButtonController(upgradeManager.Upgrades[i].NameOfUpgrade);   
        }

        for (int i = 0; i < upgradeManager.Upgrades.Count; i++)
        {
            SpritesOfButtonController(upgradeManager.Upgrades[i].NameOfUpgrade,upgradeManager.Upgrades[i].NameOfValute);
        }
    }

    public void ImageOfButtonController(string NameOfUpgrade)
    {
        UpgradeModel upgradeModel = upgradeManager.Upgrades.FirstOrDefault(model => model.NameOfUpgrade == NameOfUpgrade);
        
        if (upgradeModel.CurrentPrice >= upgradeModel.Prices.Count)
        {
            upgradeModel.Button.ValuteImage.gameObject.SetActive(false);
        }
        else
        {
            upgradeModel.Button.ValuteImage.gameObject.SetActive(true);
        }
    }

    public void SpritesOfButtonController(string NameOfUpgrade, string NameOfValute)
    {
        UpgradeModel upgradeModel = upgradeManager.Upgrades.FirstOrDefault(model => model.NameOfUpgrade == NameOfUpgrade);
        ValutesModel valuteModel = valuteManager.Valutes.FirstOrDefault(model => model.NameOfValute == NameOfValute);

        if (upgradeModel.CurrentPrice < upgradeModel.Prices.Count)
        {
            if (valuteModel.Values[upgradeModel.Prices[upgradeModel.CurrentPrice].NumberOfValuePrice].Valute >= upgradeModel.Prices[upgradeModel.CurrentPrice].Price)
            {
                upgradeModel.Button.BuyButton.image.sprite = upgradeManager.ActiveSprite;
            }
            else
            {
                for (int i = 0; i < valuteModel.Values.Count; i++)
                {
                    if (valuteModel.Values[i].Valute >= 1 && valuteModel.NumberOfValue > upgradeModel.Prices[upgradeModel.CurrentPrice].NumberOfValuePrice)
                    {
                        upgradeModel.Button.BuyButton.image.sprite = upgradeManager.ActiveSprite;
                    }
                    else if(valuteModel.NumberOfValue <= upgradeModel.Prices[upgradeModel.CurrentPrice].NumberOfValuePrice)
                    {
                        upgradeModel.Button.BuyButton.image.sprite = upgradeManager.NonActiveSprite;
                    }
                }
            }
        }
        else upgradeModel.Button.BuyButton.image.sprite = upgradeManager.ActiveSprite;
    }
}
