
using System.Linq;
using UnityEngine;

public class Add : MonoBehaviour
{ 
    [Header("Classes")] 
    [SerializeField] private ValuteManager valuteManager;

    public void AddValues(ref float value, float addValue)
    {
         value += addValue;
    }

    public void AddValuesWithChance(ref float value, float addValue, float percent)
    {
        int Chance = Random.Range(0, 100);
        if (Chance < percent) value += addValue;
    }
}
