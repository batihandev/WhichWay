
using UnityEngine;

using UnityEngine.SceneManagement;

public class StartScreen : MonoBehaviour
{
    int firstTime;
    public GameObject howtoplay;
    public GameObject menu;
    // Start is called before the first frame update
    void Awake()
    {
        GameObject.FindGameObjectWithTag("ButtonClick").GetComponent<GoogleADMOBmanager>().RequestBannerAd();
    }
    public void playgame()
    {
        EndGameMenu.thisIsTheSameGame = false;
        GameObject.FindGameObjectWithTag("ButtonClick").GetComponent<GoogleADMOBmanager>().DestroyBannerAd();
        //testgl 
        firstTime =PlayerPrefs.GetInt("firstTime");
        if (firstTime == 0)
        {
            menu.SetActive(false);
            howtoplay.SetActive(true);
            PlayerPrefs.SetInt("firstTime", 1);
                

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
        GameObject.FindGameObjectWithTag("ButtonClick").GetComponent<SaveMe>().PlaySound();
        Application.Quit();
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
