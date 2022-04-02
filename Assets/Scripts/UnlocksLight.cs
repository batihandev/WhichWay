
using UnityEngine;

public class UnlocksLight : MonoBehaviour
{

    public GameObject twentyFive;
    public GameObject fifty;
    public GameObject oneHundred;
    public GameObject twoHundred;
    public GameObject twentyFiveX;
    public GameObject fiftyX;
    public GameObject oneHundredX;
    public GameObject twoHundredX;
    int highScore;
    
    void Start()

    { 
        
        highScore = Spawner.highScore;
        twentyFive.SetActive(false);
        fifty.SetActive(false);
        oneHundred.SetActive(false);
        twoHundred.SetActive(false);
        twentyFiveX.SetActive(true);
        fiftyX.SetActive(true);
        oneHundredX.SetActive(true);
        twoHundredX.SetActive(true);
        if (highScore>25)
        {
            twentyFive.SetActive(true);
            twentyFiveX.SetActive(false);
            if (highScore >= 50)
            {
                fifty.SetActive(true);
                fiftyX.SetActive(false);
                if (highScore >= 100)
                {
                    oneHundred.SetActive(true);
                    oneHundredX.SetActive(false);
                    if (highScore >= 200)
                    {
                        twoHundred.SetActive(true);
                        twoHundredX.SetActive(false);

                    }

                }

            }

        }
    }

    
}
