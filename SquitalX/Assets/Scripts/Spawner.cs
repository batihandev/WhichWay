using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject[] cubes;
    public Transform[] spawnPoints;
    int rondomCube;
    int rondomSpawn;
    public static bool cubeisspawned = false;
    GameObject cube;
    int speed = 5;
    int thisway;
    Transform cubeT;
    Vector2 dir;
    int xne;
    public static int whichcube;
    // Start is called before the first frame update
    
    void Start()
    {
        Spawn();
        //testc;
    }

    // Update is called once per frame
    void Update()
    {
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
        
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Portal")
        {
            Destroy(cube);

        }
    }

    public void Spawn()
    {
        rondomSpawn = Random.Range(0, spawnPoints.Length);
        rondomCube = Random.Range(0, cubes.Length);
        whichcube = rondomCube;
        cube = Instantiate(cubes[rondomCube], spawnPoints[rondomSpawn]);
        
        
        cubeT = cube.transform;
        if (ChosePortal.portalisdown)
        {
            thisway = speed;
        }
        else
        {
            thisway = -speed;
        }
       
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

