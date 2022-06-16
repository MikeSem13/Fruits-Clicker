
using System.Linq;
using UnityEngine;

public class Add : MonoBehaviour
{
    public void AddValues(ref double value, double addValue)
    {
         value += addValue;
    }

    public void AddValuesWithChance(ref double value, double addValue, double percent)
    {
        int Chance = Random.Range(0, 100);
        if (Chance < percent) value += addValue;
    }
}
