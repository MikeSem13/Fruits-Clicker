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

    public void StartMotion(ValutesModel valuteModel, SybwolModel sybwol)
    {
        int interval = 0;
        if (valuteModel.NumberOfMulti != 0) interval = 1;
        
        TextConverter(valuteModel.Values[valuteModel.NumberOfMulti].MultiOfValute, valuteModel.Values[valuteModel.NumberOfMulti - interval].MultiOfValute, sybwol);
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
    
    public void TextConverter(float multi, float lastMulti, SybwolModel sybwol)
    {
        if (multi < 10 && lastMulti > 100) GetComponent<Text>().text = "+" + multi.ToString("0") + "." + Math.Floor(lastMulti / 100) + sybwol.Sybwol;
        else if (multi < 1000) GetComponent<Text>().text = "+" + multi.ToString("0") + sybwol.Sybwol;
    }
}
