
using System.IO;

using UnityEngine;

public class JSONSaving : MonoBehaviour
{
    public static int pleasedontmodfiy;
    private PlayerData playerData;
   
    private string persistentPath = "";

    void Start()
    {
        SetPaths();
        GameObject.FindGameObjectWithTag("ButtonClick").GetComponent<JSONSaving>().CreatePlayerData();
        GameObject.FindGameObjectWithTag("ButtonClick").GetComponent<JSONSaving>().SaveData();
    }
    public void CreatePlayerData()
    {
        pleasedontmodfiy = (((Spawner.highScore+1) * (OnClick.starClickCount+1) * 217197 - 987)/15743);
        playerData = new PlayerData (name="Player",Spawner.highScore, StartScreen.firstTime,
            OnClick.starClickCount, Score.steps, GPSmanager.achievements1 , GPSmanager.achievements2, GPSmanager.achievements3, GPSmanager.achievements4
            , GPSmanager.achievements5, GPSmanager.achievements6, GPSmanager.achievements7, GPSmanager.achievements8, PlayerPrefs.GetFloat("Volume"), PlayerPrefs.GetInt("indexQ"), Score.endgameStarScore,StartScreen.ad,pleasedontmodfiy);
    }
    public void SetPaths()
    {
       
        persistentPath = Application.persistentDataPath + Path.AltDirectorySeparatorChar + "SaveData.json";
    }
    
    
    public void SaveFirstTime()
    {
        string savePath = persistentPath;

        
        string json = JsonUtility.ToJson(playerData);
        
        
       
        using StreamWriter writer = new StreamWriter(savePath);
        writer.Write(json);
        
    }
    public void SaveData()
    {
       
            
            LoadData();
        
        
        
        
        string savePath = persistentPath;
       
        string json = JsonUtility.ToJson(playerData);
       
        
        using StreamWriter writer = new StreamWriter(savePath);
        writer.Write(json);
    }
    
    public void LoadData()
    {   
        using StreamReader reader = new StreamReader(persistentPath);
        string json = reader.ReadToEnd();
    
        PlayerData data = JsonUtility.FromJson<PlayerData>(json) ;
       
        if (data.pleasedontmodify != (((data.highScore+1) * (data.StarClickCount+1) * 217197 - 987)/ 15743))
        {

            
        }
        else if(data.highScore>Spawner.highScore || data.StarClickCount > OnClick.starClickCount )
        {
            Spawner.highScore= data.highScore;
            
            
            
            StartScreen.firstTime= data.FirstTime;
            OnClick.starClickCount= data.StarClickCount;
            Score.steps= data.steps;
            GPSmanager.achievements1= data.achievements1;
            GPSmanager.achievements2 = data.achievements2;
            GPSmanager.achievements3 = data.achievements3;
            GPSmanager.achievements4 = data.achievements4;
            GPSmanager.achievements5 = data.achievements5;
            GPSmanager.achievements6 = data.achievements6;
            GPSmanager.achievements7 = data.achievements7;
            GPSmanager.achievements8 = data.achievements8;
            PlayerPrefs.SetFloat("Volume", data.volume);
            PlayerPrefs.SetInt("indexQ", data.indexQ);
            Score.endgameStarScore= data.endGameStarCount;
            StartScreen.ad = data.Test;
        }
   
    }
}
