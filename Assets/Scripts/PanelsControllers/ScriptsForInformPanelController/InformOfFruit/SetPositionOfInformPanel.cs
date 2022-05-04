using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetPositionOfInformPanel : MonoBehaviour
{
    public ControllButtonsController ButtonsController;
    
    public Text TextOfMultiFruit;
    public Text TextOfMainMultiMultiFruit;
    public Text TextOfMultiAwaking;
    public Image ImageOfValueOfMultiFruit;

    public void SetPositionOfTextsAndButtons(DescriberForFruitsInList Describer)
    {
        ButtonsController.SetTransformButtons(Describer);

        if (Describer.IsAwaking == false)
        {
            TextOfMultiAwaking.gameObject.SetActive(false);
            
            TextOfMainMultiMultiFruit.transform.localPosition = new Vector2(-71f,-317.6f);
            TextOfMainMultiMultiFruit.GetComponent<RectTransform>().sizeDelta = new Vector2(929.75f,128.7857f);
            TextOfMainMultiMultiFruit.fontSize = 97;

            ImageOfValueOfMultiFruit.gameObject.transform.localPosition = new Vector2(515.4108f,-2.6328f);
            ImageOfValueOfMultiFruit.gameObject.GetComponent<RectTransform>().sizeDelta = new Vector2(123.5205f,123.52f);
            
            TextOfMultiFruit.gameObject.transform.localPosition = new Vector2(708f,-9.3193f);
            TextOfMultiFruit.fontSize = 90;
        }
        else
        {
            TextOfMultiAwaking.gameObject.SetActive(true);
            
            TextOfMainMultiMultiFruit.transform.localPosition = new Vector2(-64.1f,-259.06f);
            TextOfMainMultiMultiFruit.GetComponent<RectTransform>().sizeDelta = new Vector2(798.1769f,128.7857f);
            TextOfMainMultiMultiFruit.fontSize = 87;
            
            ImageOfValueOfMultiFruit.gameObject.transform.localPosition = new Vector2(460.2614f,-4.386902e-05f);
            ImageOfValueOfMultiFruit.gameObject.GetComponent<RectTransform>().sizeDelta = new Vector2(118.3388f,118.3419f);
            
            TextOfMultiFruit.gameObject.transform.localPosition = new Vector2(650f,-4.0975f);
            TextOfMultiFruit.fontSize = 85;
        }
    }
}
