using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundEffects : MonoBehaviour
{
    public AudioSource whicheverObjectThisIsAttachedTo;
    // Start is called before the first frame update

    public void PlaySound()
    {
        whicheverObjectThisIsAttachedTo.Play();
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
