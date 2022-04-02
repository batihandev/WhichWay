using UnityEngine;
using TMPro;




public class Score : MonoBehaviour
{
    public TextMeshProUGUI score;
    public TextMeshProUGUI highScore;
   
    public static int gameoverScore;
    
    public static int endgameStarScore;
    public static int steps;
 
   
    void Start()
    {
       

        
        
       
        steps = OnClick.starClickCount - endgameStarScore;        
        GameObject.FindGameObjectWithTag("ButtonClick").GetComponent<GPSmanager>().DoIncrementalAchievement(steps);
        
        endgameStarScore = OnClick.starClickCount;
       

        gameoverScore = Spawner.score;
        
        
           

        
          
            
         

         
        
       
        score.text = "SCORE : " + Spawner.score;
        
        highScore.text = "HIGHSCORE : " + Spawner.highScore;
        
    }

    
   
}
