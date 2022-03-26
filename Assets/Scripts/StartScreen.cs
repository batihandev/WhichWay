
using UnityEngine;

using UnityEngine.SceneManagement;

public class StartScreen : MonoBehaviour
{
    public static int firstTime;
    public GameObject howtoplay;
    public GameObject menu;
    public static string ad="TestKey";
    // Start is called before the first frame update
    void Awake()
    {
        try {
            GameObject.FindGameObjectWithTag("ButtonClick").GetComponent<JSONSaving>().SetPaths();
            GameObject.FindGameObjectWithTag("ButtonClick").GetComponent<JSONSaving>().CreatePlayerData();
            GameObject.FindGameObjectWithTag("ButtonClick").GetComponent<JSONSaving>().SaveData();
        }        
        catch {
            GameObject.FindGameObjectWithTag("ButtonClick").GetComponent<JSONSaving>().SetPaths();
            GameObject.FindGameObjectWithTag("ButtonClick").GetComponent<JSONSaving>().CreatePlayerData();
            GameObject.FindGameObjectWithTag("ButtonClick").GetComponent<JSONSaving>().SaveFirstTime();
        }
        if (ad != "7TjqzjL(#>F^zqDrr-D>UFjq>")
        {
            PlayerPrefs.SetInt("removeAds", 0);
        }

        if (PlayerPrefs.GetInt("removeAds", 0) == 0) { GameObject.FindGameObjectWithTag("ButtonClick").GetComponent<GoogleADMOBmanager>().RequestBannerAd(); }
        
    }

    public void playgame()
    {
        EndGameMenu.adWatchedToContinue = false;
        EndGameMenu.thisIsTheSameGame = false;
        if (PlayerPrefs.GetInt("removeAds", 0) == 0) { GameObject.FindGameObjectWithTag("ButtonClick").GetComponent<GoogleADMOBmanager>().DestroyBannerAd(); }
           
        //testgl 
        
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
    // Update is called once per frame
    void Update()
    {
        
    }
}
