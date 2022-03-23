
using System.IO;

using UnityEngine;

public class JSONSaving : MonoBehaviour
{
    private PlayerData playerData;
   // private string path = "";
    private string persistentPath = "";

    void Start()
    {
        SetPaths();
    }
    public void CreatePlayerData()
    {
        playerData = new PlayerData (name,PlayerPrefs.GetInt("highScore"), PlayerPrefs.GetInt("gameOverScore"),/*PlayerPrefs.GetInt("removeAds"),*/PlayerPrefs.GetInt("GameEnds"), PlayerPrefs.GetInt("firstTime"),
            PlayerPrefs.GetInt("starClickCount"), PlayerPrefs.GetInt("steps"), PlayerPrefs.GetInt("achievements1"), PlayerPrefs.GetInt("achievements2"), PlayerPrefs.GetInt("achievements3"), PlayerPrefs.GetInt("achievements4")
            , PlayerPrefs.GetInt("achievements5"), PlayerPrefs.GetInt("achievements6"), PlayerPrefs.GetInt("achievements7"), PlayerPrefs.GetInt("achievements8"), PlayerPrefs.GetFloat("Volume"), PlayerPrefs.GetInt("indexQ"), PlayerPrefs.GetInt("endGameStarCount"));
    }
    private void SetPaths()
    {
       // path = Application.dataPath + Path.AltDirectorySeparatorChar + "SaveData.json";
        persistentPath = Application.persistentDataPath + Path.AltDirectorySeparatorChar + "SaveData.json";
    }
    // Update is called once per frame
    void Update()
    {
        
    }
    public void SaveData()
    {
        string savePath = persistentPath;
        Debug.Log("saving data at " + savePath);
        string json = JsonUtility.ToJson(playerData);
        Debug.Log(json);
        using StreamWriter writer = new StreamWriter(savePath);
        writer.Write(json);
    }
    public void LoadData()
    {
        using StreamReader reader = new StreamReader(persistentPath);
        string json = reader.ReadToEnd();
        PlayerData data = JsonUtility.FromJson<PlayerData>(json);
        Debug.Log(data.ToString());
        if(data.highScore>=PlayerPrefs.GetInt("highScore",0) && data.StarClickCount >= PlayerPrefs.GetInt("starClickCount", 0))
        {
            PlayerPrefs.SetInt("highScore", data.highScore);
            PlayerPrefs.SetInt("gameOverScore", data.gameOverScore);
            //PlayerPrefs.SetInt("removeAds", data.removeAds);
            PlayerPrefs.SetInt("GameEnds", data.GameEnds);
            PlayerPrefs.SetInt("firstTime", data.FirstTime);
            PlayerPrefs.SetInt("starClickCount", data.StarClickCount);
            PlayerPrefs.SetInt("steps", data.steps);
            PlayerPrefs.SetInt("achievements1", data.achievements1);
            PlayerPrefs.SetInt("achievements2", data.achievements2);
            PlayerPrefs.SetInt("achievements3", data.achievements3);
            PlayerPrefs.SetInt("achievements4", data.achievements4);
            PlayerPrefs.SetInt("achievements5", data.achievements5);
            PlayerPrefs.SetInt("achievements6", data.achievements6);
            PlayerPrefs.SetInt("achievements7", data.achievements7);
            PlayerPrefs.SetInt("achievements8", data.achievements8);
            PlayerPrefs.SetFloat("Volume", data.volume);
            PlayerPrefs.SetInt("indexQ", data.indexQ);
            PlayerPrefs.SetInt("endGameStarCount", data.endGameStarCount);
        }
   
    }
}
