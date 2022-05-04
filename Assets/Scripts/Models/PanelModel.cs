using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]public class PanelModel
{
  public string PanelId;
  
  public GameObject GameObjectPanel;
  public GameObject BackGround;

  public Animator Animator;

  private bool _isShowing;

  public bool IsShowing { get { return _isShowing; } set { _isShowing = value; }
  }
}
