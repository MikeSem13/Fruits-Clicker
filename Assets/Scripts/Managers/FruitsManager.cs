using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class FruitsManager : MonoBehaviour
{
    [Header("Классы")]
    [SerializeField] private ValuteManager valuteManager;

    public FruitModel [] FruitModels;

    public FruitModel SelectedFruit;

    public void Start()
    {
        foreach (FruitModel Fruit in FruitModels) if (Fruit.IsSelected) SelectedFruit = Fruit;
    }

    public void BuyFruit(string fruitName)
    {
        FruitModel buyFruit = FruitModels.FirstOrDefault(fruit => fruit.FruitName == fruitName);

        valuteManager.valutesMathOperations.TakeValute(valuteManager.GetValute("MultiFruit Coins").NameOfValute, buyFruit.Price);
        buyFruit.IsBuy = true;
    }

    public void SelectFruit(string fruitName)
    {
        FruitModel buyFruit = FruitModels.FirstOrDefault(fruit => fruit.FruitName == fruitName);

        buyFruit.IsSelected = true;
        for (int i = 0; i < FruitModels.Length; i++)  if (FruitModels[i].FruitName != buyFruit.FruitName) FruitModels[i].IsSelected = false;
    }
}
