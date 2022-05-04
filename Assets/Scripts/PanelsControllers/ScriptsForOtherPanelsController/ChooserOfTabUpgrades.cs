using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Serialization;

public class ChooserOfTabUpgrades : MonoBehaviour
{
    public List<MainButtons> ButtonsOfUpgrade;

    public Sprite SpriteOfActive;
    public Sprite SpriteOfIdle;
    
    public MainButtons SelectedButton;
    
    public List<GameObject> PanelsToSwipe;

    public int Index;

    public void Subscribe(MainButtons Button)
    {
        if (ButtonsOfUpgrade == null)
        {
            ButtonsOfUpgrade = new List<MainButtons>();
        }
        ButtonsOfUpgrade.Add(Button);
    }

    public void OnButtonSelected(MainButtons Button)
    {
        SelectedButton = Button;
        ResetButtons();
        Button.BackgroundOfButoon.sprite = SpriteOfActive;
        Index = Button.transform.GetSiblingIndex();
        for (int i = 0; i < PanelsToSwipe.Count; i++)
        {
            if (i == Index)
            {
                PanelsToSwipe[i].SetActive(true);
            }
            else
            {
                PanelsToSwipe[i].SetActive(false);
            }
        }
    }

    public void ResetButtons()
    {
        foreach (MainButtons Button in ButtonsOfUpgrade)
        {
            if(SelectedButton != null && Button == SelectedButton) {continue;} 
            Button.BackgroundOfButoon.sprite = SpriteOfIdle;
        }
    }
}
