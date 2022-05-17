using System;
using UnityEngine;
using UnityEngine.UI;

[Serializable] public class RewardMultiOfUpgradeModel
{
    [Header("Множитель")]
    public float Multi;
    [Space]
    [Header("Размерность множителя")]
    public ValuesEnum RewardMultiValue;
    [Header("Дополнительные параметры")]
    public int NumberOfValueMulti;
}
