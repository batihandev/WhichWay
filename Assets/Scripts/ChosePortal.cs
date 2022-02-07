
using UnityEngine;

public class ChosePortal : MonoBehaviour
{
    // Start is called before the first frame update
    Transform[] portals;
    public GameObject portal;
    int choseportal;
    int speed = 5;
    public static int portalnumber;
    public Transform portalcheck;
    public static bool portalisgone=false;
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
        choseportal = Random.Range(1, 3);
        portal = Instantiate(portal, portals[choseportal]);
        portalcheck.position = portal.transform.position;
        Spawner.thisway = -speed;
    }

    // Update is called once per frame
    void Update()
    {
        if (portalisgone)
        {
            Destroy(portal);
            portalspawner();
            portalisgone = false;
        }
    }
    void portalspawner()
    {
        choseportal = Random.Range(0, portals.Length);
        if (choseportal >= 3 )
        {
            Spawner.portalisdown=false;
            Spawner.thisway = speed;
        }
        else
        {
            Spawner.portalisdown = true;
            Spawner.thisway = -speed;
        }
        portal = Instantiate(portal, portals[choseportal]);
        portalnumber = Spawner.whichcube;
        portalcheck.position = portals[choseportal].position;
       // Debug.Log("portalyönüaþaðý" + Spawner.portalisdown);
    }
}

