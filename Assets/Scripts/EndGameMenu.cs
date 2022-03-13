
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class EndGameMenu : MonoBehaviour
{
    
    private void Start()
    {
        Time.timeScale = 1;
    }
    public void playgame()
    {

        //testgl
        Time.timeScale = 1;
        PauseMenu.swiped = false;
        PauseMenu.gameIsPaused = false;
        GameObject.FindGameObjectWithTag("ButtonClick").GetComponent<SaveMe>().PlaySound();
        StartCoroutine(toWait());
        //SceneManager.LoadScene("GamePlay");
       
       


    }
    IEnumerator toWait()
    {
        yield return new WaitForSeconds(0.5f);
        SceneManager.LoadScene("GamePlay");


    }
    IEnumerator toWait2()
    {
        yield return new WaitForSeconds(0.5f);
        SceneManager.LoadScene("StartScreen");

    }

    public void startMenu()
    {
        Time.timeScale = 1;
        GameObject.FindGameObjectWithTag("ButtonClick").GetComponent<SaveMe>().PlaySound();
        StartCoroutine(toWait2());
        
        
    }
    
}
