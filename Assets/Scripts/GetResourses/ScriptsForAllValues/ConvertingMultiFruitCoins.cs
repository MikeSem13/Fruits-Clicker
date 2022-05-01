using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConvertingMultiFruitCoins : MonoBehaviour
{
    public FruitCoinsValuteController FruitCoins;
    public MultiFruitCoinsValueController MultiFruitCoins;

    public void ConvertFruitCoinsToMultiFruitCoins()
    {
        int FruitCoinsToConvert = FruitCoins.BillionValue;
      
        float StorageOfMultiFruitCoins = 0;
      
        float FirstCountOfCoins = 1f;
        float SecondCountOfCoins = 0.5f;

        int FirstMark = 15;
        int SecondMark = 250;

        int LastMark = SecondMark;
        
        for (int i = 0; FruitCoinsToConvert > 0 ; i++)
        {
            if (i < FirstMark)
            {
                StorageOfMultiFruitCoins += FirstCountOfCoins;
            }
            else if(i < SecondMark)
            {
                StorageOfMultiFruitCoins += SecondCountOfCoins;
            }
            else if(i > LastMark)
            {
                StorageOfMultiFruitCoins += SecondCountOfCoins;
            }

            FruitCoinsToConvert -= 1;
        }
        MultiFruitCoins.MultiFruitCoinsAfterRebirth = (int)StorageOfMultiFruitCoins * MultiFruitCoins.MainMulti;
    }
}
