using UnityEngine;
using UnityEngine.UI;

public class ConvertingMultiFruitCoins : MonoBehaviour
{
    public FruitCoinsValuteController FruitCoins;
    public MultiFruitCoinsValueController MultiFruitCoins;

    private int _multiOfAdd;

    public void ConvertFruitCoinsToMultiFruitCoins()
    {
        float FruitCoinsToConvert = FruitCoins.BillionValue;
      
        float StorageOfMultiFruitCoins = 0;
      
        float FirstCountOfCoins = 1f;
        float SecondCountOfCoins = 0.5f;
        float ThirdCountOfCoins = 0.25f;
        float FourthCountOfCoins = 0.10f;

        int FirstMark = 15;
        int SecondMark = 250;
        int ThirdMark = 1000;
        int FourthMark = 75000;

        int LastMark = FourthMark;
        
        for (int i = 0; FruitCoinsToConvert >= 1 ; i++)
        {
            if (i < FirstMark)
            {
                StorageOfMultiFruitCoins += FirstCountOfCoins;
            }
            else if(i < SecondMark)
            {
                StorageOfMultiFruitCoins += SecondCountOfCoins;
            }
            else if(i < ThirdMark)
            {
                StorageOfMultiFruitCoins += ThirdCountOfCoins;
            }
            else if(i < FourthMark)
            {
                StorageOfMultiFruitCoins += FourthCountOfCoins;
            }
            else if(i > LastMark)
            {
                StorageOfMultiFruitCoins += FourthCountOfCoins;
            }

            FruitCoinsToConvert -= 1;
        }
        MultiFruitCoins.MultiFruitCoinsAfterRebirth = StorageOfMultiFruitCoins * MultiFruitCoins.MainMulti;
    }
}
