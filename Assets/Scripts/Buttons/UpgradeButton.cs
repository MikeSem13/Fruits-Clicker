using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[Serializable] public class UpgradeButton
{
    [Header("Кнопка и её параметры")]
    public Button BuyButton;
    public Text TextOfPrice;
    public Image ValuteImage;
}