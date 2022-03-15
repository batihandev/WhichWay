using System.Collections;
using System.Collections.Generic;
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
        Debug.Log("collide");
        scoreCatch = true;
    }
}
