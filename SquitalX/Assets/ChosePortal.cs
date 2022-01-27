using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChosePortal : MonoBehaviour
{
    // Start is called before the first frame update
    Transform[] portals;
    public GameObject portal;
    int choseportal;
    public static bool portalisdown;
    public static int portalnumber;
    private void Awake()
    {
        portals = new Transform[transform.childCount];
        for (int i = 0; i < portals.Length; i++)
        {
            portals[i] = transform.GetChild(i);
        }
    }
    void Start()

    {
        portalspawner();
    }

    // Update is called once per frame
    void Update()
    {
        if (!Spawner.cubeisspawned)
        {
            Destroy(portal);
            portalspawner();

        }
    }
    void portalspawner()
    {
        choseportal = Random.Range(0, portals.Length);
        if (choseportal >= 3)
        {
            portalisdown = true;
            
        }
        else
        {
            portalisdown = false;
        }
        portal = Instantiate(portal, portals[choseportal]);
        portalnumber = Spawner.whichcube;
    }
}

