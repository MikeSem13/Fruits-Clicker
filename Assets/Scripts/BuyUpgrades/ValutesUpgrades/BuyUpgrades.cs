using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuyUpgrades : MonoBehaviour
{
    public ValuteController Valutes;
    public UpgradesForCoinsController CoinsUpgrade;
    public UpgradesForDimondsController DimondUpgrades;
    public UpgradesForMultiFruitCoinsController MultiFruitCoinsUpgrade;
   
    public List<BuyButtons> Buttons;


    public Sprite ActibeToBuy;
    public Sprite NonActiveToBuy;

    public float ValueForBuy;

    public void SubscribeAllButtons(BuyButtons Button)
    {
        Buttons ??= new List<BuyButtons>();
        Buttons.Add(Button);
    }

    public void BuyUpgrade(BuyButtons buyButtons)
    {
        if(buyButtons.TypeOfUpgrade == TypesOfUpgrades.CoinsUpgrade) CoinsUpgrade.BuyFruitCoinsUpgrade(buyButtons);
        if(buyButtons.TypeOfUpgrade == TypesOfUpgrades.DimondsUpgrade) DimondUpgrades.BuyDimondUpgrades(buyButtons);
        if(buyButtons.TypeOfUpgrade == TypesOfUpgrades.MultiFruitCoinsUpgrade) MultiFruitCoinsUpgrade.BuyMultiFruitUpgrades(buyButtons);
    }
    
    public void SetSpritesForButton()
    {
        foreach (BuyButtons Button in Buttons)
        {
            SetValuteForBuy(Button,Valutes);

            int ValueOfMinusLevel = 0;
            if (Button.CurrentLevel < Button.MaxLevel - 1) ValueOfMinusLevel = 0;
            if (Button.CurrentLevel == Button.MaxLevel) ValueOfMinusLevel = 1;
         
            if (ValueForBuy >= Button.price[Button.CurrentLevel - ValueOfMinusLevel] & Button.CurrentLevel < Button.MaxLevel)
            {
                Button.BackgroundOfButton.sprite = ActibeToBuy;
            }
            else
            {
                Button.BackgroundOfButton.sprite = NonActiveToBuy;
            }

            if (Button.CurrentLevel == Button.MaxLevel)
            {
                Button.BackgroundOfButton.sprite = ActibeToBuy;
            }
        }
    }

    public void SetValuteForBuy(BuyButtons Button, ValuteController ValuteController )
    {
        if (Button.TypeOfUpgrade == TypesOfUpgrades.CoinsUpgrade)
        {
           SetValueForBuy(Button,ValuteController.IFruitCoins);
        }
      
        if (Button.TypeOfUpgrade == TypesOfUpgrades.DimondsUpgrade)
        {
            SetValueForBuy(Button,ValuteController.IFruitDimonds);
        }

        if (Button.TypeOfUpgrade == TypesOfUpgrades.MultiFruitCoinsUpgrade)
        {
            SetValueForBuy(Button,ValuteController.IMultiFruitCoins);
        }
    }
    
    public void SetValueForBuy(BuyButtons Button,IValuteController ValuteController)
    {
        if (Button.Values == Values.Basic)
        {
            ValueForBuy = ValuteController.BasicValue;
        }
      
        if (Button.Values == Values.Billons)
        {
            ValueForBuy = ValuteController.BillionValue;
        }

        if (Button.Values == Values.Quintillions)
        {
            ValueForBuy = ValuteController.QuintillionValue;
        }
    }
}
