using System;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

[Serializable] public class MultiRewardOfUpgradeModel
{
    [Header("Награда")]
    public float RewardMulti;
    public float LastRewardMulti;
    
    [Space]
    [Header("Размерность награды")]
    public ValuesEnum Value;
    
    [Space]
    [Header("Дополнительные параметры")]
    public int NumberOfValueRewardMulti;
}
