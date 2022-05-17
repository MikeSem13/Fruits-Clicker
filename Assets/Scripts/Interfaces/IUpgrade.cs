using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

 public interface IUpgrade
{
   public void BuyUpgrade(string UpgradeName);
   public void GetReward(UpgradeModel upgradeModel);
}
