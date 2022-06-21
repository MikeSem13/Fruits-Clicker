using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]public class PanelModel
{
  [Header("Id панели")]
  public string PanelId;
  
  [Header("Панель и бекграунд")]
  public GameObject GameObjectPanel;
  public GameObject BackGround;

  [Header("Аниматор")]
  public Animator Animator;

  [Header("Состояние панели")]
  private bool _isShowing;

  public bool IsShowing { get { return _isShowing; } set { _isShowing = value; }
  }
}
