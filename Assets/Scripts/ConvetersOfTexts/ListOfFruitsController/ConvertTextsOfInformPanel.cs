using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ConvertTextsOfInformPanel : MonoBehaviour
{
    public BuyFruit BuyFruit;
    
    public Sprite FruitCoinSprite;
    public Sprite FruitDimondsSprite;
    public Sprite MultiFruitCoinSprite;
    
    // All Texts of Inform panel
    public Text TextOfNameFruit;
    public Text TextOfMultiFruit;
    public Text TextOfMultiAwaking;
    public Image ImageOfValueOfAwaking;


    private void Start()
    {
        for (int i = 0; i < BuyFruit.AllFruitsDesctiber.Count; i++)
        {
            BuyFruit.AllFruitsDesctiber[i].CurrentAwakingInString = PlayerPrefs.GetString("CAwakingString" + i);
        }
    }

    private void Update()
    {
        for (int i = 0; i < BuyFruit.AllFruitsDesctiber.Count; i++)
        {
            PlayerPrefs.SetString("CAwakingString" + i, BuyFruit.AllFruitsDesctiber[i].CurrentAwakingInString);
        }
    }

    // Convert All values to Texts
    public void ConvertTextOfInfromPanel(DescriberForFruitsInList Describer)
    {
        TextOfMultiFruit.text = Describer.multi.ToString();
        TextOfMultiAwaking.text = Describer.CountOfMultiAwaking.ToString();

        if (Describer.fruits == Fruits.Apple) TextOfNameFruit.text = "Яблоко";
        if (Describer.fruits == Fruits.Banana) TextOfNameFruit.text = "Банан";
        if (Describer.fruits == Fruits.Orange) TextOfNameFruit.text = "Апельсин";
        
        SetSpritesAndTexts(Describer);
    }

    public void SetSpritesAndTexts(DescriberForFruitsInList Describer)
    {
        if (Describer.CurrentAwakingInString == TypesOfAwaking.FruitCoinsAwaking.ToString())
        {
            ImageOfValueOfAwaking.sprite = FruitCoinSprite;
            ImageOfValueOfAwaking.gameObject.GetComponent<RectTransform>().sizeDelta = new Vector2(122.7392f,122.7424f);
        }
        if (Describer.CurrentAwakingInString == TypesOfAwaking.FruitDimondsAwaking.ToString())
        {
            ImageOfValueOfAwaking.sprite = FruitDimondsSprite;
            ImageOfValueOfAwaking.gameObject.GetComponent<RectTransform>().sizeDelta = new Vector2(126.4187f,101.3509f);
        }
        if (Describer.CurrentAwakingInString == TypesOfAwaking.MultiFruitCoinsAwaking.ToString())
        {
            ImageOfValueOfAwaking.sprite = MultiFruitCoinSprite;
            ImageOfValueOfAwaking.gameObject.GetComponent<RectTransform>().sizeDelta = new Vector2(122.7392f,122.7424f);
        }
    }
}
