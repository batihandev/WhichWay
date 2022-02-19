
using UnityEngine;

public class ChosePortal : MonoBehaviour
{
    // Start is called before the first frame update
    Transform[] portals;
    public GameObject portal;
    int choseportal;
    int speed = 5;
    public static int portalNumber;
    public Transform portalCheck;
    public static bool portalIsGone=false;
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
        portalCheck.position = portal.transform.position;
        Spawner.thisWay = -speed;
    }

    // Update is called once per frame
    void Update()
    {
        if (portalIsGone)
        {
            Destroy(portal);
            portalspawner();
            portalIsGone = false;
        }
    }
    void portalspawner()
    {
        choseportal = Random.Range(0, portals.Length);
        if (choseportal >= 3 )
        {
            Spawner.portalIsDown=false;
            Spawner.thisWay = speed;
        }
        else
        {
            Spawner.portalIsDown = true;
            Spawner.thisWay = -speed;
        }
        portal = Instantiate(portal, portals[choseportal]);
        portalNumber = Spawner.whichCube;
        portalCheck.position = portals[choseportal].position;
       // Debug.Log("portalyönüaþaðý" + Spawner.portalisdown);
    }
}

