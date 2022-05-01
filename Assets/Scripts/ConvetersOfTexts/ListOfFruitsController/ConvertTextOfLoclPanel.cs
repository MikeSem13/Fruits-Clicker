using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ConvertTextOfLoclPanel : MonoBehaviour
{
    public Text TextOfRequpments;

    // Convert Requpments to Texts
    public void SelectTextToRequpment(DescriberForFruitsInList Describer)
    {
        if (Describer.fruits == Fruits.Banana)
        {
            TextOfRequpments.text = "Сделайте 1 перерождение чтобы разблокировать";
        }
        if (Describer.fruits == Fruits.Orange)
        {
            TextOfRequpments.text = "Сделайте 3 перерождения чтобы разблокировать";
        }
    }
}
