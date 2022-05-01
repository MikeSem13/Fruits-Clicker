using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenAnyPanel : MonoBehaviour
{
   // Panels And BackGround
   public GameObject Panel;
   public GameObject BlackGround;

   // Method to Open or Close Which panel
   public void OpenAndClosePanel()
   {
      Panel.SetActive(!Panel.activeSelf);
      if(BlackGround != null) BlackGround.SetActive(!BlackGround.activeSelf);
   }
}
