using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
//using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class Spawner : MonoBehaviour
{
    public GameObject[] cubes;
    public Transform[] spawnPoints;
    int rondomCube;
    int rondomSpawn;
    public static bool cubeisspawned = false;
    GameObject cube;
    //int howmanycubes;
    public static int thisway;
    //int stillthisway;
    //Transform cubeTz;
    List<GameObject> cubeT = new List<GameObject>();
    //Transform[] cubeT;
    //Vector2 dir;
    //int xne;
    public static int whichcube;
    public GameObject objectcheck;
    public static bool portalisdown;
    public TextMeshProUGUI health;
    public TextMeshProUGUI scoret;
    int lives = 3;
    int score = 0;
    int index;
    float distx;
    float disty;
    float spawnDistF;
    public Transform objectivecheck;
    public Transform portal;
    public Transform spawndist;
    bool canspawn = true;
    List<float> destroyDisty=new List<float>();
    List<float> destroyDistx = new List<float>();
    List<float> distforspawn = new List<float>();
    List<float> distforobjCheck = new List<float>();
    bool thiswaychanged = false;
    bool spawnedAnother = false;
    float minValy;
    float minValyI;
    float minValx;
    int destroyindex;
    //bool rightclick = false;
    //bool leftclick = false;
    //bool touchedonce = false;

    // Start is called before the first frame update

    void Awake()
    {
        lives = 3;
        disty = 5f;
        cube = Instantiate(cubes[0], spawnPoints[0]);
        cubeT.Add(cube);
        
        whichcube = 0;
        
        cubeisspawned = true;
        health.text = "Lives : " + lives;
        scoret.text = "Score : " + score;
    }
    private void Start()
    {
        lives = 3;
        disty = 5f;
    }
    //public void FindingIndex()
    //{
        
    //    if (!thiswaychanged)
    //    {
    //        if (!spawnedAnother)
    //        {
    //            index = 0;
    //        }
    //        else if (spawnedAnother)
    //        {
    //            index = 0;
    //        }
    //    }
    //    else if (thiswaychanged)
    //    {
    //        if (spawnedAnother)
    //        {
    //            index = cubeT.Count - 1;
    //        }
    //    }
    //}

    // Update is called once per frame
    void Update()
    {
        
        distx = Mathf.Abs(portal.position.x - objectivecheck.position.x);
        disty = Mathf.Abs(portal.position.y - objectivecheck.position.y);
        //spawnDistF = Mathf.Abs(objectcheck.transform.position.y - spawndist.position.y);
        //Debug.Log(disty + "disty"+spawnDistF+"spawndistf");
        //if (lives <= 0)
        //{
        for (int i = 0; i < cubeT.Count; i++)
        {
            distforspawn.Add(Mathf.Abs(cubeT[i].transform.position.y - spawndist.position.y));
            for (int z = 0; z < distforspawn.Count; z++)
            {
                if (distforspawn[z] > 2f)
                {
                    canspawn = true;
                }
                else
                {
                    distforspawn.Clear();
                    canspawn = false;
                    return;
                }
            }
            
        }

       
        //objectcheck.transform.position = cubeT[cubeT.Count - 2].transform.position;

        // distforobjCheck.Clear();  
        //float minVal = distforobjCheck.Min();
        //index = distforobjCheck.IndexOf(minVal);
        //objectcheck.transform.position = cubeT[index].transform.position;

        //    
        //}

        if (cubeT.Count<5 && canspawn)
        {
            Spawn();
        }

        ScoreKeeper();
        //switch (whichcube)
        //{
        //    case 0:
        //      //  moveCube();
        //        break;
        //    case 1:
        //        //moveCubeReverse();
        //        break;
        //    case 2:
        //       // moveCubeSaG();
        //        break;
        //    case 3:
        //       // moveCubeSol();
        //        break;
        //}

        if (Input.touchCount==2)
        {
            Time.timeScale = 0;
            //if (thisway > 0)
            //{
            //    Destroy(cubeT.First());
            //    cubeT.Remove(cubeT.First());
            //}
            //if (thisway < 0)
            //{
            //    Destroy(cubeT.Last());
            //    cubeT.Remove(cubeT.Last());
            //}
            //ColorOf.iscubegone = true;
            //ColorOfGround.iscubegoneground = true;
            //Spawn();
        }
        if (Input.touchCount>=3)
        {
            Time.timeScale = 1;
        }
        //if (thisway != stillthisway) {
        //for (int i = 0; i < cubeT.Count; i++)
        //{
        //    cubeT[i].position += new Vector3(0, thisway * Time.deltaTime, 0);
        //}
        //    stillthisway = thisway;
        //}

       
            
               
           
            
        
       
       

    }
    public void ScoreKeeper()
    {
        
        
            bool isEmpty = !destroyDisty.Any();
            if (isEmpty) {
                
            destroyDisty.Add(Mathf.Abs(cubeT[0].transform.position.y - portal.position.y));
            destroyDisty.Add(Mathf.Abs(cubeT[0].transform.position.y - portal.position.y));
            destroyDisty.Add(Mathf.Abs(cubeT[0].transform.position.y - portal.position.y));
            destroyDisty.Add(Mathf.Abs(cubeT[0].transform.position.y - portal.position.y));
            destroyDisty.Add(Mathf.Abs(cubeT[0].transform.position.y - portal.position.y));



            }
            else if(!isEmpty)
            {
            for (int i = 0; i < cubeT.Count; i++)
            {
                destroyDisty[i]= Mathf.Abs(cubeT[i].transform.position.y - portal.position.y);
            }
            }
            bool isEmptyx = !destroyDistx.Any();
            
            if (isEmptyx)
            {
            destroyDistx.Add(Mathf.Abs(cubeT[0].transform.position.x - portal.position.x));
            destroyDistx.Add(Mathf.Abs(cubeT[0].transform.position.x - portal.position.x));
            destroyDistx.Add(Mathf.Abs(cubeT[0].transform.position.x - portal.position.x));
            destroyDistx.Add(Mathf.Abs(cubeT[0].transform.position.x - portal.position.x));
            destroyDistx.Add(Mathf.Abs(cubeT[0].transform.position.x - portal.position.x));
          
            }
            else if (!isEmpty)
           {
            for (int a = 0; a < cubeT.Count; a++)
            {
               destroyDistx[a] = Mathf.Abs(cubeT[a].transform.position.x - portal.position.x);
            }
            }
            

        
        
              minValy = destroyDisty.Min();
              //minValx = destroyDistx.Min();
              

              index = destroyDisty.IndexOf(minValy);
        // destroyindex = index;

        minValx = Mathf.Abs (cubeT[index].transform.position.x - portal.position.x);
        minValyI = Mathf.Abs (cubeT[index].transform.position.y - portal.position.y);
        if (minValyI < 1.2f && minValx <= 0.1f)
            //burayý deðiþtir portalýn þekli deðiþirse
            {
                

                ColorOf.iscubegone = true;
                ColorOfGround.iscubegoneground = true;
                ChosePortal.portalisgone = true;
                score++;
                scoret.text = "Score : " + score;
                Destroy(cubeT[index]);
                cubeT.RemoveAt(index);
            Debug.Log(index + "index" + destroyindex + "destroyindex"+"score");



        }
        else if (minValyI < 0.5f)
            {
                if (lives == 1)
                {

                    //ColorOf.iscubegone = true;
                    //ColorOfGround.iscubegoneground = true;
                    //Spawn();
                    if (lives == 1)
                    {
                        lives--;
                    }
                    Time.timeScale = 0;
                    health.text = "Lives : " + lives;
                    SceneManager.LoadScene("GameOver");

                }
                else if (lives > 1)
                {


                    ColorOf.iscubegone = true;
                    ColorOfGround.iscubegoneground = true;
                ChosePortal.portalisgone = true;
                lives--;
                    health.text = "Lives : " + lives;
                    Destroy(cubeT[index]);
                    cubeT.RemoveAt(index);
                Debug.Log(index + "index" + destroyindex + "destroyindex"+"lives");



            }

            }


       
    }
    //public void checktouch()
    //{
    //    if (Input.touchCount > 0)
    //    {
    //        var touch = Input.GetTouch(0);
    //        if (touch.position.x < Screen.width / 2)
    //        {
    //            leftclick = true;
    //            rightclick = false;
    //        }
    //        else if (touch.position.x > Screen.width / 2)
    //        {
    //            rightclick = true;
    //            leftclick = false;
    //        }
    //    }
    //    else
    //    {
    //        rightclick = false;
    //        leftclick = false;
    //        touchedonce = false;
    //    }

    //}
    public void Spawn()
    {
        
        rondomSpawn = Random.Range(0, spawnPoints.Length);
        rondomCube = Random.Range(0, cubes.Length);
        whichcube = rondomCube;
        cube = Instantiate(cubes[rondomCube], spawnPoints[rondomSpawn]);


        cubeT.Add(cube);
        
        //if (!portalisdown)
        //{
        //    thisway = speed;
        //    Debug.Log(thisway + "bozidiz");
        //}
        //if(portalisdown)
        //{
        //    thisway = -speed;
        //    Debug.Log(thisway + "negadiz    ");
        //}

        //Debug.Log("spawnküb" + whichcube);


        cubeisspawned = true;

    }
    //public void moveCube()
    //{
    //    checktouch();
    //    if (Input.touchCount > 0 && !touchedonce)
    //    {
    //        touchedonce = true;
            
    //        //cubeT.position += new Vector3(0,thisway*Time.deltaTime,0);
    //        //Debug.Log(thisway+"x position "+ cubeT.position.x+"hangiküp"+whichcube);
    //        if (Input.GetKeyDown("a") || leftclick)
    //        {
    //            if (cubeT.position.x == 2.4f)
    //            {
    //                xne = 1;
    //                // cubeT.position = new Vector3(0, cubeT.position.y, cubeT.position.z);
    //            }
    //            if (cubeT.position.x == 0)
    //            {
    //                xne = 2;
    //                // cubeT.position = new Vector3(-2.4f, cubeT.position.y, cubeT.position.z);
    //            }
    //            if (cubeT.position.x == -2.4f)
    //            {
    //                xne = 3;
    //                // cubeT.position = new Vector3(2.4f, cubeT.position.y, cubeT.position.z);
    //            }
    //            //(2.4f, cubeT.position.y, cubeT.position.z);
    //            switch (xne)
    //            {
    //                case 1:
    //                    cubeT.position = new Vector3(0, cubeT.position.y, cubeT.position.z);
    //                    break;
    //                case 2:
    //                    cubeT.position = new Vector3(-2.4f, cubeT.position.y, cubeT.position.z);
    //                    break;
    //                case 3:
    //                    cubeT.position = new Vector3(2.4f, cubeT.position.y, cubeT.position.z);
    //                    break;

    //            }
    //        }
    //        if (Input.GetKeyDown("d") || rightclick)
    //        {
    //            if (cubeT.position.x == 2.4f)
    //            {
    //                xne = 1;
    //                // cubeT.position = new Vector3(0, cubeT.position.y, cubeT.position.z);
    //            }
    //            if (cubeT.position.x == 0)
    //            {
    //                xne = 2;
    //                // cubeT.position = new Vector3(-2.4f, cubeT.position.y, cubeT.position.z);
    //            }
    //            if (cubeT.position.x == -2.4f)
    //            {
    //                xne = 3;
    //                // cubeT.position = new Vector3(2.4f, cubeT.position.y, cubeT.position.z);
    //            }
    //            //(2.4f, cubeT.position.y, cubeT.position.z);
    //            switch (xne)
    //            {
    //                case 1:
    //                    cubeT.position = new Vector3(-2.4f, cubeT.position.y, cubeT.position.z);
    //                    break;
    //                case 2:
    //                    cubeT.position = new Vector3(2.4f, cubeT.position.y, cubeT.position.z);
    //                    break;
    //                case 3:
    //                    cubeT.position = new Vector3(0, cubeT.position.y, cubeT.position.z);
    //                    break;

    //            }
    //        }
    //        //leftclick = false;
    //        //rightclick = false;
            

    //    }
    //}
    //public void moveCubeReverse()
    //{
    //    checktouch();
    //    if (Input.touchCount > 0 && !touchedonce)
    //    {
    //        touchedonce = true;
         
    //        //cubeT.position += new Vector3(0, thisway * Time.deltaTime, 0);
    //        //Debug.Log(thisway + "x position " + cubeT.position.x);
    //        if (Input.GetKeyDown("a") || leftclick)
    //        {
    //            if (cubeT.position.x == 2.4f)
    //            {
    //                xne = 1;
    //                // cubeT.position = new Vector3(0, cubeT.position.y, cubeT.position.z);
    //            }
    //            if (cubeT.position.x == 0)
    //            {
    //                xne = 2;
    //                // cubeT.position = new Vector3(-2.4f, cubeT.position.y, cubeT.position.z);
    //            }
    //            if (cubeT.position.x == -2.4f)
    //            {
    //                xne = 3;
    //                // cubeT.position = new Vector3(2.4f, cubeT.position.y, cubeT.position.z);
    //            }
    //            //(2.4f, cubeT.position.y, cubeT.position.z);
    //            switch (xne)
    //            {
    //                case 1:
    //                    cubeT.position = new Vector3(-2.4f, cubeT.position.y, cubeT.position.z);
    //                    break;
    //                case 2:
    //                    cubeT.position = new Vector3(2.4f, cubeT.position.y, cubeT.position.z);
    //                    break;
    //                case 3:
    //                    cubeT.position = new Vector3(0, cubeT.position.y, cubeT.position.z);
    //                    break;

    //            }

    //        }
    //        if (Input.GetKeyDown("d") || rightclick)
    //        {
    //            if (cubeT.position.x == 2.4f)
    //            {
    //                xne = 1;
    //                // cubeT.position = new Vector3(0, cubeT.position.y, cubeT.position.z);
    //            }
    //            if (cubeT.position.x == 0)
    //            {
    //                xne = 2;
    //                // cubeT.position = new Vector3(-2.4f, cubeT.position.y, cubeT.position.z);
    //            }
    //            if (cubeT.position.x == -2.4f)
    //            {
    //                xne = 3;
    //                // cubeT.position = new Vector3(2.4f, cubeT.position.y, cubeT.position.z);
    //            }
    //            //(2.4f, cubeT.position.y, cubeT.position.z);
    //            switch (xne)
    //            {
    //                case 1:
    //                    cubeT.position = new Vector3(0, cubeT.position.y, cubeT.position.z);
    //                    break;
    //                case 2:
    //                    cubeT.position = new Vector3(-2.4f, cubeT.position.y, cubeT.position.z);
    //                    break;
    //                case 3:
    //                    cubeT.position = new Vector3(2.4f, cubeT.position.y, cubeT.position.z);
    //                    break;

    //            }
    //        }
    //        //leftclick = false;
    //        //rightclick = false;
            


    //    }
    //}
    //public void moveCubeSaG()
    //{
    //    checktouch();
    //    if (Input.touchCount > 0 && !touchedonce)
    //    {
    //        touchedonce = true;
            
    //        //cubeT.position += new Vector3(0, thisway * Time.deltaTime, 0);
    //        //Debug.Log(thisway + "x position " + cubeT.position.x);
    //        if (Input.GetKeyDown("a") || Input.GetKeyDown("d") || leftclick || rightclick)
    //        {
    //            if (cubeT.position.x == 2.4f)
    //            {
    //                xne = 1;
    //                // cubeT.position = new Vector3(0, cubeT.position.y, cubeT.position.z);
    //            }
    //            if (cubeT.position.x == 0)
    //            {
    //                xne = 2;
    //                // cubeT.position = new Vector3(-2.4f, cubeT.position.y, cubeT.position.z);
    //            }
    //            if (cubeT.position.x == -2.4f)
    //            {
    //                xne = 3;
    //                // cubeT.position = new Vector3(2.4f, cubeT.position.y, cubeT.position.z);
    //            }
    //            //(2.4f, cubeT.position.y, cubeT.position.z);
    //            switch (xne)
    //            {
    //                case 1:
    //                    cubeT.position = new Vector3(-2.4f, cubeT.position.y, cubeT.position.z);
    //                    break;
    //                case 2:
    //                    cubeT.position = new Vector3(2.4f, cubeT.position.y, cubeT.position.z);
    //                    break;
    //                case 3:
    //                    cubeT.position = new Vector3(0, cubeT.position.y, cubeT.position.z);
    //                    break;

    //            }
    //        }
    //        //leftclick = false;
    //        //rightclick = false;
            


    //    }
    //}
    //public void moveCubeSol()
    //{
    //    checktouch();
    //    if (Input.touchCount > 0 && !touchedonce)
    //    {
    //        touchedonce = true;
            
    //        //cubeT.position += new Vector3(0, thisway * Time.deltaTime, 0);
    //        //Debug.Log(thisway + "x position " + cubeT.position.x);
    //        if (Input.GetKeyDown("a") || Input.GetKeyDown("d") || leftclick || rightclick)
    //        {
    //            if (cubeT.position.x == 2.4f)
    //            {
    //                xne = 1;
    //                // cubeT.position = new Vector3(0, cubeT.position.y, cubeT.position.z);
    //            }
    //            if (cubeT.position.x == 0)
    //            {
    //                xne = 2;
    //                // cubeT.position = new Vector3(-2.4f, cubeT.position.y, cubeT.position.z);
    //            }
    //            if (cubeT.position.x == -2.4f)
    //            {
    //                xne = 3;
    //                // cubeT.position = new Vector3(2.4f, cubeT.position.y, cubeT.position.z);
    //            }
    //            //(2.4f, cubeT.position.y, cubeT.position.z);
    //            switch (xne)
    //            {
    //                case 1:
    //                    cubeT.position = new Vector3(0, cubeT.position.y, cubeT.position.z);
    //                    break;
    //                case 2:
    //                    cubeT.position = new Vector3(-2.4f, cubeT.position.y, cubeT.position.z);
    //                    break;
    //                case 3:
    //                    cubeT.position = new Vector3(2.4f, cubeT.position.y, cubeT.position.z);
    //                    break;

    //            }
    //        }
    //        //leftclick = false;
    //        //rightclick = false;
            

    //    }
    //}
}

