
using UnityEngine;
using System.Collections;

public class LeftMov : MonoBehaviour
{
    bool leftClick;
    bool rightClick;
    bool touchedOnce;
    int xne;
    bool lerping = false;
    Vector3 startMarker;
    Vector3 endMarker;
    private float speed = 30f;
    private float startTime;
    private float journeyLength;

    float fractionOfJourney;
    // Start is called before the first frame update

    public void checktouch()
    {
        
            if (Input.touchCount > 0)
            {
                var touch = Input.GetTouch(0);
                if (touch.position.x < Screen.width / 2)
                {
                    leftClick = true;
                    rightClick = false;
                }
                else if (touch.position.x > Screen.width / 2)
                {
                    rightClick = true;
                    leftClick = false;
                }
            }
            else
            {
                rightClick = false;
                leftClick = false;
                touchedOnce = false;
            }
        

    }
    IEnumerator Lerp()
    {
        while (fractionOfJourney < 0.98)
        {
            lerping = true;
            float distCovered = (Time.time - startTime) * speed;
            fractionOfJourney = distCovered / journeyLength;
            //Debug.Log(distCovered + "distancecovered");
            float transformX = Mathf.Lerp(startMarker.x, endMarker.x, fractionOfJourney);
            transform.position = new Vector3(transformX, transform.position.y, transform.position.z);
            //transform.position += new Vector3(0, (Spawner.thisWay * Time.deltaTime), 0);
            //Debug.Log(transform.position + "lerp position");
            //timeElapsed += Time.deltaTime;
            yield return null;


        }
        lerping = false;
        transform.position = new Vector3(endMarker.x, transform.position.y, transform.position.z);
        fractionOfJourney = 0;
        //lerping = false;

    }
    // Update is called once per frame
    void FixedUpdate()
    {
        
            transform.position += new Vector3(0, (Spawner.thisWay * Time.deltaTime), 0);
        
        checktouch();
        if (Input.touchCount > 0 && !touchedOnce && !PauseMenu.gameIsPaused)
        {
           

            
            if (Input.GetKeyDown("a") || Input.GetKeyDown("d") || leftClick || rightClick)
            {
                if (transform.position.x == 2.4f)
                {
                    xne = 1;
                    
                }
                else if (transform.position.x == 0)
                {
                    xne = 2;
                    
                }
                else if (transform.position.x == -2.4f)
                {
                    xne = 3;
                   
                }
               
                switch (xne)
                {
                    case 1:
                        //transform.position = new Vector3(0, transform.position.y, transform.position.z);
                        startTime = Time.time;
                        startMarker = transform.position;
                        endMarker = new Vector3(0, transform.position.y, transform.position.z);
                        journeyLength = Vector3.Distance(startMarker, endMarker);
                        StartCoroutine(Lerp());
                        break;
                    case 2:
                       // transform.position = new Vector3(-2.4f, transform.position.y, transform.position.z);
                        startTime = Time.time;
                        startMarker = transform.position;
                        endMarker = new Vector3(-2.4f, transform.position.y, transform.position.z);
                        journeyLength = Vector3.Distance(startMarker, endMarker);
                        StartCoroutine(Lerp());
                        break;
                    case 3:
                       // transform.position = new Vector3(2.4f, transform.position.y, transform.position.z);
                        startTime = Time.time;
                        startMarker = transform.position;
                        endMarker = new Vector3(2.4f, transform.position.y, transform.position.z);
                        journeyLength = Vector3.Distance(startMarker, endMarker);
                        StartCoroutine(Lerp());
                        break;

                }
            }

            touchedOnce = true;

        }
    }
}

