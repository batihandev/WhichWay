using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReverseMovement : MonoBehaviour
{
    bool leftclick;
    bool rightclick;
    bool touchedonce;
    int xne;
    // Start is called before the first frame update
    void Start()
    {

    }
    public void checktouch()
    {
        if (Input.touchCount > 0)
        {
            var touch = Input.GetTouch(0);
            if (touch.position.x < Screen.width / 2)
            {
                leftclick = true;
                rightclick = false;
            }
            else if (touch.position.x > Screen.width / 2)
            {
                rightclick = true;
                leftclick = false;
            }
        }
        else
        {
            rightclick = false;
            leftclick = false;
            touchedonce = false;
        }

    }

    // Update is called once per frame
    void Update()
    {
        checktouch();
        if (Input.touchCount > 0 && !touchedonce)
        {
            touchedonce = true;

            //cubeT.position += new Vector3(0,thisway*Time.deltaTime,0);
            //Debug.Log(thisway+"x position "+ cubeT.position.x+"hangiküp"+whichcube);
            if (Input.GetKeyDown("d") || rightclick)
            {
                if (transform.position.x == 2.4f)
                {
                    xne = 1;
                    // cubeT.position = new Vector3(0, cubeT.position.y, cubeT.position.z);
                }
                if (transform.position.x == 0)
                {
                    xne = 2;
                    // cubeT.position = new Vector3(-2.4f, cubeT.position.y, cubeT.position.z);
                }
                if (transform.position.x == -2.4f)
                {
                    xne = 3;
                    // cubeT.position = new Vector3(2.4f, cubeT.position.y, cubeT.position.z);
                }
                //(2.4f, cubeT.position.y, cubeT.position.z);
                switch (xne)
                {
                    case 1:
                        transform.position = new Vector3(0, transform.position.y, transform.position.z);
                        break;
                    case 2:
                        transform.position = new Vector3(-2.4f, transform.position.y, transform.position.z);
                        break;
                    case 3:
                        transform.position = new Vector3(2.4f, transform.position.y, transform.position.z);
                        break;

                }
            }
            if (Input.GetKeyDown("a") || leftclick)
            {
                if (transform.position.x == 2.4f)
                {
                    xne = 1;
                    // cubeT.position = new Vector3(0, cubeT.position.y, cubeT.position.z);
                }
                if (transform.position.x == 0)
                {
                    xne = 2;
                    // cubeT.position = new Vector3(-2.4f, cubeT.position.y, cubeT.position.z);
                }
                if (transform.position.x == -2.4f)
                {
                    xne = 3;
                    // cubeT.position = new Vector3(2.4f, cubeT.position.y, cubeT.position.z);
                }
                //(2.4f, cubeT.position.y, cubeT.position.z);
                switch (xne)
                {
                    case 1:
                        transform.position = new Vector3(-2.4f, transform.position.y, transform.position.z);
                        break;
                    case 2:
                        transform.position = new Vector3(2.4f, transform.position.y, transform.position.z);
                        break;
                    case 3:
                        transform.position = new Vector3(0, transform.position.y, transform.position.z);
                        break;

                }
            }
            //leftclick = false;
            //rightclick = false;


        }
    }
}
