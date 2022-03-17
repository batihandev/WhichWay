
using UnityEngine;

public class OnClickAdd : MonoBehaviour
{
    void OnMouseDown()
    {

        GameObject.FindGameObjectWithTag("Pwaypoint").GetComponent<AdsStarScript>().AdsStarEffect();
        GameObject.FindGameObjectWithTag("ButtonClick").GetComponent<SaveMe>().PlaySound();
    }
}
