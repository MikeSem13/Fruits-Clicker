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

    public void StartMotion(float Multi)
    {
        transform.localScale = Vector3.one;
        TextConverter(Multi);
        transform.localPosition = Vector2.zero;
        Vector = new Vector2(Random.Range(-50, 50), Random.Range(-50, 50));
        Vector = Vector.normalized;
        Vector *= 20;
        Move = true;
        GetComponent<Animation>().Play();
    }

    public void TextConverter(float FruitCoins)
    {
        if (FruitCoins <= 999) GetComponent<Text>().text = "+" + FruitCoins.ToString("0");
        if (FruitCoins > 999 && FruitCoins <= 9999)  GetComponent<Text>().text = "+" + Math.Round((FruitCoins / 1000),1) + "k";
        if (FruitCoins > 9999 && FruitCoins <= 999999)  GetComponent<Text>().text = "+" + (FruitCoins / 1000).ToString("0") + "k";
        if (FruitCoins > 999999 && FruitCoins <= 9999999)  GetComponent<Text>().text = "+" + Math.Round((FruitCoins / (1000 * 1000)),1) + "M";
        if (FruitCoins > 9999999 && FruitCoins <= 999999999)  GetComponent<Text>().text = "+" + (FruitCoins / (1000 * 1000)).ToString("0") + "M";
    }
}
