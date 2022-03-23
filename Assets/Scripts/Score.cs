using UnityEngine;
using TMPro;




public class Score : MonoBehaviour
{
    public TextMeshProUGUI score;
    public TextMeshProUGUI highScore;
     int _highScore;
    int gameoverScore;
    int starClickCount;
    int endgameStarScore;
    int steps;
    //int firstScore = 0;
    // Start is called before the first frame update
   
    void Start()
    {
       

        _highScore = PlayerPrefs.GetInt("highScore");
        starClickCount = PlayerPrefs.GetInt("starClickCount", 0);
        endgameStarScore = PlayerPrefs.GetInt("endGameStarCount", 0);
        steps = starClickCount - endgameStarScore;        
        GameObject.FindGameObjectWithTag("ButtonClick").GetComponent<GPSmanager>().DoIncrementalAchievement(steps);
        PlayerPrefs.SetInt("steps", steps);
        PlayerPrefs.SetInt("endGameStarCount",starClickCount);
        //gameOverHighScore = PlayerPrefs.GetInt("gameOverScore");

        gameoverScore = Spawner.score;
        PlayerPrefs.SetInt("gameOverScore", gameoverScore);
        
           

        
          
            
         

         
        
       
        score.text = "SCORE : " + Spawner.score;
        
        highScore.text = "HIGHSCORE : " + _highScore;
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
