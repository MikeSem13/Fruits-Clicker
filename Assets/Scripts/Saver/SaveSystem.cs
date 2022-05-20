
using System;
using UnityEngine;
using System.IO;

public class SaveSystem : MonoBehaviour
{
   [SerializeField] public ValuteManager ValuteManager;
   
   [Space]
   [Multiline] [SerializeField] private string json;
   [Space]

   [SerializeField] private string SavePath;
   [SerializeField] private string SaveFileName = "JSON.json";

   private void Awake()
   {
      #if UNITY_ANDROID && !UNITY_EDITOR
      SavePath = Path.Combine(Application.persistentDataPath, SaveFileName);
      #else
      SavePath = Path.Combine(Application.dataPath, SaveFileName);
      #endif
      Load();
   }

   private void OnApplicationQuit()
   {
      Save();
   }

   private void OnApplicationPause(bool pauseStatus)
   {
      if (Application.platform == RuntimePlatform.Android)
      {
         Save();
      }
   }

   public void Load()
   {
      json = File.ReadAllText(SavePath);
      ValuteManager valuteManagerFromJson = JsonUtility.FromJson<ValuteManager>(json);
      this.ValuteManager = valuteManagerFromJson;
   }

   public void Save()
   {
      ValuteManager valuteManager = new ValuteManager();
      ValuteManager = valuteManager;
      
      json =  JsonUtility.ToJson(valuteManager, true);
      File.WriteAllText(SavePath, json);
   }
}
