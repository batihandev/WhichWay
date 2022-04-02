
using UnityEngine;
using System.Collections;

using UnityEngine.SceneManagement;
using TMPro;

public class EndGameMenu : MonoBehaviour
{
    public static bool adWatchedToContinue = false;
    public static bool thisIsTheSameGame = false;
    public TextMeshProUGUI continueButton;
    public static int gameends;
    public static bool endgameMenuisOn = true;
    private void Awake()
    {
        endgameMenuisOn = true;
    }
     private void Start()
    {
        GameObject.FindGameObjectWithTag("ButtonClick").GetComponent<JSONSaving>().CreatePlayerData();
        GameObject.FindGameObjectWithTag("ButtonClick").GetComponent<JSONSaving>().SaveData();
        ChosePortal.adsStarOn = false;
        ChosePortal.starportalsDestroyed = true;
        Time.timeScale = 1;
       
           
        if (thisIsTheSameGame)
        {
            ConButtonRemover();
        }
    }
    public void ConButtonRemover()
    {
        continueButton.faceColor = new Color32(255, 255, 255, 10);
        thisIsTheSameGame = true;
    }
    public void playgame()
    {
        
        thisIsTheSameGame = false;
        endgameMenuisOn = false;
        //testgl
        Time.timeScale = 1;
        PauseMenu.swiped = false;
        PauseMenu.gameIsPaused = false;
        ChosePortal.starportalsDestroyed = true;
        GameObject.FindGameObjectWithTag("ButtonClick").GetComponent<SaveMe>().PlaySound();
        Invoke("ToWait", 0.2f);
        //SceneManager.LoadScene("GamePlay");




    }
    public void Continue()
    {
        
        if (!thisIsTheSameGame) {
            GameObject.FindGameObjectWithTag("ButtonClick").GetComponent<SaveMe>().PlaySound();
            if (PlayerPrefs.GetInt("removeAds", 0) == 0) { GameObject.FindGameObjectWithTag("ButtonClick").GetComponent<GoogleADMOBmanager>().ShowRewardedAd(); }
            if (PlayerPrefs.GetInt("removeAds", 0) == 1)
            {
                EndGameMenu.thisIsTheSameGame = true;
                EndGameMenu.adWatchedToContinue = true;
                Time.timeScale = 1;
                PauseMenu.swiped = false;
                PauseMenu.gameIsPaused = false;
                GameObject.FindGameObjectWithTag("ButtonClick").GetComponent<SaveMe>().PlaySound();
                Invoke("ToWait", 0.2f);
            }
        }
        
        





    }
    void ToWait()
    {
        endgameMenuisOn = false;
        SceneManager.LoadScene("GamePlay");


    }
    void toWait2()
    {

        Time.timeScale = 1;
        endgameMenuisOn = false;
        SceneManager.LoadScene("StartScreen");

    }

    public void startMenu()
    {
        thisIsTheSameGame = false;
        
        
        gameends++;
        
        
        GameObject.FindGameObjectWithTag("ButtonClick").GetComponent<SaveMe>().PlaySound();

        Invoke("toWait2", 0.3f);
        
        
    }
    
}
