
using UnityEngine;


public class OnClickAdd : MonoBehaviour
{
    public static bool adstarClicked=false;
    //public GameObject adConfrimScreen;
    
    private void Awake()
    {
        adstarClicked = false;
    }
    void OnMouseDown()
    {
        if (!adstarClicked&& !PauseMenu.gameIsPaused)
        {
            if (PlayerPrefs.GetInt("removeAds", 0) == 1)
            {
                OnClickAdd.adstarClicked = true;
                GameObject.FindGameObjectWithTag("Pwaypoint").GetComponent<AdsStarScript>().AdsStarEffect();
                GameObject.FindGameObjectWithTag("ButtonClick").GetComponent<SaveMe>().PlaySound();
                //EndGameMenu.adWatchedToContinue = true;
                if (ChosePortal.starportalsDestroyed)
                {
                    ChosePortal.starisClicked = true;
                }
            }
            else if  (PlayerPrefs.GetInt("removeAds", 0) == 0)
            {

                GameObject.FindGameObjectWithTag("Menu").GetComponent<PauseMenu>().AdScreen();


            }

            
                
            
        }
       


    }
}
