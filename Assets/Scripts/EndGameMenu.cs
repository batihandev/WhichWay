
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndGameMenu : MonoBehaviour
{

    public void playgame()
    {

        //testgl
        Time.timeScale = 1;
        SceneManager.LoadScene("GamePlay");
        
    }
    public void startMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("StartScreen");
    }
    
}
