
using UnityEngine;

public class OnClickAdd : MonoBehaviour
{
    public static bool adstarClicked=false;
    int starclickCount;
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
                GameObject.FindGameObjectWithTag("ButtonClick").GetComponent<SaveMe>().PlaySound();
                GameObject.FindGameObjectWithTag("ButtonClick").GetComponent<GoogleADMOBmanager>().ShowRewardedAd();
            }

            
           // starclickCount = PlayerPrefs.GetInt("starClickCount", 0);
            //starclickCount++;
          //  PlayerPrefs.SetInt("starClickCount", starclickCount);
                
            
        }
       


    }
}
