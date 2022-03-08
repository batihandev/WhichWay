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
    int lives = 999;
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


    void Awake()
    {
        lives = 999;
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




        ScoreKeeper();
        for (int i = 0; i < cubeT.Count; i++)
        {
            distForSpawn.Add(Mathf.Abs(cubeT[i].transform.position.y - spawnDist.position.y));
            for (int z = 0; z < distForSpawn.Count; z++)
            {
                if (distForSpawn[z] > 2f)
                {
                    canspawn = true;
                }
                else
                {
                    distForSpawn.Clear();
                    canspawn = false;
                    return;
                }
            }

        }

        if (cubeT.Count < 6 && canspawn)
        {
            Spawn();
        }











    }
    public void ScoreKeeper()
    {


        
        destroyDisty.Clear();
        destroyDistx.Clear();
       
            for (int i = 0; i < cubeT.Count; i++)
            {
                destroyDisty.Add(Mathf.Abs(cubeT[0].transform.position.y - portal.position.y));
                destroyDistx.Add(Mathf.Abs(cubeT[0].transform.position.x - portal.position.x));
                destroyDisty[i] = Mathf.Abs(cubeT[i].transform.position.y - portal.position.y);
                destroyDistx[i] = Mathf.Abs(cubeT[i].transform.position.x - portal.position.x);
            }
            minValy = destroyDisty.Min();
            index = destroyDisty.IndexOf(minValy);
            minValx = Mathf.Abs(cubeT[index].transform.position.x - portal.position.x);
            minValyI = Mathf.Abs(cubeT[index].transform.position.y - portal.position.y);
            if (ScoreCatcher.scoreCatch==true)
            //burayý deðiþtir portalýn þekli deðiþirse
            {

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
            ScoreCatcher.scoreCatch = false;

                //Debug.Log(index + "index" + destroyIndex + "destroyindex"+"score");



            }
            else if (minValyI < 0.2f)
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
}

