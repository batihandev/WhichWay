using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerData 
{
    public string name;
    public int highScore;
    public int gameOverScore;
    //public int removeAds;
    public int GameEnds;
    public int FirstTime;
    public int StarClickCount;
    public int steps;
    public int achievements1;
    public int achievements2;
    public int achievements3;
    public int achievements4;
    public int achievements5;
    public int achievements6;
    public int achievements7;
    public int achievements8;
    public float volume;
    public int indexQ;
    public int endGameStarCount;

    public PlayerData(string name, int highScore, int gameOverScore,/* int removeAds,*/ int GameEnds, int FirstTime, int starClickCount, int steps, int achievements1, int achievements2,
        int achievements3, int achievements4, int achievements5, int achievements6, int achievements7, int achievements8, float volume,int indexQ,int endGameStarCount)
    {
        this.name = name;
        this.highScore = highScore;
        this.gameOverScore = gameOverScore;
       // this.removeAds = removeAds;
        this.GameEnds = GameEnds;
        this.FirstTime = FirstTime;
        this.StarClickCount = starClickCount;
        this.steps = steps;
        this.achievements1 = achievements1;
        this.achievements2 = achievements2;
        this.achievements3 = achievements3;
        this.achievements4 = achievements4;
        this.achievements5 = achievements5;
        this.achievements6 = achievements6;
        this.achievements7 = achievements7;
        this.achievements8 = achievements8;
        this.volume = volume;
        this.indexQ = indexQ;
        this.endGameStarCount = endGameStarCount;

        
}
    
}
