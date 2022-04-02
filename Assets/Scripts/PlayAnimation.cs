
using UnityEngine;

public class PlayAnimation : MonoBehaviour
{
    public Animator anim;
    
    void Awake()
    {
        anim.Play("portal");
    }

  
}
