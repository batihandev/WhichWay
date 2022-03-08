using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ChosePortal : MonoBehaviour
{
    // Start is called before the first frame update
    Transform[] portalWaypoints;
    public GameObject portal;
    List<GameObject> portalS = new List<GameObject>();
    int choseportal;
    float speed = 2.5f;
    Animator portalAnim;
    //int chosenNumber;
    int savePortalNumber=0;
    List<int> portalSpawnCount = new List<int> { 1, 2, 3, 4, 5 };
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
        portalWaypoints = new Transform[transform.childCount];
        for (int i = 0; i < portalWaypoints.Length; i++)
        {
            portalWaypoints[i] = transform.GetChild(i);
        }
    }
    void Start()

    {
        choseportal = 0;
        portal = Instantiate(portal, portalWaypoints[choseportal]);
        portalS.Add(portal);
        
        
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
            if (Spawner.score > 50)
            {
                speed = 2.5f + (Mathf.Log(Spawner.score - 8)) / 2;
            }
            else
            {
                speed = 2.5f + (Mathf.Log(Spawner.score - 8)) / 3;
            }
            
            portalSpawnSpeed = 1 - ((Mathf.Log(Spawner.score - 7)) /50);
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
                //Invoke("portalspawner", portalSpawnSpeed);
                portalspawner();
                
                
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
        //portalS.RemoveAt(0);
    }
    void animation()
    {
        animationplaying = false;
        
        //Invoke("ListClear", portalSpawnSpeed);
        
       // portalS.Insert(1, portal);
    }
    
    void portalspawner()
    {


        Destroy(portalS[0],portalSpawnSpeed); 
        portalS.RemoveAt(0);

        //choseportal = Random.Range(0, portalWaypoints.Length);
        int portalRandom = Random.Range(0, portalSpawnCount.Count);
        choseportal = portalSpawnCount[portalRandom];
        portalSpawnCount.Add(savePortalNumber);
        portalSpawnCount.Remove(choseportal);
        
        savePortalNumber = choseportal;
        //chosenNumber = portalSpawnCount[portalRandom];
        

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
        
        portal = Instantiate(portal, portalWaypoints[choseportal]);
        portalS.Add(portal);

        
        
        portalNumber = Spawner.whichCube;
        portalCheck.position = portalWaypoints[choseportal].position;
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

