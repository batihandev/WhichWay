
using UnityEngine;

using UnityEngine.SceneManagement;

public class StartScreen : MonoBehaviour
{
    public static int firstTime;
    public GameObject howtoplay;
    public GameObject menu;
    public static string ad="TestKey";
    public static bool dothisonce = false;
   
    void Awake()
    {
        dothisonce = false;
        if (ad != "7TjqzjL(#>F^zqDrr-D>UFjq>")
        {
            PlayerPrefs.SetInt("removeAds", 0);
        }

        if (PlayerPrefs.GetInt("removeAds", 0) == 0) { GameObject.FindGameObjectWithTag("ButtonClick").GetComponent<GoogleADMOBmanager>().RequestBannerAd(); }
        
    }
    private void Start()
    {
        
    }

    public void playgame()
    {
        EndGameMenu.adWatchedToContinue = false;
        ChosePortal.starportalsDestroyed = true;
        EndGameMenu.thisIsTheSameGame = false;
        if (PlayerPrefs.GetInt("removeAds", 0) == 0) { GameObject.FindGameObjectWithTag("ButtonClick").GetComponent<GoogleADMOBmanager>().DestroyBannerAd(); }
           
        
        
        if (firstTime == 0)
        {
            menu.SetActive(false);
            howtoplay.SetActive(true);
            
            firstTime = 1;
                

        }
        else {


            GameObject.FindGameObjectWithTag("ButtonClick").GetComponent<SaveMe>().PlaySound();

            Time.timeScale = 1;
            PauseMenu.swiped = false;
            PauseMenu.gameIsPaused = false;
            SceneManager.LoadScene("GamePlay");
        }
        
       
    }
    public void Exit()
    {
        GameObject.FindGameObjectWithTag("ButtonClick").GetComponent<JSONSaving>().CreatePlayerData();
        GameObject.FindGameObjectWithTag("ButtonClick").GetComponent<JSONSaving>().SaveData();
        GameObject.FindGameObjectWithTag("ButtonClick").GetComponent<SaveMe>().PlaySound();
        Application.Quit();
    }
    
    void Update()
    {
        if (!dothisonce) { 
        try
        {
            GameObject.FindGameObjectWithTag("ButtonClick").GetComponent<JSONSaving>().SetPaths();
            GameObject.FindGameObjectWithTag("ButtonClick").GetComponent<JSONSaving>().CreatePlayerData();
            GameObject.FindGameObjectWithTag("ButtonClick").GetComponent<JSONSaving>().SaveData();
        }
        catch
        {
            GameObject.FindGameObjectWithTag("ButtonClick").GetComponent<JSONSaving>().SetPaths();
            GameObject.FindGameObjectWithTag("ButtonClick").GetComponent<JSONSaving>().CreatePlayerData();
            GameObject.FindGameObjectWithTag("ButtonClick").GetComponent<JSONSaving>().SaveFirstTime();
        }
            dothisonce = true;
        }
    }
}
