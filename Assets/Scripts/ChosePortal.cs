using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ChosePortal : MonoBehaviour
{
    // Start is called before the first frame update
    Transform[] portalWaypoints;
    public GameObject portal;
    public GameObject portalForStar;
    GameObject[] portalS = {null,null};
    GameObject[] portalStar_ = { null, null, null, null, null, null };
    
    //List<GameObject> portalStar = new List<GameObject>();
    int choseportal;
    float speed = 2.5f;
    Animator[] portalAnim = { null, null };
    Animator[] portalStarAnim= { null, null, null, null, null, null };
    //int chosenNumber;
    int savePortalNumber=0;
    List<int> portalSpawnCount = new List<int> { 1, 2, 3, 4, 5 };
    public static int portalNumber;
    public static float portalSpawnSpeed=1;
    public Transform portalCheck;
    public static bool changePortalCheck=false;
    public static bool Up = false;
    float random;
    bool animationplaying = false;
    bool animatiyonplayingReverse = false;
    public static bool starClickedPortal=false;
    float counter;
    bool startcounter=false;
    bool starportalsDestroyed = true;
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
        portalS[0] = Instantiate(portal, portalWaypoints[choseportal]);
        
        
        
        
        portalAnim[0] = portalS[0].GetComponent(typeof(Animator)) as Animator;
        //portalCheck.position = portalI.transform.position;
        Spawner.thisWay = -speed;
    }

    // Update is called once per frame
    void Update()
    {
        if (startcounter) { counter += Time.deltaTime; }
        
        if (counter > 5 &&startcounter) 
        {
            StarPortalsDestroy();
            startcounter = false;
            counter = 0;
        }
        if (starClickedPortal)
        {
            StarPortals();

        }
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
            //if (Up)
            //{
            //    Spawner.thisWay = speed;
            //}
            //else
            //{
            //    Spawner.thisWay = -speed;
            //}
        }
        
        if (changePortalCheck && !animationplaying && !animatiyonplayingReverse &&!startcounter &&starportalsDestroyed)
        {
            random = Random.Range(Spawner.score, 200);
            if (random > 125)
            {

                if (portalS[0] != null)
                {
                    portalAnim[0] = portalS[0].GetComponent(typeof(Animator)) as Animator;
                    portalAnim[0].enabled = true;
                    portalAnim[0].SetFloat("Direction 1", 1);
                    portalAnim[0].Play("Reverse 1");
                }
                if (portalS[1] != null)
                {
                    portalAnim[1] = portalS[1].GetComponent(typeof(Animator)) as Animator;
                    portalAnim[1].enabled = true;
                    portalAnim[1].SetFloat("Direction 1", 1);
                    portalAnim[1].Play("Reverse 1");
                }



                animatiyonplayingReverse = true;
                Invoke("AnimationReverse", portalSpawnSpeed);
                //Invoke("portalspawner", portalSpawnSpeed);
                Portalspawner();
                
                
                //portalspawner();
                changePortalCheck = false;
                
            }

            
            changePortalCheck = false;
        }
       // Debug.Log(speed+"speed"+Mathf.Log(100));
    }
    void AnimationReverse()
    {
        animatiyonplayingReverse = false;
        //portalS.RemoveAt(0);
    }
    void Animationz()
    {
        animationplaying = false;
        
        //Invoke("ListClear", portalSpawnSpeed);
        
       // portalS.Insert(1, portal);
    }
    
    void Portalspawner()
    {


        if (portalS[0] == null)
        {
            Destroy(portalS[1], portalSpawnSpeed);

            //choseportal = Random.Range(0, portalWaypoints.Length);
            int portalRandom = Random.Range(0, portalSpawnCount.Count);
            choseportal = portalSpawnCount[portalRandom];
            portalSpawnCount.Add(savePortalNumber);
            portalSpawnCount.Remove(choseportal);

            savePortalNumber = choseportal;
            //chosenNumber = portalSpawnCount[portalRandom];


            if (choseportal >= 3)
            {
                Spawner.portalIsDown = false;
                Spawner.thisWay = speed;
                Up = true;
            }
            else
            {
                Spawner.portalIsDown = true;
                Spawner.thisWay = -speed;
                Up = false;
            }

            portalS[0] = Instantiate(portal, portalWaypoints[choseportal]);




            portalNumber = Spawner.whichCube;
            portalCheck.position = portalWaypoints[choseportal].position;
            // portalAnim.SetFloat("Direction", -1);
            portalAnim[0] = portalS[0].GetComponent(typeof(Animator)) as Animator;
            portalAnim[0].enabled = true;
            portalAnim[0].SetFloat("Direction 1", 1);
            portalAnim[0].Play("portalxz");



            animationplaying = true;
            Invoke("Animationz", portalSpawnSpeed);

        }

        else if (portalS[1] == null)
        { Destroy(portalS[0], portalSpawnSpeed);


            //choseportal = Random.Range(0, portalWaypoints.Length);
            int portalRandom = Random.Range(0, portalSpawnCount.Count);
            choseportal = portalSpawnCount[portalRandom];
            portalSpawnCount.Add(savePortalNumber);
            portalSpawnCount.Remove(choseportal);

            savePortalNumber = choseportal;
            //chosenNumber = portalSpawnCount[portalRandom];


            if (choseportal >= 3)
            {
                Spawner.portalIsDown = false;
                Spawner.thisWay = speed;
                Up = true;
            }
            else
            {
                Debug.Log(choseportal+"choseportals");
                Spawner.portalIsDown = true;
                Spawner.thisWay = -speed;
                Up = false;
            }

            portalS[1] = Instantiate(portal, portalWaypoints[choseportal]);
            



            portalNumber = Spawner.whichCube;
            portalCheck.position = portalWaypoints[choseportal].position;
            // portalAnim.SetFloat("Direction", -1);
            portalAnim[1] = portalS[1].GetComponent(typeof(Animator)) as Animator;
            portalAnim[1].enabled = true;
            portalAnim[1].SetFloat("Direction 1", 1);
            portalAnim[1].Play("portalxz");



            animationplaying = true;
            Invoke("Animationz", portalSpawnSpeed);

        }


        // Debug.Log("portalyönüaþaðý" + Spawner.portalisdown);
    }
    void StarPortals()
    {
        if (Up)
        {
            Spawner.thisWay = -speed;
            Up = false;
        }
        else
        {
            Spawner.thisWay = speed;
            Up = true;
        }
        if (portalS[0] != null)
        {
            Destroy(portalS[0], portalSpawnSpeed);
            portalAnim[0] = portalS[0].GetComponent(typeof(Animator)) as Animator;
            portalAnim[0].enabled = true;
            portalAnim[0].SetFloat("Direction 1", 1);
            portalAnim[0].Play("Reverse 1");
        }
        if (portalS[1] != null)
        {
            Destroy(portalS[1], portalSpawnSpeed);
            portalAnim[1] = portalS[1].GetComponent(typeof(Animator)) as Animator;
            portalAnim[1].enabled = true;
            portalAnim[1].SetFloat("Direction 1", 1);
            portalAnim[1].Play("Reverse 1");
        }


        animatiyonplayingReverse = true;
        Invoke("AnimationReverse", portalSpawnSpeed);
       
        

        //alt taraf asýl
        //ScoreCatcher.scoreCatch = false;
        starClickedPortal = false;
        startcounter = true;
        starportalsDestroyed = false;
        Invoke("StarPortalWait", portalSpawnSpeed);
     
         
     

    }
    void StarPortalWait()
    {
      

        for (int i = 0; i < 6; i++)
        {
            portalStar_[i] = Instantiate(portalForStar, portalWaypoints[i]);
            //portalStar.Add(portalStar_);
            portalStarAnim[i] = portalStar_[i].GetComponent(typeof(Animator)) as Animator;
            portalStarAnim[i].enabled = true;
            portalStarAnim[i].SetFloat("Direction", 1);
            portalStarAnim[i].Play("portal");
           
        }
    }
    void StarPortalsDestroy()
    {
        
        
        for (int i = 0; i < 6; i++)
        {
            Destroy(portalStar_[i], portalSpawnSpeed);
            //portalStar.Add(portalStar_);
            //portalStarAnim[i] = portalStar_[i].GetComponent(typeof(Animator)) as Animator;
            //portalStarAnim[i].enabled = true;
            portalStarAnim[i].SetFloat("Direction", 1);
            portalStarAnim[i].Play("Reverse");
           
        }
       
        //chosenNumber = portalSpawnCount[portalRandom];


        if (Up)
        {
            choseportal = Random.Range(0, 3);
            Spawner.thisWay = -speed;

           Up = false;
        }
        else
        {
            Up = true;
            Spawner.thisWay = speed;
            choseportal = Random.Range(3, 6);
        }            
        Invoke("SpawnFirstOne", portalSpawnSpeed);
       







    }

    void SpawnFirstOne()
    {
        
        if (portalS[0] == null)
        {
            portalS[0] = Instantiate(portal, portalWaypoints[choseportal]);
            



            portalNumber = Spawner.whichCube;
            portalCheck.position = portalWaypoints[choseportal].position;
            // portalAnim.SetFloat("Direction", -1);
            portalAnim[0] = portalS[0].GetComponent(typeof(Animator)) as Animator;
            portalAnim[0].enabled = true;
            portalAnim[0].SetFloat("Direction 1", 1);
            portalAnim[0].Play("portalxz");



            animationplaying = true;
            Invoke("Animationz", portalSpawnSpeed);
            starportalsDestroyed = true;
        }
        else if (portalS[1] == null)
        {
            portalS[1] = Instantiate(portal, portalWaypoints[choseportal]);
           



            portalNumber = Spawner.whichCube;
            portalCheck.position = portalWaypoints[choseportal].position;
            // portalAnim.SetFloat("Direction", -1);
            portalAnim[1] = portalS[1].GetComponent(typeof(Animator)) as Animator;
            portalAnim[1].enabled = true;
            portalAnim[1].SetFloat("Direction 1", 1);
            portalAnim[1].Play("portalxz");



            animationplaying = true;
            Invoke("Animationz", portalSpawnSpeed);
            starportalsDestroyed = true;
            starClickedPortal = false;
        }

    }
}

