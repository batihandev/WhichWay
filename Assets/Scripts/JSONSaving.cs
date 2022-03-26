
using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JSONSaving : MonoBehaviour
{
    public static int pleasedontmodfiy;
    private PlayerData playerData;
   // private string path = "";
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
        playerData = new PlayerData (name="Player",Spawner.highScore,/*PlayerPrefs.GetInt("removeAds"),*/ StartScreen.firstTime,
            OnClick.starClickCount, Score.steps, GPSmanager.achievements1 , GPSmanager.achievements2, GPSmanager.achievements3, GPSmanager.achievements4
            , GPSmanager.achievements5, GPSmanager.achievements6, GPSmanager.achievements7, GPSmanager.achievements8, PlayerPrefs.GetFloat("Volume"), PlayerPrefs.GetInt("indexQ"), Score.endgameStarScore,StartScreen.ad,pleasedontmodfiy);
    }
    public void SetPaths()
    {
       // path = Application.dataPath + Path.AltDirectorySeparatorChar + "SaveData.json";
        persistentPath = Application.persistentDataPath + Path.AltDirectorySeparatorChar + "SaveData.json";
    }
    // Update is called once per frame
    void Update()
    {
        
    }
    public void SaveFirstTime()
    {
        string savePath = persistentPath;

        Debug.Log("saving data at " + savePath);
        string json = JsonUtility.ToJson(playerData);
        
        //Rot39(json);
        Debug.Log(json);
        using StreamWriter writer = new StreamWriter(savePath);
        writer.Write(json);
        
    }
    public void SaveData()
    {
       
            //using StreamReader reader = new StreamReader(persistentPath);
            LoadData();
        
        
        
        
        string savePath = persistentPath;
        Debug.Log("saving data at " + savePath);
        string json = JsonUtility.ToJson(playerData);
        //Rot39(json);
        Debug.Log(json);
        using StreamWriter writer = new StreamWriter(savePath);
        writer.Write(json);
    }
    //public string Rot39(string input)
    //{
    //    // This string contains 78 different characters in random order.
    //    var mix = "QDXkW<_(V?cqK.lJ>-*y&zv9prf8biYCFeMxBm6ZnG3H4OuS1UaI5TwtoA#Rs!,7d2@L^gNhj)EP$0";
    //    var result = (input ?? "").ToCharArray();
    //    for (int i = 0; i < result.Length; ++i)
    //    {
    //        int j = mix.IndexOf(result[i]);
    //        result[i] = (j < 0) ? result[i] : mix[(j + 39) % 78];
    //    }
    //    return new string(result);
    //}
    public void LoadData()
    {   
        using StreamReader reader = new StreamReader(persistentPath);
        string json = reader.ReadToEnd();
    
        PlayerData data = JsonUtility.FromJson<PlayerData>(json) ;
        Debug.Log(data.ToString()+"loadeddata checking now ...");
        if (data.pleasedontmodify != (((data.highScore+1) * (data.StarClickCount+1) * 217197 - 987)/ 15743))
        {

            Debug.Log("cheating?");
        }
        else if(data.highScore>Spawner.highScore || data.StarClickCount > OnClick.starClickCount )
        {
            Spawner.highScore= data.highScore;
            
            //PlayerPrefs.SetInt("removeAds", data.removeAds);
            
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
