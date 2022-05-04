using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FruitsController : MonoBehaviour
{
    // Variables for Fruits Controller
    public String CurrentFruitInString;
    public int CurrentFruitInNumber;
    public List<String> AllFruits;

    // Save all Variables
    private void Start()
    {
        CurrentFruitInNumber = PlayerPrefs.GetInt("CFruit");
        CurrentFruitInString = PlayerPrefs.GetString("CFruitS");
    }

    private void Update()
    {
        SetStringOfFruits();
        
        PlayerPrefs.SetInt("CFruit", CurrentFruitInNumber);
        PlayerPrefs.SetString("CFruitS", CurrentFruitInString);
    }

    // Method to choose current fruit
    public void SetStringOfFruits()
    {
        if (CurrentFruitInNumber == 0) CurrentFruitInString = "Яблоко";
        if (CurrentFruitInNumber == 1) CurrentFruitInString = "Банан";
        if (CurrentFruitInNumber == 2) CurrentFruitInString = "Апельсин";
    }
}
