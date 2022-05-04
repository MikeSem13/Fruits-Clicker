using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FpsBoard : MonoBehaviour
{
    private void Awake()
    {
        Application.targetFrameRate = 60;
        QualitySettings.vSyncCount = 0;
    }
}
