using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenPanelOfListFruits : MonoBehaviour
{
    // Needed Classes
    public ConvertTextsOfInformPanel ConverterInformTexts;
    public ControllCurrentFruitInList ControllCurrentFruitInList;
    public SetPositionOfInformPanel SetPositionOfInformPanel;

    // Images of Fruits
    public List<GameObject> ImagesForList;
    
    // Method To Change Texts and Images of Inform Panel
    public void SelectAllImagesAndText(DescriberForFruitsInList Describer)
   {
       SetPositionOfInformPanel.SetPositionOfTextsAndButtons(Describer);
       ControllCurrentFruitInList.ChooseFruitToList(Describer);
       ConverterInformTexts.ConvertTextOfInfromPanel(Describer);

       ImagesForList[ControllCurrentFruitInList.CurrentFruitsInNumberInList].SetActive(true);
       for (int i = 0; i < ControllCurrentFruitInList.CurrentFruitsInNumberInList; i++)
       { 
           ImagesForList[i].SetActive(false);
       }

       for (int i = ControllCurrentFruitInList.CurrentFruitsInNumberInList + 1; i < ImagesForList.Count; i++)
       {
           ImagesForList[i].SetActive(false);
       }
   }
}
