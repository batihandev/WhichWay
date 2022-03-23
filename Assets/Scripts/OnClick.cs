
using UnityEngine;

public class OnClick : MonoBehaviour
{
    public static bool StarClicked=false;
    int starclickCount;
     void Awake()
    {
        StarClicked = false;
    }
    void OnMouseDown()
    {
        if (!StarClicked && !PauseMenu.gameIsPaused)
        {
            StarClicked = true;
            GameObject.FindGameObjectWithTag("Pwaypoint").GetComponent<ChoseStar>().StarEffect();
            GameObject.FindGameObjectWithTag("ButtonClick").GetComponent<SaveMe>().PlaySound();
            starclickCount = PlayerPrefs.GetInt("starClickCount", 0);
            starclickCount++;
            PlayerPrefs.SetInt("starClickCount", starclickCount);
            if (ChosePortal.starportalsDestroyed)
            {
                ChosePortal.starisClicked = true;
            }
        }
       
       
    }
}
