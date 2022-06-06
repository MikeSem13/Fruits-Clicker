
using UnityEngine;
using System.IO;

public class SaveSystem : MonoBehaviour
{
   [Header("Классы для сохранения")]
   public ValuteManager ValuteManager;
   public UpgradeManager UpgradeManager;
   public BoostsOfUpgrades BoostsOfUpgrades;
   
   [Space]
   [Space]
   
   [Header("Классы для передачи сохранения")]
   public ValuteManagerData ValuteManagerData;
   public UpgradeManagerData UpgradeManagerData;
   public BoostsOfUpgradesData BoostsOfUpgradesData;

   [Space]
   [Header("Пути к файлам")]
   public string ValutePath;
   public string UpgradePath;
   public string BoostsPath;
   
   [Space]
   [Header("Файлы")]
   public string ValuteSaveFileName;
   public string UpgradesSaveFileName;
   public string BoostsSaveFileName;
   
   private void Awake()
   {
      SetAnyPath(ref ValutePath, ValuteSaveFileName);
      SetAnyPath(ref UpgradePath, UpgradesSaveFileName);
      SetAnyPath(ref BoostsPath, BoostsSaveFileName);
      
      Load();
   }

   public void SetAnyPath(ref string path, string fileName)
   {
      #if UNITY_ANDROID && !UNITY_EDITOR
      path = Path.Combine(Application.persistentDataPath,  fileName);
      #else
      path = Path.Combine(Application.dataPath, fileName);
      #endif
   }
   
   public void OnApplicationQuit()
   {
      Save();
   }

   public void OnApplicationPause(bool pauseStatus)
   {
      if (Application.platform == RuntimePlatform.Android) Save();
   }

   public void Load()
   {
      if (File.ReadAllText(ValutePath).Length > 50)
      {
         ValuteManagerData = JsonUtility.FromJson<ValuteManagerData>(File.ReadAllText(ValutePath));

         ValuteManagerData.ReturnSave(ValuteManager);  
      }
      
      if (File.ReadAllText(UpgradePath).Length > 50)
      {
         UpgradeManagerData = JsonUtility.FromJson<UpgradeManagerData>(File.ReadAllText(UpgradePath));

         UpgradeManagerData.ReturnSave(UpgradeManager);  
      }
      
      if (File.ReadAllText(BoostsPath).Length > 50)
      {
         BoostsOfUpgradesData = JsonUtility.FromJson<BoostsOfUpgradesData>(File.ReadAllText(BoostsPath));

         BoostsOfUpgradesData.ReturnSave(BoostsOfUpgrades);  
      }
   }

   public void Save()
   {
      ValuteManagerData.TakeToSave(ValuteManager);
      
      File.WriteAllText(ValutePath, JsonUtility.ToJson(ValuteManagerData, true));
      
      
      UpgradeManagerData.TakeToSave(UpgradeManager);
      
      File.WriteAllText(UpgradePath, JsonUtility.ToJson(UpgradeManagerData, true));
      
      BoostsOfUpgradesData.TakeToSave(BoostsOfUpgrades);
      
      File.WriteAllText(BoostsPath, JsonUtility.ToJson(BoostsOfUpgradesData, true));
   }
}
