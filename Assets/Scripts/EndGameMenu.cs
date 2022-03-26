
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using TMPro;

public class EndGameMenu : MonoBehaviour
{
    public static bool adWatchedToContinue = false;
    public static bool thisIsTheSameGame = false;
    public TextMeshProUGUI continueButton;
    public static int gameends;
    private void Start()
    {
        GameObject.FindGameObjectWithTag("ButtonClick").GetComponent<JSONSaving>().CreatePlayerData();
        GameObject.FindGameObjectWithTag("ButtonClick").GetComponent<JSONSaving>().SaveData();
        ChosePortal.adsStarOn = false;
        ChosePortal.starportalsDestroyed = true;
        Time.timeScale = 1;
        if (PlayerPrefs.GetInt("removeAds", 0) == 0) { GameObject.FindGameObjectWithTag("ButtonClick").GetComponent<GoogleADMOBmanager>().RequestAndLoadInterstitialAd(); }
           
        if (thisIsTheSameGame)
        {
            continueButton.faceColor = new Color32(255, 255, 255, 10);
        }
    }
    public void playgame()
    {
        
        thisIsTheSameGame = false;
        //testgl
        Time.timeScale = 1;
        PauseMenu.swiped = false;
        PauseMenu.gameIsPaused = false;
        GameObject.FindGameObjectWithTag("ButtonClick").GetComponent<SaveMe>().PlaySound();
        Invoke("ToWait", 0.2f);
        //SceneManager.LoadScene("GamePlay");




    }
    public void Continue()
    {
        
        if (!thisIsTheSameGame) {
            GameObject.FindGameObjectWithTag("ButtonClick").GetComponent<SaveMe>().PlaySound();
            if (PlayerPrefs.GetInt("removeAds", 0) == 0) { GameObject.FindGameObjectWithTag("ButtonClick").GetComponent<GoogleADMOBmanager>().ShowRewardedAdEnd(); }
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
        
        SceneManager.LoadScene("GamePlay");


    }
    IEnumerator toWait2()
    {
        yield return new WaitForSeconds(0.2f);
        SceneManager.LoadScene("StartScreen");

    }

    public void startMenu()
    {
        thisIsTheSameGame = false;
        Time.timeScale = 1;
        
        gameends++;
        
        if (gameends % 2 == 0)
        {
            if (PlayerPrefs.GetInt("removeAds", 0) == 0)
            {
                GameObject.FindGameObjectWithTag("ButtonClick").GetComponent<GoogleADMOBmanager>().ShowInterstitialAd();
            }
        }
        GameObject.FindGameObjectWithTag("ButtonClick").GetComponent<SaveMe>().PlaySound();
        
        StartCoroutine(toWait2());
        
        
    }
    
}
