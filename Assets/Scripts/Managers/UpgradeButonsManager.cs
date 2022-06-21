using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeButonsManager : MonoBehaviour
{
    [SerializeField] private ValuteManager valuteManager;
    private UpgradeManager upgradeManager;

    private void Start()
    {
        upgradeManager = GetComponent<UpgradeManager>();
    }

    private void Update()
    {
        for (int i = 0; i < upgradeManager.Upgrades.Length; i++)
        {
            ImageOfButtonController(upgradeManager.Upgrades[i].NameOfUpgrade);
        }

        for (int i = 0; i < upgradeManager.Upgrades.Length; i++)
        {
            SpritesOfButtonController(upgradeManager.Upgrades[i].NameOfUpgrade,
                upgradeManager.Upgrades[i].NameOfValute);
        }
    }

    public void ImageOfButtonController(string NameOfUpgrade)
    {
        UpgradeModel upgradeModel =
            upgradeManager.Upgrades.FirstOrDefault(model => model.NameOfUpgrade == NameOfUpgrade);

        if (upgradeModel.CurrentPrice >= upgradeModel.Prices.Length)
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

        if (upgradeModel.CurrentPrice < upgradeModel.Prices.Length)
        {
            if (valuteModel.Valute >= upgradeModel.Prices[upgradeModel.CurrentPrice].Price)
            {
                upgradeModel.Button.BuyButton.image.sprite = upgradeManager.ActiveSprite;
            }
            else
            {
                upgradeModel.Button.BuyButton.image.sprite = upgradeManager.NonActiveSprite;
            }
        }
        else
        {
            upgradeModel.Button.BuyButton.image.sprite = upgradeManager.ActiveSprite;
        }
    }
}