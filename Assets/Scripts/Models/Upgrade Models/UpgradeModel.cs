using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

[Serializable] public class UpgradeModel
{
  [Space]
  [Header("Имя апгрейда")]
  public string NameOfUpgrade;
  
  [Space]
  [Header("Имя валюты апгрейда")]
  public string NameOfValute;
  
  [Space]
  [Header("Цены")]
  public PriceOfUpgradeModel [] Prices;
  
  [Space]
  [Header("Награды с множителем")]
  public MultiRewardOfUpgradeModel [] RewardMultis;
  [Space]
  [Header("Специальные награды")]
  
  public SpecialRewardsOfUpgradeModel[] SpecialRewards;
  
  [Space] 
  [Header("Кнопка")] 
  public UpgradeButton Button;
  
  [Space] 
  [Header("Активация специальных наград")]
  public bool SpecialReward;
  
  [Space]
  [Header("Тип специальных наград")]
  public SpecialUpgradesEnum TypeOfSpecialUpgrade;
  
  [Space]
  [Header("Текущая цена")]
  public int CurrentPrice;

  [Space]
  [Header("Текста")]
  public Text TextOfMulti;
}