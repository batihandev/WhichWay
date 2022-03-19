
using UnityEngine;


public class ChoseStar : MonoBehaviour
{

    Transform[] portalWaypoints;
    public GameObject star;
    GameObject starSpawn;
    Animator starAnim;
    
    int random;
    float randomSx;
    float randomSy;
    int randomDir;
    bool secondspassed;
    
    float count;
    bool thereIsAStar=false;
    float x;
    float y;
    bool bouncedOnce=false;
    Vector2 nextPosition;
    bool deadManWalk = false;
    float deadCount;
    int starEffectCalc=0;
    
    
    // Start is called before the first frame update
    void Awake()
    {
        portalWaypoints = new Transform[transform.childCount];
        for (int i = 0; i < portalWaypoints.Length; i++)
        {
            portalWaypoints[i] = transform.GetChild(i);
        }




    }

    // Update is called once per frame
    void Update()
    {
        if(PlayerPrefs.GetInt("highScore") >= 25)
        {
            
            if (deadManWalk && deadCount < 0.9f && starSpawn != null)
            {
                x = starSpawn.transform.position.x;
                y = starSpawn.transform.position.y;
                deadCount += Time.deltaTime;
                randomSx = Random.Range(0.0f, 2.0f);
                randomSy = Random.Range(0.5f, 3f);
                x += randomSx;
                y += randomSy;
                nextPosition = new Vector2(x, y);
                starSpawn.transform.position = Vector2.Lerp(starSpawn.transform.position, nextPosition, Time.deltaTime * 1);

            }
            if (!thereIsAStar)
            {
                count += Time.deltaTime;
                //Debug.Log(count);
            }
            if (PlayerPrefs.GetInt("highScore") >= 200)
            {
                if (count > 10)
                {
                    secondspassed = true;
                }
            }
            else if(count > 15)
            {
                secondspassed = true;

            }
            if (secondspassed && !thereIsAStar)
            {
                randomDir = Random.Range(0, 2);
                random = Random.Range(0, portalWaypoints.Length);
                starSpawn = Instantiate(star, portalWaypoints[random]);
                starAnim = starSpawn.GetComponent<Animator>();
                // starSpawn.GetComponent<Button>().onClick.AddListener(delegate { StarEffect(random); });

                thereIsAStar = true;
                secondspassed = false;
                deadManWalk = false;
                count = 0;
            }
            if (thereIsAStar)
            {
                MoveStar(random);

            }
            
                }
        

    }
    void MoveStar(int index)
    {
        x = starSpawn.transform.position.x;
        y = starSpawn.transform.position.y;
        //randomSx = Random.Range(0.0f,2.0f);
        //randomSy = Random.Range(0.0f, 2.0f);
        //x = x + randomSx;
        //y = y + randomSy;
        //nextPosition = new Vector2(x, y);
        //starSpawn.transform.position = Vector2.Lerp(starSpawn.transform.position, nextPosition, Time.deltaTime * 1);
        switch (index)
        {
            case 0:
                if (randomDir == 0)
                {
                    
                    randomSx = Random.Range(0.0f, 2.0f);
                    randomSy = Random.Range(0.5f, 3f);
                    x += randomSx;
                    y += randomSy;
                    nextPosition = new Vector2(x, y);
                    starSpawn.transform.position = Vector2.Lerp(starSpawn.transform.position, nextPosition, Time.deltaTime * 1);
                    if (x > 4.5 && !bouncedOnce)
                    {
                        randomDir = 1;
                        bouncedOnce = true;
                        break;
                    }
                    else  if((x > 6 || y > 15 || x < -6 || y < -15) && bouncedOnce  )
                    {
                        DeadManWalking();
                    }
                }
                else if(randomDir==1)
                {
                    
                    randomSx = Random.Range(0.0f, 2.0f);
                    randomSy = Random.Range(0.5f, 3.0f);
                    x  -= randomSx;
                    y  += randomSy;
                    nextPosition = new Vector2(x, y);
                    starSpawn.transform.position = Vector2.Lerp(starSpawn.transform.position, nextPosition, Time.deltaTime * 1);
                    if (x < -4.5 && !bouncedOnce)
                    {
                        randomDir = 0;
                        bouncedOnce = true;
                        break;
                    }
                    else if ((x > 6 || y > 15 || x < -6 || y < -15) && bouncedOnce)
                    {
                        DeadManWalking();
                    }
                }

               
                //alt orta
                break;
            case 1:
                if (randomDir == 0)
                {
                    
                    randomSx = Random.Range(0.0f, 2.0f);
                    randomSy = Random.Range(0.5f, 3f);
                    x += randomSx;
                    y += randomSy;
                    nextPosition = new Vector2(x, y);
                    starSpawn.transform.position = Vector2.Lerp(starSpawn.transform.position, nextPosition, Time.deltaTime * 1);
                    if (x > 4.5 && !bouncedOnce)
                    {
                        randomDir = 1;
                        bouncedOnce = true;
                        break;
                    }
                    else if ((x > 6 || y > 15 || x < -6 || y < -15) && bouncedOnce)
                    {
                        DeadManWalking();
                    }
                }
                else if (randomDir == 1)
                {
                    
                    randomSx = Random.Range(0.0f, 2.0f);
                    randomSy = Random.Range(0.5f, 3.0f);
                    x -= randomSx;
                    y += randomSy;
                    nextPosition = new Vector2(x, y);
                    starSpawn.transform.position = Vector2.Lerp(starSpawn.transform.position, nextPosition, Time.deltaTime * 1);
                    if (x < -4.5 && !bouncedOnce)
                    {
                        randomDir = 0;
                        bouncedOnce = true;
                        break;
                    }
                    else if ((x > 6 || y > 15 || x < -6 || y < -15) && bouncedOnce)
                    {
                        DeadManWalking();
                    }
                }
                //alt sað
                break;
            case 2:
                if (randomDir == 0)
                {
                    
                    randomSx = Random.Range(0.0f, 2.0f);
                    randomSy = Random.Range(0.5f, 3f);
                    x += randomSx;
                    y += randomSy;
                    nextPosition = new Vector2(x, y);
                    starSpawn.transform.position = Vector2.Lerp(starSpawn.transform.position, nextPosition, Time.deltaTime * 1);
                    if (x > 4.5 && !bouncedOnce)
                    {
                        randomDir = 1;
                        bouncedOnce = true;
                        break;
                    }
                    else if ((x > 6 || y > 15 || x < -6 || y < -15) && bouncedOnce)
                    {
                        DeadManWalking();
                    }
                }
                else if (randomDir == 1)
                {
                    
                    randomSx = Random.Range(0.0f, 2.0f);
                    randomSy = Random.Range(0.5f, 3.0f);
                    x -= randomSx;
                    y += randomSy;
                    nextPosition = new Vector2(x, y);
                    starSpawn.transform.position = Vector2.Lerp(starSpawn.transform.position, nextPosition, Time.deltaTime * 1);
                    if (x < -4.5 && !bouncedOnce)
                    {
                        randomDir = 0;
                        bouncedOnce = true;
                        break;
                    }
                    else if ((x > 6 || y > 15 || x < -6 || y < -15) && bouncedOnce)
                    {
                        DeadManWalking();
                    }
                }
                //alt sol
                break;
            case 3:
                if (randomDir == 0)
                {
                    
                    randomSx = Random.Range(0.0f, 2.0f);
                    randomSy = Random.Range(0.5f, 3f);
                    x += randomSx;
                    y -= randomSy;
                    nextPosition = new Vector2(x, y);
                    starSpawn.transform.position = Vector2.Lerp(starSpawn.transform.position, nextPosition, Time.deltaTime * 1);
                    if (x > 4.5 && !bouncedOnce)
                    {
                        randomDir = 1;
                        bouncedOnce = true;
                        break;
                    }
                    else if ((x > 6 || y > 15 || x < -6 || y < -15) && bouncedOnce)
                    {
                        DeadManWalking();
                    }
                }
                else if (randomDir == 1)
                {
                    
                    randomSx = Random.Range(0.0f, 2.0f);
                    randomSy = Random.Range(0.5f, 3.0f);
                    x -= randomSx;
                    y -= randomSy;
                    nextPosition = new Vector2(x, y);
                    starSpawn.transform.position = Vector2.Lerp(starSpawn.transform.position, nextPosition, Time.deltaTime * 1);
                    if (x < -4.5 && !bouncedOnce)
                    {
                        randomDir = 0;
                        bouncedOnce = true;
                        break;
                    }
                    else if ((x > 6 || y > 15 || x < -6 || y < -15) && bouncedOnce)
                    {
                        DeadManWalking(); ;
                    }
                }
                //üst orta
                break;
            case 4:
                if (randomDir == 0)
                {
                    
                    randomSx = Random.Range(0.0f, 2.0f);
                    randomSy = Random.Range(0.5f, 3f);
                    x += randomSx;
                    y -= randomSy;
                    nextPosition = new Vector2(x, y);
                    starSpawn.transform.position = Vector2.Lerp(starSpawn.transform.position, nextPosition, Time.deltaTime * 1);
                    if (x > 4.5 && !bouncedOnce)
                    {
                        randomDir = 1;
                        bouncedOnce = true;
                        break;
                    }
                    else if ((x > 6 || y > 15 || x < -6 || y < -15) && bouncedOnce)
                    {
                        DeadManWalking();
                    }
                }
                else if (randomDir == 1)
                {
                    
                    randomSx = Random.Range(0.0f, 2.0f);
                    randomSy = Random.Range(0.5f, 3.0f);
                    x -= randomSx;
                    y -= randomSy;
                    nextPosition = new Vector2(x, y);
                    starSpawn.transform.position = Vector2.Lerp(starSpawn.transform.position, nextPosition, Time.deltaTime * 1);
                    if (x < -4.5 && !bouncedOnce)
                    {
                        randomDir = 0;
                        bouncedOnce = true;
                        break;
                    }
                    else if ((x > 6 || y > 15 || x < -6 || y < -15) && bouncedOnce)
                    {
                        DeadManWalking();
                    }
                }
                //üst sað
                break;
            case 5:
                if (randomDir == 0)
                {
                    
                    randomSx = Random.Range(0.0f, 2.0f);
                    randomSy = Random.Range(0.5f, 3f);
                    x += randomSx;
                    y -= randomSy;
                    nextPosition = new Vector2(x, y);
                    starSpawn.transform.position = Vector2.Lerp(starSpawn.transform.position, nextPosition, Time.deltaTime * 1);
                    if (x > 4.5 && !bouncedOnce)
                    {
                        randomDir = 1;
                        bouncedOnce = true;
                        break;
                    }
                    else if ((x > 6 || y > 15 || x < -6 || y < -15) && bouncedOnce)
                    {
                        DeadManWalking();
                    }
                }
                else if (randomDir == 1)
                {
                    
                    randomSx = Random.Range(0.0f, 2.0f);
                    randomSy = Random.Range(0.5f, 3.0f);
                    x -= randomSx;
                    y -= randomSy;
                    nextPosition = new Vector2(x, y);
                    starSpawn.transform.position = Vector2.Lerp(starSpawn.transform.position, nextPosition, Time.deltaTime * 1);
                    if (x < -4.5 && !bouncedOnce)
                    {
                        randomDir = 0;
                        bouncedOnce = true;
                        break;
                    }
                    else if ((x > 6 || y > 15 || x < -6 || y < -15) && bouncedOnce)
                    {
                        DeadManWalking();
                    }
                }
                //üst sol
                break;
        }
        
    }
    void DeadManWalking()
    {
        starAnim.SetBool("StarIsDying", true);
        deadManWalk = true;
        bouncedOnce = false;
        deadCount = 0;
        Destroy(starSpawn, 1f);
        thereIsAStar = false;
        Invoke("StarClickedOnce", 1);
    }
    void StarClickedOnce()
    {
        OnClick.StarClicked = false;
    }
    public void StarEffect()
    {
       // Debug.Log("button works");
             
        if (PlayerPrefs.GetInt("highScore") >= 100)
        {
            if (starEffectCalc < 1)
            {
                Spawner.starSameCubeSpawn = true;
                Spawner.clickedWhileAdsson = true;
                starEffectCalc++;
            }
            else
            {
                starEffectCalc = 0;
                int randomEffect = Random.Range(0, 3);
                if (randomEffect > 1)
                {
                    ChosePortal.starClickedPortal = true;
                    ChosePortal.StarClickedWhileOpen = true;
                   // Debug.Log("starportalnorm");
                    
                }
                else { 
                    Spawner.starSameCubeSpawn = true;
                    Spawner.clickedWhileAdsson = true;
                }
                
            }
            
            
        }
        else
        {
            Spawner.starSameCubeSpawn = true;
            Spawner.clickedWhileAdsson = true;
        }
        
        
        DeadManWalking();
        


    }

}

