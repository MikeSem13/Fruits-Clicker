using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetValueFromClickController : MonoBehaviour
{
    public ValuteController Valutes;
    public CreateATextsOfFruitCoins CreateAText;
    public OnClickOfFruitsAnimation ClickFruitAnimation;
    public GetBonusMulti BonusMulti;
    public GetLevelForSuchFruit LevelFruit;

    public void GetValuesFromClick()
    {
        Valutes.IFruitCoins.AddValute();
        Valutes.IFruitDimonds.AddValute();
        OtherEfectsForClickFruit();
    }

    public void OtherEfectsForClickFruit()
    {
        BonusMulti.GetMultiBonus();
        CreateAText.MotionOnClick();
        ClickFruitAnimation.OnClickAnimation();
        LevelFruit.ClickToGetLevel();
    }
}
