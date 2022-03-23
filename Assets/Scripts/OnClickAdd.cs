
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
        if (!adstarClicked)
        {
            adstarClicked = true; 
            
            GameObject.FindGameObjectWithTag("ButtonClick").GetComponent<SaveMe>().PlaySound();
            GameObject.FindGameObjectWithTag("ButtonClick").GetComponent<GoogleADMOBmanager>().ShowRewardedAd();
           // starclickCount = PlayerPrefs.GetInt("starClickCount", 0);
            //starclickCount++;
          //  PlayerPrefs.SetInt("starClickCount", starclickCount);
                
            
        }
        
    }
}
