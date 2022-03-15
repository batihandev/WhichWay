using System.Collections;
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
    List<float> destroyDisty2 = new List<float>();
    List<float> destroyDistx = new List<float>();
    List<float> destroyDistx2 = new List<float>();
    List<float> distForSpawn = new List<float>();
    string healthS;
    string scoresS;

    float minValy;
    float minValyI;
        float minValyIDown;
    float minValx;
    float minValy2;
    float minValyI2;
    float minValx2;
    int index2;
    int destroyIndex;
    public AudioSource forwardCube;
    public AudioSource reverseCube;
    public AudioSource leftCube;
    public AudioSource rightCube;
    public static bool starSameCubeSpawn= false;
    int sameCubeCounter = 5;
    public static bool addsWatchedForCube = false;
    int samecube;


    void Awake()
    {
        lives = 50;
        score = 0;
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

    }

    void Update()
    {

        if (addsWatchedForCube)
        {
            sameCubeCounter = 10;
            addsWatchedForCube = false;
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
            if (!starSameCubeSpawn && !cubeIsSpawned)
            {
                Spawn();
            }
            if (starSameCubeSpawn && !cubeIsSpawned)
            {

               
                SameCubeSpawn();
                if (sameCubeCounter == 0)
                {
                    starSameCubeSpawn = false;
                    sameCubeCounter = 5;
                    
                }
            }
            
            
        }











    }
    public void ScoreCounter()
    {
        if (ScoreCatcher.scoreCatch == true)
        //burayý deðiþtir portalýn þekli deðiþirse
        {
            ScoreCatcher.scoreCatch = false;

            //Debug.Log((ChosePortal.portalS[0] == null) + "0" + (ChosePortal.portalS[1] == null) + "1" + minValyI2 + "yý2" + minValyI + "yý");
            ColorOf.isCubeGone = true;
            ColorOfGround.ýsCubeGoneGround = true;
            ChosePortal.changePortalCheck = true;
            score++;
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
        minValyI = Mathf.Abs(cubeT[index].transform.position.y - 7);
        minValyIDown = Mathf.Abs(cubeT[index].transform.position.y - (-7));

        // minValx = Mathf.Abs(cubeT[index].transform.position.x - portal.position.x);

        //Debug.Log(minValyIDown + "minvalyýdown");
       
        if (minValyI < 0.1f ||minValyIDown<0.1f)
            {
                if (lives == 0)
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
                else if (lives > 0)
                {


                    ColorOf.isCubeGone = true;
                    ColorOfGround.ýsCubeGoneGround = true;
                    ChosePortal.changePortalCheck = true;
                    lives--;
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
        if(sameCubeCounter==5 && !addsWatchedForCube)
        {
            samecube= Random.Range(0, cubes.Length);

        }
        if (sameCubeCounter == 10 && addsWatchedForCube)
        {
            samecube = Random.Range(0, cubes.Length);

        }
        sameCubeCounter--;
        rondomSpawn = Random.Range(0, spawnPoints.Length);
        
        whichCube = rondomCube;
        cube = Instantiate(cubes[samecube], spawnPoints[rondomSpawn]);


        cubeT.Add(cube);

        cubeIsSpawned = true;

    }
}

