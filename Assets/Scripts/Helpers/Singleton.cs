using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Object = System.Object;

public class Singleton<T> : MonoBehaviour where T : MonoBehaviour
{
    private static T _showPanel;

    public static T ShowPanel
    {
        get
        {
            return _showPanel;
        }
    }

    private void Awake()
    {
        _showPanel = (T) (object) this;
    }
}
