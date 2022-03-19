
using UnityEngine;

public class ScoreCatcher : MonoBehaviour
{
    public static bool scoreCatch = false;
    void Awake()
    {
        scoreCatch = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    //private void OnTriggerEnter2D(Collider2D collision)
    //{
    //    Debug.Log("collide");
    //}
    private void OnTriggerEnter(Collider other)
    {
        if (!ChosePortal.starClickedPortal)
        {
           // Debug.Log("collide");
            scoreCatch = true;
        }
        
    }
}
