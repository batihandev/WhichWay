using UnityEngine;
using TMPro;



public class Score : MonoBehaviour
{
    public TextMeshProUGUI score;
    public TextMeshProUGUI highScore;
    int _highScore;
    //int firstScore = 0;
    // Start is called before the first frame update
   
    void Start()
    {

        
        _highScore = PlayerPrefs.GetInt("highScore");
        //firstScore = _highScore;
        if (_highScore < Spawner.score)
        {
            PlayerPrefs.SetInt("highScore", Spawner.score);
        }
        score.text = "Score : " + Spawner.score;
        _highScore = PlayerPrefs.GetInt("highScore");
        highScore.text = "High Score : " + _highScore;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
