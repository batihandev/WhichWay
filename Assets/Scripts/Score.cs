using UnityEngine;
using TMPro;




public class Score : MonoBehaviour
{
    public TextMeshProUGUI score;
    public TextMeshProUGUI highScore;
     int _highScore;
    public static int gameoverScore;
    
    public static int endgameStarScore;
    public static int steps;
    //int firstScore = 0;
    // Start is called before the first frame update
   
    void Start()
    {
       

        
        
       
        steps = OnClick.starClickCount - endgameStarScore;        
        GameObject.FindGameObjectWithTag("ButtonClick").GetComponent<GPSmanager>().DoIncrementalAchievement(steps);
        
        endgameStarScore = OnClick.starClickCount;
        //gameOverHighScore = PlayerPrefs.GetInt("gameOverScore");

        gameoverScore = Spawner.score;
        
        
           

        
          
            
         

         
        
       
        score.text = "SCORE : " + Spawner.score;
        
        highScore.text = "HIGHSCORE : " + Spawner.highScore;
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
