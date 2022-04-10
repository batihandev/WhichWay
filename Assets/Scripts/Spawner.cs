
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class Spawner : MonoBehaviour
{
    
    public TextMeshProUGUI scoregaintext;
    bool scoregained;
    private Vector3 scoregainEndPos;
    float scoreTextSpeed=2f;
    float journeyLength;
    float startTime;
    int alphaofScoreGain = 0;
    int scoreHold=0;
    Vector3 startPos;
    Vector3 endPos;
    bool lifeLost = false;
    public Image lifeLostPic;
    //Made By Batýhan Özdemir
    public GameObject[] cubes;
    public Transform[] spawnPoints;
    int rondomCube;
    int rondomSpawn;
    public static bool cubeIsSpawned = false;
    GameObject cube;

    public static float thisWay;

    List<GameObject> cubeT = new List<GameObject>();

    public static int whichCube;
    public GameObject objectCheck;
    public static bool portalIsDown;
    public TextMeshProUGUI health;
    public TextMeshProUGUI scoret;
    int lives = 3;
    public static int score = 0;
    int index;
    
    public Transform objectiveCheck;
    public Transform portal;
    public Transform spawnDist;
    bool canspawn = true;
    List<float> destroyDisty = new List<float>();
  
    List<float> distForSpawn = new List<float>();
    string healthS;
    string scoresS;

    float minValy;
    float minValyI;
        float minValyIDown;
   
    public AudioSource forwardCube;
    public AudioSource reverseCube;
    public AudioSource leftCube;
    public AudioSource rightCube;
    public static bool starSameCubeSpawn= false;
    bool starSpawnBegin = false;
    int sameCubeCounter = 5;
    int AdssameCubeCounter = 10;
    
    public static bool addsWatchedForCube = false;
    int samecube;
    public static bool clickedWhileAdsson=false;
    public static bool clickedWhileSpawnsOn = false;
    public static int highScore = 0;
   



    void Awake()
    {
        EndGameMenu.endgameMenuisOn = false;
        starSameCubeSpawn = false;
        addsWatchedForCube = false;
        if (highScore >= 50){
            lives = 5;
        }
        else
        {
            lives = 3;
        }
        
        score = 0;
        if (EndGameMenu.adWatchedToContinue && EndGameMenu.thisIsTheSameGame)
        {
            score = Score.gameoverScore;
            lives = 2;
        }
        cube = Instantiate(cubes[0], spawnPoints[0]);
        cubeT.Add(cube);
        thisWay = 0;
        whichCube = 0;

        cubeIsSpawned = true;

        healthS = "Lives " + lives;
        health.text = healthS;

        scoresS = "Score " + score;
        scoret.text = scoresS;

    }
    private void Start()
    {
        
        if (PlayerPrefs.GetInt("removeAds", 0) == 0) { 
        GameObject.FindGameObjectWithTag("ButtonClick").GetComponent<GoogleADMOBmanager>().RequestAndLoadRewardedAd();
       
        }
    }

    void Update()
    {


        if (scoregained)
        {
            int clrOf = 255 - alphaofScoreGain;
            
            if (alphaofScoreGain != 252)
            {
                alphaofScoreGain+=9;
            }
            scoregaintext.color = new Color32(255, 255, 255,(byte)clrOf);
            float distCovered = (Time.time - startTime) * scoreTextSpeed;
            float fractionOfJourney = distCovered / journeyLength;
            scoregaintext.transform.position = Vector3.Lerp(startPos, endPos, fractionOfJourney);
            float dist = Vector3.Distance(scoregaintext.transform.position, endPos);
            if (fractionOfJourney<=1&&fractionOfJourney>=0.9)
            {
                alphaofScoreGain = 0;
                scoregaintext.color = new Color32(255, 255, 255, 0);
                scoregained = false;
                Debug.Log(scoregained);
            }
        }
      
        if(starSpawnBegin && addsWatchedForCube && clickedWhileAdsson)
        {
            AdssameCubeCounter += 5;
            clickedWhileAdsson = false;
        }
        if(starSpawnBegin && starSameCubeSpawn && clickedWhileSpawnsOn)
        {
            sameCubeCounter += 10;
            clickedWhileSpawnsOn = false;
        }

        ScoreCounter();
        ScoreKeeper();
        
        for (int i = 0; i < cubeT.Count; i++)
        {
            distForSpawn.Add(Mathf.Abs(cubeT[i].transform.position.y - spawnDist.position.y));
            for (int z = 0; z < distForSpawn.Count; z++)
            {
                if (distForSpawn[z] > 2f)
                {
                    canspawn = true;
                    cubeIsSpawned = false;
                }
                else
                {
                    distForSpawn.Clear();
                    canspawn = false;
                    cubeIsSpawned = true;
                    return;
                }
            }

        }

        if (cubeT.Count < 6 && canspawn)
        {
            if (!starSameCubeSpawn && !addsWatchedForCube && !cubeIsSpawned)
            {
                Spawn();
            }
            if ((starSameCubeSpawn||addsWatchedForCube) && !cubeIsSpawned)
            {

               
                SameCubeSpawn();
                if (sameCubeCounter == 0 )
                {
                    starSameCubeSpawn = false;
                    sameCubeCounter = 5;
                    if (!addsWatchedForCube)
                    {
                        starSpawnBegin = false;
                    }
                    
                    

                }
                if (AdssameCubeCounter == 0)
                {
                    AdssameCubeCounter = 10;
                    
                    addsWatchedForCube = false;
                    if (!starSameCubeSpawn)
                    {
                        starSpawnBegin = false;
                    }
                   
                }
            }
            
            
        }











    }
    public void ScoreCounter()
    {
        destroyDisty.Clear();

        

        if (ChosePortal.Up)
        {

            for (int i = 0; i < cubeT.Count; i++)
            {
                destroyDisty.Add(Mathf.Abs(cubeT[0].transform.position.y - 7));


                destroyDisty[i] = Mathf.Abs(cubeT[i].transform.position.y - 7);

            }

        }
        else if (!ChosePortal.Up)
        {

            for (int i = 0; i < cubeT.Count; i++)
            {
                destroyDisty.Add(Mathf.Abs(cubeT[0].transform.position.y - (-7)));

                destroyDisty[i] = Mathf.Abs(cubeT[i].transform.position.y - (-7));

            }

        }
        minValy = destroyDisty.Min();
        index = destroyDisty.IndexOf(minValy);
        minValyI = 7 - cubeT[index].transform.position.y;
        minValyIDown = cubeT[index].transform.position.y - 7;
        

        if (ScoreCatcher.scoreCatch == true || (ChosePortal.starClickedPortal||ChosePortal.adsStarOn))
        //burayý deðiþtir portalýn þekli deðiþirse
        {
            if(minValyI <0.5f || minValyIDown < -13.5f) { 
            ScoreCatcher.scoreCatch = false;

            
            ChosePortal.changePortalCheck = true;
            score++;
                int _highScore = highScore;
            if(score> _highScore)
            {

                highScore=score;
                    

                }
            if (highScore >= 50)
            {
                if (score > 50)
                {
                    if (score % 50 == 0)
                    {
                        lives++;
                            healthS = "Lives " + lives;
                            health.text = healthS;
                        }
                }
            }
           
            scoresS = "Score " + score;
            scoret.text = scoresS;


            if (score % 2 == 0)
            {
              
                reverseCube.Play();
               
            }
            else
            {
              
                forwardCube.Play();
                
            }


                if (scoreHold != score)
                {
                    scoreHold = score;
                    if (ChosePortal.Up)
                    {
                        scoregaintext.color = new Color32(255, 255, 255, 255);
                        alphaofScoreGain = 0;

                        startPos = new(cubeT[index].transform.position.x, cubeT[index].transform.position.y - 0.5f, cubeT[index].transform.position.z);
                        scoregaintext.transform.position = startPos;
                        endPos = new(cubeT[index].transform.position.x, cubeT[index].transform.position.y - 3, cubeT[index].transform.position.z);
                        scoregainEndPos = endPos;
                        startTime = Time.time;
                        journeyLength = Vector3.Distance(startPos, endPos);
                    }
                    else
                    {
                        scoregaintext.color = new Color32(255, 255, 255, 255);
                        alphaofScoreGain = 0;
                        startPos = new(cubeT[index].transform.position.x, cubeT[index].transform.position.y + 0.5f, cubeT[index].transform.position.z);
                        scoregaintext.transform.position = startPos;
                        endPos = new(cubeT[index].transform.position.x, cubeT[index].transform.position.y + 3, cubeT[index].transform.position.z);
                        scoregainEndPos = endPos;
                        startTime = Time.time;
                        journeyLength = Vector3.Distance(startPos, endPos);
                    }

                    scoregained = true;
                }
                
                
               
            

            Destroy(cubeT[index]);
            cubeT.RemoveAt(index);


                


            }
        }
    }
    public void ScoreKeeper()
    {



        destroyDisty.Clear();

      

        if (ChosePortal.Up)
        {
            
            for (int i = 0; i < cubeT.Count; i++)
            {
                destroyDisty.Add(Mathf.Abs(cubeT[0].transform.position.y - 7));


                destroyDisty[i] = Mathf.Abs(cubeT[i].transform.position.y - 7);

            }
            
        }
        else if (!ChosePortal.Up)
        {
            
            for (int i = 0; i < cubeT.Count; i++)
            {
                destroyDisty.Add(Mathf.Abs(cubeT[0].transform.position.y - (-7)));

                destroyDisty[i] = Mathf.Abs(cubeT[i].transform.position.y - (-7));

            }
            
        }
        minValy = destroyDisty.Min();
        index = destroyDisty.IndexOf(minValy);
        minValyI = 7- cubeT[index].transform.position.y;
        minValyIDown = cubeT[index].transform.position.y -7;
       

        if (minValyI < -0.1f ||minValyIDown<-14.1f)
            {
                if (lives == 1)
                {
                


                    Time.timeScale = 0;
                    healthS = "Lives " + lives;
                    health.text = healthS;
                    SceneManager.LoadScene("GameOver");
                    reverseCube.Stop();
                    leftCube.Stop();
                    forwardCube.Stop();
                    rightCube.Play();

                }
                else if (lives > 1)
                {


                    
                    ChosePortal.changePortalCheck = true;
                    lives--;
                     ChosePortal.died = true;
                    healthS = "Lives " + "  " + lives;
                    health.text = healthS;

                    StartCoroutine(LifeLostEffect());
                    leftCube.Play();
                   
                    Destroy(cubeT[index]);
                    cubeT.RemoveAt(index);
                   



                }

            }

        

        
      
      



    }
    IEnumerator LifeLostEffect()
    {
        Color alphaL = lifeLostPic.color;

        alphaL.a = 1 - 0.5f;
        lifeLostPic.color = alphaL;
        yield return new WaitForSeconds(0.1f);
        lifeLost = false;

        alphaL.a = 1 - 1f;
        lifeLostPic.color = alphaL;
    }
    public void Spawn()
    {

        rondomSpawn = Random.Range(0, spawnPoints.Length);
        rondomCube = Random.Range(0, cubes.Length);
        whichCube = rondomCube;
        cube = Instantiate(cubes[rondomCube], spawnPoints[rondomSpawn]);


        cubeT.Add(cube);



        cubeIsSpawned = true;

    }
    public void SameCubeSpawn()
    {
        if(sameCubeCounter == 5 && !addsWatchedForCube && !starSpawnBegin)
        {
            starSpawnBegin = true;
            samecube = Random.Range(0, cubes.Length);

        }
        if (AdssameCubeCounter == 10 && addsWatchedForCube && !starSpawnBegin)
        {
            starSpawnBegin = true;
            samecube = Random.Range(0, cubes.Length);

        }
        if (starSameCubeSpawn)
        {
            sameCubeCounter--;
        }
        if (addsWatchedForCube)
        {
            AdssameCubeCounter--;
        }

       
        rondomSpawn = Random.Range(0, spawnPoints.Length);
        
        whichCube = samecube;
        cube = Instantiate(cubes[samecube], spawnPoints[rondomSpawn]);


        cubeT.Add(cube);

        cubeIsSpawned = true;

    }
}

