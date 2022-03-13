using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartScreen : MonoBehaviour
{
    
    // Start is called before the first frame update
    void Awake()
    {
        
    }
    public void playgame()
    {

        //testgl
        GameObject.FindGameObjectWithTag("ButtonClick").GetComponent<SaveMe>().PlaySound();
        
        Time.timeScale = 1;
        PauseMenu.swiped = false;
        PauseMenu.gameIsPaused = false;
        SceneManager.LoadScene("GamePlay");
       
    }
    public void Exit()
    {
        GameObject.FindGameObjectWithTag("ButtonClick").GetComponent<SaveMe>().PlaySound();
        Application.Quit();
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
