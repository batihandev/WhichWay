
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
    private void Start()
    {
        ChosePortal.adsStarOn = false;
        ChosePortal.starportalsDestroyed = true;
        Time.timeScale = 1;
        GameObject.FindGameObjectWithTag("ButtonClick").GetComponent<GoogleADMOBmanager>().RequestAndLoadInterstitialAd();
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
        StartCoroutine(toWait());
        //SceneManager.LoadScene("GamePlay");
       
       


    }
    public void Continue()
    {
        
        if (!thisIsTheSameGame) {
            GameObject.FindGameObjectWithTag("ButtonClick").GetComponent<SaveMe>().PlaySound();
            GameObject.FindGameObjectWithTag("ButtonClick").GetComponent<GoogleADMOBmanager>().ShowRewardedAdEnd();
        }
        
        





    }
    IEnumerator toWait()
    {
        yield return new WaitForSeconds(0.2f);
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
        int gameends = PlayerPrefs.GetInt("GameEnds", 0);
        gameends++;
        PlayerPrefs.SetInt("GameEnds", gameends);
        if (PlayerPrefs.GetInt("GameEnds", 0) % 2 == 0)
        {
            GameObject.FindGameObjectWithTag("ButtonClick").GetComponent<GoogleADMOBmanager>().ShowInterstitialAd();
        }
        GameObject.FindGameObjectWithTag("ButtonClick").GetComponent<SaveMe>().PlaySound();
        
        StartCoroutine(toWait2());
        
        
    }
    
}
