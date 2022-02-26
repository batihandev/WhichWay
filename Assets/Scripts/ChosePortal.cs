using UnityEngine;

public class ChosePortal : MonoBehaviour
{
    // Start is called before the first frame update
    Transform[] portals;
    public GameObject portal;
    int choseportal;
    float speed = 3;
    
    public static int portalNumber;
    public Transform portalCheck;
    public static bool changePortalCheck=false;
    bool Up = false;
    float random;
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
        if (Spawner.score > 9)
        {
            speed = 3 + (Mathf.Log(Spawner.score -8)) / 3;
            if (Up)
            {
                Spawner.thisWay = speed;
            }
            else
            {
                Spawner.thisWay = -speed;
            }
        }
        
        if (changePortalCheck)
        {
            random = Random.Range(Spawner.score, 200);
            if (random > 125)
            {
                Destroy(portal);
                portalspawner();
                changePortalCheck = false;
                
            }

            
            changePortalCheck = false;
        }
       // Debug.Log(speed+"speed"+Mathf.Log(100));
    }
    void portalspawner()
    {
        choseportal = Random.Range(0, portals.Length);
        if (choseportal >= 3 )
        {
            Spawner.portalIsDown=false;
            Spawner.thisWay= speed ;
            Up = true;
        }
        else
        {
            Spawner.portalIsDown = true;
            Spawner.thisWay = -speed;
            Up = false;
        }
        portal = Instantiate(portal, portals[choseportal]);
        portalNumber = Spawner.whichCube;
        portalCheck.position = portals[choseportal].position;
       // Debug.Log("portalyönüaþaðý" + Spawner.portalisdown);
    }
}

