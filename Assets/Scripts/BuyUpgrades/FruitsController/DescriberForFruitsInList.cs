using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DescriberForFruitsInList : MonoBehaviour
{
    public BuyFruit Buyfruit;

    // Variebles of fruit
    [Header("Переменные определяющие тип фрукта")]
    public Fruits fruits;
    public TypesOfAwaking Awaking;
    public TypesOfCountBoost TypeOfCountBoost;

    [Header("Переменные определяющие тип фрукта")]
    public String CurrentAwakingInString;
    public int LevelOfFruit;
    public int MaxLevelOfFruit;
    public int price;
    public int multi;
    public int CountOfMultiAwaking;

    [Header("Переменные определяющие состояние фрукта")]
    public bool IsUnlocked;
    public bool IsBuying;
    public bool IsSelected;
    public bool IsAwaking;
    
    [Header("Переменные связанные с уровнем")]
    
    public int CurrentClickOfLevel;
    public List<int> CountOfClicksToLevelUpFruit;
    
    private void Start()
    {
        Buyfruit.Subscribe(this);
        if (fruits == Fruits.Apple) IsBuying = true;
    }

    private void Update()
    {
        if (Awaking == TypesOfAwaking.None)
        {
            TypeOfCountBoost = TypesOfCountBoost.None;
        }
    }
}

// List of all fruits
public enum Fruits
{
    Apple,
    Banana,
    Orange
}
