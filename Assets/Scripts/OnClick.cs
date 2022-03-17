
using UnityEngine;

public class OnClick : MonoBehaviour
{
    public static bool StarClicked=false;
     void Awake()
    {
        StarClicked = false;
    }
    void OnMouseDown()
    {
        if (!StarClicked)
        {
            StarClicked = true;
            GameObject.FindGameObjectWithTag("Pwaypoint").GetComponent<ChoseStar>().StarEffect();
            GameObject.FindGameObjectWithTag("ButtonClick").GetComponent<SaveMe>().PlaySound();
            if (ChosePortal.starportalsDestroyed)
            {
                ChosePortal.starisClicked = true;
            }
        }
       
       
    }
}
