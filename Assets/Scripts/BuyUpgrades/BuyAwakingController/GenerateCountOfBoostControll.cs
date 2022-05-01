using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateCountOfBoostControll : MonoBehaviour
{
    public int RandomCountOfBoost;

    public void GenerateCount(DescriberForFruitsInList Describer)
    {
        if (Describer.Awaking == TypesOfAwaking.FruitCoinsAwaking)
        {
            if (Describer.TypeOfCountBoost == TypesOfCountBoost.SmallBoost)
            {
                RandomCountOfBoost = Random.Range(2, 5);
            }
            if (Describer.TypeOfCountBoost == TypesOfCountBoost.MiddleBoost)
            {
                RandomCountOfBoost = Random.Range(4, 9);
            }
            if (Describer.TypeOfCountBoost == TypesOfCountBoost.LargeBoost)
            {
                RandomCountOfBoost = Random.Range(7, 14);
            }
        } 
        if (Describer.Awaking == TypesOfAwaking.FruitDimondsAwaking)
        {
            if (Describer.TypeOfCountBoost == TypesOfCountBoost.SmallBoost)
            {
                RandomCountOfBoost = Random.Range(2, 5);
            }
            if (Describer.TypeOfCountBoost == TypesOfCountBoost.MiddleBoost)
            {
                RandomCountOfBoost = Random.Range(3, 7);
            }
            if (Describer.TypeOfCountBoost == TypesOfCountBoost.LargeBoost)
            {
                RandomCountOfBoost = Random.Range(5, 10);
            }
        } 
        if (Describer.Awaking == TypesOfAwaking.MultiFruitCoinsAwaking)
        {
            if (Describer.TypeOfCountBoost == TypesOfCountBoost.SmallBoost)
            {
                RandomCountOfBoost = Random.Range(2, 4);
            }
            if (Describer.TypeOfCountBoost == TypesOfCountBoost.MiddleBoost)
            {
                RandomCountOfBoost = Random.Range(3, 6);
            }
            if (Describer.TypeOfCountBoost == TypesOfCountBoost.LargeBoost)
            {
                RandomCountOfBoost = Random.Range(5, 8);
            }
        }

        Describer.CountOfMultiAwaking = RandomCountOfBoost;
    }
}
