using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnClick : MonoBehaviour
{
    
    void OnMouseDown()
    {
        
        GameObject.FindGameObjectWithTag("Pwaypoint").GetComponent<ChoseStar>().StarEffect();
    }
}
