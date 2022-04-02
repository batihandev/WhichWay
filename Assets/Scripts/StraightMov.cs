
using UnityEngine;

public class StraightMov : MonoBehaviour
{
    bool leftClick;
    bool rightClick;
    bool touchedOnce;
    int xne;
    
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

    
    void Update()
    {
        transform.position += new Vector3(0, Spawner.thisWay * Time.deltaTime, 0);
        checktouch();
        if (Input.touchCount > 0 && !touchedOnce && !PauseMenu.gameIsPaused)
        {
            

            if (Input.GetKeyDown("a") || leftClick)
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
            if (Input.GetKeyDown("d") || rightClick)
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


            touchedOnce = true;
        }
    }

}

