using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;
using Vector2 = UnityEngine.Vector2;
using Vector3 = UnityEngine.Vector3;

public class ControllOfMotionOfTexts : MonoBehaviour
{
    public bool Move;

    private Vector2 Vector;

    private void FixedUpdate()
    {
        if(!Move) return;
        transform.Translate(Vector * Time.deltaTime);
    }

    public void StartMotion(ValutesModel valuteModel, TextConverter valueToTextConverter)
    {
        TextConverter(valuteModel,valueToTextConverter);
        ControllPositionOfText();
        Move = true;
        GetComponent<Animation>().Play();
    }

    public void ControllPositionOfText()
    {
        transform.localScale = Vector3.one;
        transform.localPosition = Vector2.zero;
        Vector = new Vector2(Random.Range(-50, 50), Random.Range(-50, 50));
        Vector = Vector.normalized;
        Vector *= 20;
    }
    
    public void TextConverter(ValutesModel valuteModel, TextConverter valueToTextConverter)
    {
       valueToTextConverter.ConvertValuesToText(GetComponent<Text>(), valuteModel.ValuteMultiplier, "+");
    }
}
