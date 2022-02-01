using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
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
    
    public static int thisway;
    Transform cubeT;
    Vector2 dir;
    int xne;
    public static int whichcube;
    public GameObject objectcheck;
    public static bool portalisdown;
    public TextMeshProUGUI health;
    public TextMeshProUGUI scoret;
    int lives = 3;
    int score = 0;
    // Start is called before the first frame update
    
    void Start()
    {
        Spawn();
        health.text = "Lives : " + lives;
        scoret.text = "Score : " + score;
    }

    // Update is called once per frame
    void Update()
    {

        if (lives <= 0)
        {
            SceneManager.LoadScene("GameOver");
        }
        
        if (!cubeisspawned)
        {
            Spawn();
        }
       
        switch (whichcube)
        {
            case 0:
                moveCube();
                break;
            case 1:
                moveCubeReverse();
                break;
            case 2:
                moveCubeSaG();
                break;
            case 3:
                moveCubeSol();
                break;
        }
        if (TriggerCheck.disty < 0.5)
        {
            Destroy(cube);
            ColorOf.iscubegone = true;
            ColorOfGround.iscubegoneground = true;
            Spawn();
            lives--;
            health.text = "Lives : " + lives;
            
        }
        else if(TriggerCheck.disty <1.2 && TriggerCheck.distx == 0)
            //burayý deðiþtir portalýn þekli deðiþirse
        {
            Destroy(cube);
            ColorOf.iscubegone = true;
            ColorOfGround.iscubegoneground = true;
            Spawn();
            score++;
            scoret.text = "Score : " + score;
        }
            if (Input.GetKeyDown("l"))
        {
            Destroy(cube);
            ColorOf.iscubegone = true;
            ColorOfGround.iscubegoneground = true;
            Spawn();
        }
        objectcheck.transform.position = cube.transform.position;
        
    }


    public void Spawn()
    {
        ChosePortal.portalisgone = true;
        rondomSpawn = Random.Range(0, spawnPoints.Length);
        rondomCube = Random.Range(0, cubes.Length);
        whichcube = rondomCube;
        cube = Instantiate(cubes[rondomCube], spawnPoints[rondomSpawn]);
        
        
        cubeT = cube.transform;
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
       
        Debug.Log("spawnküb" + whichcube);

        cubeisspawned = true;
        
    }
    public void moveCube()
    {

        cubeT.position += new Vector3(0,thisway*Time.deltaTime,0);
        //Debug.Log(thisway+"x position "+ cubeT.position.x+"hangiküp"+whichcube);
        if (Input.GetKeyDown("a")) { 
         if (cubeT.position.x == 2.4f )
         {
                xne = 1;
            // cubeT.position = new Vector3(0, cubeT.position.y, cubeT.position.z);
        }
        if (cubeT.position.x == 0)
         {
                xne = 2;
            // cubeT.position = new Vector3(-2.4f, cubeT.position.y, cubeT.position.z);
        }
        if (cubeT.position.x == -2.4f )
         {
                xne = 3;
            // cubeT.position = new Vector3(2.4f, cubeT.position.y, cubeT.position.z);
         }
            //(2.4f, cubeT.position.y, cubeT.position.z);
            switch (xne)
            {
                case 1:
                    cubeT.position = new Vector3(0, cubeT.position.y, cubeT.position.z);
                    break;
                case 2:
                    cubeT.position = new Vector3(-2.4f, cubeT.position.y, cubeT.position.z);
                    break;
                case 3:
                    cubeT.position = new Vector3(2.4f, cubeT.position.y, cubeT.position.z);
                    break;

            }
        }
        if (Input.GetKeyDown("d"))
        {
            if (cubeT.position.x == 2.4f)
            {
                xne = 1;
                // cubeT.position = new Vector3(0, cubeT.position.y, cubeT.position.z);
            }
            if (cubeT.position.x == 0)
            {
                xne = 2;
                // cubeT.position = new Vector3(-2.4f, cubeT.position.y, cubeT.position.z);
            }
            if (cubeT.position.x == -2.4f)
            {
                xne = 3;
                // cubeT.position = new Vector3(2.4f, cubeT.position.y, cubeT.position.z);
            }
            //(2.4f, cubeT.position.y, cubeT.position.z);
            switch (xne)
            {
                case 1:
                    cubeT.position = new Vector3(-2.4f, cubeT.position.y, cubeT.position.z);
                    break;
                case 2:
                    cubeT.position = new Vector3(2.4f, cubeT.position.y, cubeT.position.z);
                    break;
                case 3:
                    cubeT.position = new Vector3(0, cubeT.position.y, cubeT.position.z);
                    break;

            }
        }



    }
    public void moveCubeReverse()
    {

        cubeT.position += new Vector3(0, thisway * Time.deltaTime, 0);
        //Debug.Log(thisway + "x position " + cubeT.position.x);
        if (Input.GetKeyDown("a"))
        {
            if (cubeT.position.x == 2.4f)
            {
                xne = 1;
                // cubeT.position = new Vector3(0, cubeT.position.y, cubeT.position.z);
            }
            if (cubeT.position.x == 0)
            {
                xne = 2;
                // cubeT.position = new Vector3(-2.4f, cubeT.position.y, cubeT.position.z);
            }
            if (cubeT.position.x == -2.4f)
            {
                xne = 3;
                // cubeT.position = new Vector3(2.4f, cubeT.position.y, cubeT.position.z);
            }
            //(2.4f, cubeT.position.y, cubeT.position.z);
            switch (xne)
            {
                case 1:
                    cubeT.position = new Vector3(-2.4f, cubeT.position.y, cubeT.position.z);
                    break;
                case 2:
                    cubeT.position = new Vector3(2.4f, cubeT.position.y, cubeT.position.z);
                    break;
                case 3:
                    cubeT.position = new Vector3(0, cubeT.position.y, cubeT.position.z);
                    break;

            }
        }
        if (Input.GetKeyDown("d"))
        {
            if (cubeT.position.x == 2.4f)
            {
                xne = 1;
                // cubeT.position = new Vector3(0, cubeT.position.y, cubeT.position.z);
            }
            if (cubeT.position.x == 0)
            {
                xne = 2;
                // cubeT.position = new Vector3(-2.4f, cubeT.position.y, cubeT.position.z);
            }
            if (cubeT.position.x == -2.4f)
            {
                xne = 3;
                // cubeT.position = new Vector3(2.4f, cubeT.position.y, cubeT.position.z);
            }
            //(2.4f, cubeT.position.y, cubeT.position.z);
            switch (xne)
            {
                case 1:
                    cubeT.position = new Vector3(0, cubeT.position.y, cubeT.position.z);
                    break;
                case 2:
                    cubeT.position = new Vector3(-2.4f, cubeT.position.y, cubeT.position.z);
                    break;
                case 3:
                    cubeT.position = new Vector3(2.4f, cubeT.position.y, cubeT.position.z);
                    break;

            }
        }



    }
    public void moveCubeSaG()
    {

        cubeT.position += new Vector3(0, thisway * Time.deltaTime, 0);
        //Debug.Log(thisway + "x position " + cubeT.position.x);
        if (Input.GetKeyDown("a") || Input.GetKeyDown("d"))
        {
            if (cubeT.position.x == 2.4f)
            {
                xne = 1;
                // cubeT.position = new Vector3(0, cubeT.position.y, cubeT.position.z);
            }
            if (cubeT.position.x == 0)
            {
                xne = 2;
                // cubeT.position = new Vector3(-2.4f, cubeT.position.y, cubeT.position.z);
            }
            if (cubeT.position.x == -2.4f)
            {
                xne = 3;
                // cubeT.position = new Vector3(2.4f, cubeT.position.y, cubeT.position.z);
            }
            //(2.4f, cubeT.position.y, cubeT.position.z);
            switch (xne)
            {
                case 1:
                    cubeT.position = new Vector3(-2.4f, cubeT.position.y, cubeT.position.z);
                    break;
                case 2:
                    cubeT.position = new Vector3(2.4f, cubeT.position.y, cubeT.position.z);
                    break;
                case 3:
                    cubeT.position = new Vector3(0, cubeT.position.y, cubeT.position.z);
                    break;

            }
        }
      


    }
    public void moveCubeSol()
    {

        cubeT.position += new Vector3(0, thisway * Time.deltaTime, 0);
        //Debug.Log(thisway + "x position " + cubeT.position.x);
        if (Input.GetKeyDown("a")|| Input.GetKeyDown("d"))
        {
            if (cubeT.position.x == 2.4f)
            {
                xne = 1;
                // cubeT.position = new Vector3(0, cubeT.position.y, cubeT.position.z);
            }
            if (cubeT.position.x == 0)
            {
                xne = 2;
                // cubeT.position = new Vector3(-2.4f, cubeT.position.y, cubeT.position.z);
            }
            if (cubeT.position.x == -2.4f)
            {
                xne = 3;
                // cubeT.position = new Vector3(2.4f, cubeT.position.y, cubeT.position.z);
            }
            //(2.4f, cubeT.position.y, cubeT.position.z);
            switch (xne)
            {
                case 1:
                    cubeT.position = new Vector3(0, cubeT.position.y, cubeT.position.z);
                    break;
                case 2:
                    cubeT.position = new Vector3(-2.4f, cubeT.position.y, cubeT.position.z);
                    break;
                case 3:
                    cubeT.position = new Vector3(2.4f, cubeT.position.y, cubeT.position.z);
                    break;

            }
        }
      


    }
}

