using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowMultiFruitCoinsUpgrades : MonoBehaviour
{
    public GameObject FruitCoinsPanelButton;
    public GameObject DimondsPanelButton;
    public GameObject MultiFruitCoinsButton;
    private void Update()
    {
        /*if (Rebirth.CountOfRebirth > 0)
        {
            MultiFruitCoinsButton.SetActive(true);
            SetSizeAndPositionForThreeButtons();
        }
        else
        {
            MultiFruitCoinsButton.SetActive(false);
            SetSizeAndPositionForTwoButtons();
        }*/
    }

    public void SetSizeAndPositionForTwoButtons()
    {
        FruitCoinsPanelButton.transform.localPosition = new Vector2(-303.29f,-1.6f);
        DimondsPanelButton.transform.localPosition = new Vector2(297.3f,-1.6f);
        FruitCoinsPanelButton.GetComponent<RectTransform>().sizeDelta = new Vector2(901f,251.0903f);
        DimondsPanelButton.GetComponent<RectTransform>().sizeDelta = new Vector2(901f,251.0903f);
    }
    
    public void SetSizeAndPositionForThreeButtons()
    {
        FruitCoinsPanelButton.transform.localPosition = new Vector2(-403.15f,-0.13f);
        DimondsPanelButton.transform.localPosition = new Vector2(-2.8f, 0.00020006f);
        FruitCoinsPanelButton.GetComponent<RectTransform>().sizeDelta = new Vector2(600.6667f,251.0903f);
        DimondsPanelButton.GetComponent<RectTransform>().sizeDelta = new Vector2(600.6667f,251.0903f);
    }
}
