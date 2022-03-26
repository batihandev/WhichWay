using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerData 
{
    public string name;
    public int highScore;
    
    //public int removeAds;
    
    public int FirstTime;
    public int StarClickCount;
    public int steps;
    public bool achievements1;
    public bool achievements2;
    public bool achievements3;
    public bool achievements4;
    public bool achievements5;
    public bool achievements6;
    public bool achievements7;
    public bool achievements8;
    public float volume;
    public int indexQ;
    public int endGameStarCount;
    public string Test;
    public int pleasedontmodify;

    public PlayerData(string name, int highScore, /* int removeAds,*/  int FirstTime, int starClickCount, int steps, bool achievements1, bool achievements2,
        bool achievements3, bool achievements4, bool achievements5, bool achievements6, bool achievements7, bool achievements8, float volume,int indexQ,int endGameStarCount,string Test,int pleasedontmodify)
    {
        this.name = name;
        this.highScore = highScore;
        
       // this.removeAds = removeAds;
        
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
        this.Test = Test;
        this.pleasedontmodify = pleasedontmodify;

        
}
    
}
