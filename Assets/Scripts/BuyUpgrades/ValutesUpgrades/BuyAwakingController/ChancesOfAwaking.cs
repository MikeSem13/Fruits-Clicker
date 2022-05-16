using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using Random = UnityEngine.Random;

public class ChancesOfAwaking : MonoBehaviour
{
    public BuyFruit Fruts;
    public GenerateCountOfBoostControll GenerateCountOfBoostControll;
    
    [Header("Шансы")]
    public int [] ChancesOfTypeBoost;
    public int [] ChancesOfTypeCountBoost;
    [Header("Типы вознограждений")]
    public List<TypesOfAwaking> AwakingRewards; 
    public List<TypesOfCountBoost> CountBoostsRewards;
    [Header("Рандомные числа")]
    public int TotalChance;
    public int RandomNumOfTypeBoost;
    public int RandomNumOfTypeCountBoost;

    private void Start()
    {
        foreach (var chances in ChancesOfTypeBoost)
        {
            TotalChance += chances;
        }
    }

    public void GenerateATypeOfBoost()
    {
        RandomNumOfTypeBoost = Random.Range(0,TotalChance);

        for (int i = 0; i < ChancesOfTypeBoost.Length; i++)
        {
            if (RandomNumOfTypeBoost <= ChancesOfTypeBoost[i])
            {
                Fruts.AllFruitsDesctiber[Fruts.ControllCurrentFruitInList.CurrentFruitsInNumberInList].Awaking = AwakingRewards[i];
                Fruts.AllFruitsDesctiber[Fruts.ControllCurrentFruitInList.CurrentFruitsInNumberInList].CurrentAwakingInString = Fruts.AllFruitsDesctiber[Fruts.ControllCurrentFruitInList.CurrentFruitsInNumberInList].Awaking.ToString();
                GenerateATypeCountOfBoost();
            }
            else
            {
                RandomNumOfTypeBoost -= ChancesOfTypeBoost[i];
            }
        }
    }

    public void GenerateATypeCountOfBoost()
    {
        RandomNumOfTypeCountBoost = Random.Range(0, TotalChance);
        
        for (int i = 0; i < ChancesOfTypeCountBoost.Length; i++)
        {
            if (RandomNumOfTypeCountBoost <= ChancesOfTypeCountBoost[i])
            {
                Fruts.AllFruitsDesctiber[Fruts.ControllCurrentFruitInList.CurrentFruitsInNumberInList].TypeOfCountBoost = CountBoostsRewards[i];
                GenerateCountOfBoostControll.GenerateCount(Fruts.AllFruitsDesctiber[Fruts.ControllCurrentFruitInList.CurrentFruitsInNumberInList]);
            }
            else
            {
                RandomNumOfTypeCountBoost -= ChancesOfTypeCountBoost[i];
            }
        }
    }
}

public enum TypesOfCountBoost
{
    None,
    SmallBoost,
   MiddleBoost,
   LargeBoost,
}
