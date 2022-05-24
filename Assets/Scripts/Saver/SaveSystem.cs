
using System;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.Serialization;

public class SaveSystem : MonoBehaviour
{
   public List<SaveValuteData> Saves = new List<SaveValuteData>();

   [SerializeField] public ValuteManager valuteManager;

   [SerializeField] public string Path;
   [SerializeField] public string SaveFileName;
   
   private void Awake()
   {
      for (int i = 0; i < Saves.Count; i++)
      {
         #if UNITY_ANDROID && !UNITY_EDITOR
         Path = Path.Combine(Application.persistentDataPath, SaveFileName);
         #else
         Path = System.IO.Path.Combine(Application.persistentDataPath, SaveFileName);
         #endif  
      }

      if (File.ReadAllText(Path) != null) Load();
   }

   public void OnApplicationQuit()
   {
      SaveFileJson();
   }

   public void OnApplicationPause(bool pauseStatus)
   {
      if (Application.platform == RuntimePlatform.Android)
      {
         SaveFileJson();
      }
   }

   public void Load()
   {
      string json = File.ReadAllText(Path);
      Saves[0] = JsonUtility.FromJson<SaveValuteData>(json);
      Debug.Log(Saves[0].Valutes);
   }

   public void SaveFileJson()
   {
      if (File.Exists(Path))
      {
         Saves[0].Valutes = valuteManager.Valutes;
         string json = JsonUtility.ToJson(Saves[0].Valutes, true);
         File.WriteAllText(Path, json);
         Debug.Log(json);
      }
   }
}
