using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Take : MonoBehaviour
{
    [Header("Classes")] 
    [SerializeField] private ValuteManager valuteManager;

    public void TakeValues(ref double valute, double addValue)
    {
        valute -= addValue;
    }
}
