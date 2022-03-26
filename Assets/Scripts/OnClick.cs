
using UnityEngine;

public class OnClick : MonoBehaviour
{
    public static bool StarClicked=false;
    public static int starClickCount;
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
            
            starClickCount++;
            
            if (ChosePortal.starportalsDestroyed)
            {
                ChosePortal.starisClicked = true;
            }
        }
       
       
    }
}
