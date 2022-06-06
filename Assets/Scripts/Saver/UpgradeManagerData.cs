using System;

[Serializable] public class UpgradeManagerData
{
    public UpgradeModel [] Upgrades;

    public void TakeToSave(UpgradeManager upgradeManager)
    {
        for (int i = 0; i < Upgrades.Length; i++)
        {
            Upgrades[i].CurrentPrice = upgradeManager.Upgrades[i].CurrentPrice;
            Upgrades[i].Prices = upgradeManager.Upgrades[i].Prices;
            Upgrades[i].RewardMultis = upgradeManager.Upgrades[i].RewardMultis;
            Upgrades[i].SpecialRewards = upgradeManager.Upgrades[i].SpecialRewards;
        }
    }

    public void ReturnSave(UpgradeManager upgradeManager)
    {
        for (int i = 0; i < upgradeManager.Upgrades.Length; i++)
        {
            upgradeManager.Upgrades[i].CurrentPrice = Upgrades[i].CurrentPrice;
            upgradeManager.Upgrades[i].Prices = Upgrades[i].Prices;
            upgradeManager.Upgrades[i].RewardMultis = Upgrades[i].RewardMultis;
            upgradeManager.Upgrades[i].SpecialRewards = Upgrades[i].SpecialRewards;
        }
    }
}
