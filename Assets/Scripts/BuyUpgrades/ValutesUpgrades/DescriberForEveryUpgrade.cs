using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DescriberForEveryUpgrade : MonoBehaviour
{
   public DimondUpgrades DimondUpgrades;
}

public enum DimondUpgrades
{
   MoreCoinsUpgrade,
   MoreDimondsUpgrade,
   MoreTimeToGoldFruitsUpgrade,
   MoreDimondFruitsUpgrade
}
