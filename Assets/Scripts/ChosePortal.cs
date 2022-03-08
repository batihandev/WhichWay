using UnityEngine;

public class ChosePortal : MonoBehaviour
{
    // Start is called before the first frame update
    Transform[] portals;
    public GameObject portal;
    int choseportal;
    float speed = 3;
    Animator portalAnim;
    public static int portalNumber;
    public static float portalSpawnSpeed=1;
    public Transform portalCheck;
    public static bool changePortalCheck=false;
    bool Up = false;
    float random;
    bool animationplaying = false;
    bool animatiyonplayingReverse = false;
    private void Awake()
    {
        portalSpawnSpeed = 1;
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
        portalAnim = portal.GetComponent(typeof(Animator)) as Animator;
        portalCheck.position = portal.transform.position;
        Spawner.thisWay = -speed;
    }

    // Update is called once per frame
    void Update()
    {
       // Debug.Log(portalAnim.GetCurrentAnimatorStateInfo(0).IsName("portal"));
        if (Spawner.score > 9)
        {
            speed = 3 + (Mathf.Log(Spawner.score -8)) / 3;
            portalSpawnSpeed = 1 - ((Mathf.Log(Spawner.score - 7)) / 5);
            if (Up)
            {
                Spawner.thisWay = speed;
            }
            else
            {
                Spawner.thisWay = -speed;
            }
        }
        
        if (changePortalCheck && !animationplaying && !animatiyonplayingReverse )
        {
            random = Random.Range(Spawner.score, 200);
            if (random > 125)
            {

                //portalAnim.SetFloat("Direction", -1);
                portalAnim = portal.GetComponent(typeof(Animator)) as Animator;
                
                portalAnim.SetFloat("Direction", 1);
                portalAnim.Play("Reverse");
                portalAnim.enabled = true;
                animatiyonplayingReverse = true;
                Invoke("animationReverse", portalSpawnSpeed);
                Invoke("portalspawner", portalSpawnSpeed);
                
                
                //portalspawner();
                changePortalCheck = false;
                
            }

            
            changePortalCheck = false;
        }
       // Debug.Log(speed+"speed"+Mathf.Log(100));
    }
    void animationReverse()
    {
        animatiyonplayingReverse = false;
    }
    void animation()
    {
        animationplaying = false;
    }
    void portalspawner()
    {
        Destroy(portal);
        
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
        // portalAnim.SetFloat("Direction", -1);
        portalAnim = portal.GetComponent(typeof(Animator)) as Animator;
        portalAnim.SetFloat("Direction", 1);
        portalAnim.Play("portal", 0);
        portalAnim.enabled = true;
       
        animationplaying = true;
        Invoke("animation", portalSpawnSpeed);

        // Debug.Log("portalyönüaþaðý" + Spawner.portalisdown);
    }
}

