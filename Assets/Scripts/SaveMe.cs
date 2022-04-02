
using UnityEngine;

public class SaveMe : MonoBehaviour
{
    private AudioSource buttonClick;
    
    
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
