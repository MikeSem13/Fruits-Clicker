using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CreateATextsOfFruitCoins : MonoBehaviour
{
   public ValuteManager ValuteManager;

   public GameObject Spawner;
   public GameObject PrefabOfText;

   public ControllOfMotionOfTexts Text;

   public void SpawnOnClick()
   {
      ControllOfMotionOfTexts TextClone = Instantiate(Text.gameObject).GetComponent<ControllOfMotionOfTexts>();
      TextClone.transform.SetParent(Spawner.transform);
      TextClone.StartMotion(ValuteManager.GetValute("Fruit Coins") , ValuteManager.DemisionsOfValutes.SybwolsOfValutes[ValuteManager.GetValute("Fruit Coins").NumberOfMulti]);
      Destroy(TextClone.gameObject, 3.5f);
   }

   private void Start()
   {
      Text = Instantiate(PrefabOfText,Spawner.transform).GetComponent<ControllOfMotionOfTexts>();
   }
}
