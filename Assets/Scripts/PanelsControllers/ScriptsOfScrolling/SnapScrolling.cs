using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SnapScrolling : MonoBehaviour, IPointerEnterHandler
{
    private ScrollRect Scroll;

    private void Start()
    {
        Scroll = GetComponent<ScrollRect>();
    }

    public void EnableElasity()
    {
        Scroll.elasticity = 0.1f;
        Scroll.vertical = true;
    }

    public void OffElasity()
    {
        Scroll.elasticity = 0;
        Scroll.vertical = false;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
       EnableElasity();
    }
}
