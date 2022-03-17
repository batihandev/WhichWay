using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class PauseMenu : MonoBehaviour
{
    public static bool gameIsPaused = false;
    public GameObject pauseMenuUI;
   
    public static bool swiped = false;
    float dista;
    private Touch touch;
    private Vector2 firstTouch, endTouch;
   
    private void Update()
    {
        if (Input.touchCount > 0 && !gameIsPaused)
        {
            
            touch = Input.GetTouch(0);
           
            switch (touch.phase)
            {
                case TouchPhase.Began:
                    firstTouch = touch.position;
                    break;
                case TouchPhase.Moved:
                    
                    if (Input.touchCount < 2 && Input.touchCount>0)
                    {
                        endTouch = touch.position;
                        if (firstTouch == endTouch)
                            swiped = false;
                        if (firstTouch != endTouch)
                        { dista = (firstTouch - endTouch).sqrMagnitude;
                            
                            if (dista > 20000 )
                            {
                                //Debug.Log(dista);
                                if (Input.touchCount > 1)
                                {
                                    swiped = false;
                                }
                                else { swiped = true; }
                                
                            }
                            else
                            {
                                dista = 0;
                                swiped = false;
                            }
                        }

                        
                    }
                    else
                    {
                        firstTouch=touch.position;
                    }
                   
                    
                    break;

              
                    
            }
            
        }
               

        
        if ( swiped)
        {
           
                Pause();
            



        }
    }
    
    public void Resume()
    {
        GameObject.FindGameObjectWithTag("ButtonClick").GetComponent<SaveMe>().PlaySound();
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1;
        gameIsPaused = false;
        swiped = false;
        
    }
    public void Pause()
    {
        GameObject.FindGameObjectWithTag("ButtonClick").GetComponent<SaveMe>().PlaySound();
        pauseMenuUI.SetActive(true);
        swiped = false;
        Time.timeScale = 0;
        
        gameIsPaused = true;                
    }

    public void MenuButton()
    {
        GameObject.FindGameObjectWithTag("ButtonClick").GetComponent<SaveMe>().PlaySound();
        pauseMenuUI.SetActive(false);
        
        SceneManager.LoadScene("StartScreen");
    }
    

}
