using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

[RequireComponent(typeof(Image))]
public class MainButtons : MonoBehaviour, IPointerClickHandler
{
   public ChooserOfTabUpgrades TabUpgrades;

   public Image BackgroundOfButoon;

   private void Start()
   {
      BackgroundOfButoon = GetComponent<Image>();
      TabUpgrades.Subscribe(this);
   }

   public void OnPointerClick(PointerEventData eventData)
   {
       TabUpgrades.OnButtonSelected(this);
   }
}
