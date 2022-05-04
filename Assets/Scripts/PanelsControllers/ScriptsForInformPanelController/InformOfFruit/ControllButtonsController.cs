using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControllButtonsController : MonoBehaviour
{
    public Button ButtonOfBuy;
    public Button ButtonOfAwaking;

    public void SetTransformButtons(DescriberForFruitsInList Describer)
    {
        if (Describer.LevelOfFruit == Describer.MaxLevelOfFruit & Describer.IsAwaking == false)
        {
            ButtonOfBuy.GetComponent<RectTransform>().transform.localPosition = new Vector2(-300.002f,-608.9076f);
            ButtonOfAwaking.gameObject.SetActive(true);
            
        }
        else
        {
            ButtonOfBuy.GetComponent<RectTransform>().transform.localPosition = new Vector2(0f,-608.9076f);
            ButtonOfAwaking.gameObject.SetActive(false);
        }
    }
}
