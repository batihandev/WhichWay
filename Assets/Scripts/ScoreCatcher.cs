
using UnityEngine;

public class ScoreCatcher : MonoBehaviour
{
    public static bool scoreCatch = false;
    void Awake()
    {
        scoreCatch = false;
    }

 
    private void OnTriggerEnter(Collider other)
    {
        if (!ChosePortal.starClickedPortal)
        {
         
            scoreCatch = true;
        }
        
    }
}
