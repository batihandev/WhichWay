using UnityEngine;
using TMPro;




public class Score : MonoBehaviour
{
    public TextMeshProUGUI score;
    public TextMeshProUGUI highScore;
     int _highScore;
    int gameoverScore;
    //int firstScore = 0;
    // Start is called before the first frame update
   
    void Start()
    {

        
        _highScore = PlayerPrefs.GetInt("highScore");
        //gameOverHighScore = PlayerPrefs.GetInt("gameOverScore");

        gameoverScore = Spawner.score;
        PlayerPrefs.SetInt("gameOverScore", gameoverScore);
            
           

        
          
            
         

         
        
       
        score.text = "Score : " + Spawner.score;
        
        highScore.text = "High Score : " + _highScore;
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
