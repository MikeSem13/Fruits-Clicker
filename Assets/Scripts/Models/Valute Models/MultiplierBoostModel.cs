using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable] public class MultiplierBoostModel
{ 
    [Header("Название буста")]
    public string NameOfBoost;

    [Space]
    [Header("Буст")]
    public double Boost = 1;
}
