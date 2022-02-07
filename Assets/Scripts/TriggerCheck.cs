using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerCheck : MonoBehaviour
{
    public static float  distx;
    public static float disty;
    public Transform objectivecheck;
    public Transform portal;
    // Start is called before the first frame update
    void Awake()
    {
        disty = 5f;
    }

    private void Update()
    {
        distx = Mathf.Abs(portal.position.x- objectivecheck.position.x);
        disty = Mathf.Abs(portal.position.y - objectivecheck.position.y);
        Debug.Log(disty+"disty");
        
        //deli
    }
}


