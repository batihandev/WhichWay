
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
//using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class Spawner : MonoBehaviour
{
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
        //lives = 3;
        if (PlayerPrefs.GetInt("removeAds", 0) == 0) { 
        GameObject.FindGameObjectWithTag("ButtonClick").GetComponent<GoogleADMOBmanager>().RequestAndLoadRewardedAd();
        GameObject.FindGameObjectWithTag("ButtonClick").GetComponent<GoogleADMOBmanager>().RequestAndLoadRewardedAdEndGame();
        }
    }

    void Update()
    {

       
      
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
                    //starSpawnBegin = false;
                    

                }
                if (AdssameCubeCounter == 0)
                {
                    AdssameCubeCounter = 10;
                    
                    addsWatchedForCube = false;
                    if (!starSameCubeSpawn)
                    {
                        starSpawnBegin = false;
                    }
                    //starSpawnBegin = false;
                }
            }
            
            
        }











    }
    public void ScoreCounter()
    {
        destroyDisty.Clear();

        //destroyDistx.Clear();

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
        //Debug.Log(minValyI + "yIup" + minValyIDown + "yIdown"+("score"));

        if (ScoreCatcher.scoreCatch == true || (ChosePortal.starClickedPortal||ChosePortal.adsStarOn))
        //burayý deðiþtir portalýn þekli deðiþirse
        {
            if(minValyI <0.5f || minValyIDown < -13.5f) { 
            ScoreCatcher.scoreCatch = false;

            //Debug.Log((ChosePortal.portalS[0] == null) + "0" + (ChosePortal.portalS[1] == null) + "1" + minValyI2 + "yý2" + minValyI + "yý");
            //ColorOf.isCubeGone = true;
            
            ChosePortal.changePortalCheck = true;
            score++;
                int _highScore = highScore;
            if(score> _highScore)
            {

                highScore=score;
                    GameObject.FindGameObjectWithTag("ButtonClick").GetComponent<JSONSaving>().CreatePlayerData();
                    GameObject.FindGameObjectWithTag("ButtonClick").GetComponent<JSONSaving>().SaveData();

                }
            if (highScore >= 50)
            {
                if (score > 50)
                {
                    if (score % 50 == 0)
                    {
                        lives++;
                    }
                }
            }
           
            scoresS = "Score " + score;
            scoret.text = scoresS;


            if (score % 2 == 0)
            {
                //rightCube.Stop();
                // forwardCube.Stop();
                reverseCube.Play();
                // leftCube.Stop();
            }
            else
            {
                //leftCube.Stop();

                forwardCube.Play();
                //reverseCube.Stop();
                //rightCube.Stop();
            }





            //Debug.Log(whichCube + "hangiküb");

            Destroy(cubeT[index]);
            cubeT.RemoveAt(index);


                //Debug.Log(index + "index" + destroyIndex + "destroyindex"+"score");


            }
        }
    }
    public void ScoreKeeper()
    {



        destroyDisty.Clear();

        //destroyDistx.Clear();

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
       // Debug.Log(minValyI + "yIup" + minValyIDown + "yIdown" + ("ded"));

        // minValx = Mathf.Abs(cubeT[index].transform.position.x - portal.position.x);

        //Debug.Log(minValyIDown + "minvalyýdown");

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


                    //ColorOf.isCubeGone = true;
                    
                    ChosePortal.changePortalCheck = true;
                    lives--;
                     ChosePortal.died = true;
                    healthS = "Lives " + "  " + lives;
                    health.text = healthS;

                    //rightCube.Stop();
                    //forwardCube.Stop();
                    //reverseCube.Stop();
                    leftCube.Play();
                    // Debug.Log(whichCube + "hangiküb");
                    Destroy(cubeT[index]);
                    cubeT.RemoveAt(index);
                    //Debug.Log(index + "index" + destroyIndex + "destroyindex"+"lives");



                }

            }

        

        //destroyDisty2.Clear();
       // destroyDistx2.Clear();
       
      
      



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

        //Debug.Log(sameCubeCounter + "same" + AdssameCubeCounter + "adssame");
        rondomSpawn = Random.Range(0, spawnPoints.Length);
        
        whichCube = samecube;
        cube = Instantiate(cubes[samecube], spawnPoints[rondomSpawn]);


        cubeT.Add(cube);

        cubeIsSpawned = true;

    }
}

