using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Serialization;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class BuyButtons : MonoBehaviour, IPointerClickHandler
{
    public BuyUpgrades Upgrades;
    
    [Header("Типы Апгрейдов")]
    public TypesOfUpgrades TypeOfUpgrade;
    public TypesOfDinondsUpgrades TypesOfDinondsUpgrades;
    public TypesOfMultiFruitCoinsUpgrades TypesOfMultiFruitCoinsUpgrades;
    [Header("Типы Размеров цен апргрейдов")]

    // Prcie Of Upgrades
    [Header("Цены")]
    public List<float> price;

    // Multi of Upgrades
    [Header("Множители")]
    public List<int> multi;

    
    // Levels of Upgrades
    [Header("Уровни апгрейдов и доплнительные переменные")]
    public int MaxLevel;
    public int CurrentLevel;

    public Image BackgroundOfButton;

    private void Start()
    {
        BackgroundOfButton = GetComponent<Image>();
        Upgrades.SubscribeAllButtons(this);
    }
    
    private void Update()
    {
        Upgrades.SetSpritesForButton();
    }

    
    public void OnPointerClick(PointerEventData eventData)
    {
        Upgrades.BuyUpgrade(this);
    }
}

public enum TypesOfUpgrades
{
    CoinsUpgrade,
    DimondsUpgrade,
    MultiFruitCoinsUpgrade,
}

public enum TypesOfDinondsUpgrades
{
    UpgradeForMoreCoins,
    UpgradeForMoreDimonds,
    UpgradeForMoreTimeForBoost,
    UpgradeForMoreDimondFruits
}

public enum TypesOfMultiFruitCoinsUpgrades
{
    UpgradeForMoreLevel,
    UpgradeForMoreMultiFruitCoins,
    UpgradeForMoreDimonds2,
}