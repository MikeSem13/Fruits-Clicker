using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllCurrentFruitInList : MonoBehaviour
{
    // Variables Of Current Fruit In List
    public int CurrentFruitsInNumberInList;
    public String CurrentFruitsInStringInList;

    // Method Which Choose Current Fruit In List
    public void ChooseFruitToList(DescriberForFruitsInList Describer)
    {
        if (Describer.fruits == Fruits.Apple)
        {
            CurrentFruitsInStringInList = "Apple";
            CurrentFruitsInNumberInList = 0;
        }

        if (Describer.fruits == Fruits.Banana)
        {
            CurrentFruitsInStringInList = "Banana";
            CurrentFruitsInNumberInList = 1;
        }

        if (Describer.fruits == Fruits.Orange)
        {
            CurrentFruitsInStringInList = "Orange";
            CurrentFruitsInNumberInList = 2;
        }
    }
}
