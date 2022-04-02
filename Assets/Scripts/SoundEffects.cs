using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundEffects : MonoBehaviour
{
    public AudioSource whicheverObjectThisIsAttachedTo;
    

    public void PlaySound()
    {
        whicheverObjectThisIsAttachedTo.Play();
    }
   
}
