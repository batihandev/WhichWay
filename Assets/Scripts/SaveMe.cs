using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveMe : MonoBehaviour
{
    private AudioSource buttonClick;
    // Start is called before the first frame update
    
    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
        buttonClick=GetComponent<AudioSource>();
    }
    public void PlaySound()
    {
        if (buttonClick.isPlaying) return;
        buttonClick.Play();
       
    }
    public void StopSound()
    {
        buttonClick.Stop();
    }
    

    
}
