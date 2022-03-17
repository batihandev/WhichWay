
using UnityEngine;

public class OnClickAdd : MonoBehaviour
{
    public static bool adstarClicked=false;
    private void Awake()
    {
        adstarClicked = false;
    }
    void OnMouseDown()
    {
        if (!adstarClicked)
        {
            adstarClicked = true;
            GameObject.FindGameObjectWithTag("Pwaypoint").GetComponent<AdsStarScript>().AdsStarEffect();
            GameObject.FindGameObjectWithTag("ButtonClick").GetComponent<SaveMe>().PlaySound();
            if (ChosePortal.starportalsDestroyed)
            {
                ChosePortal.starisClicked = true;
            }
        }
        
    }
}
