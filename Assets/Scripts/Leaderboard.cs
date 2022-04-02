using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using GooglePlayGames;
using GooglePlayGames.BasicApi;
using UnityEngine.SocialPlatforms;


public class Leaderboard : MonoBehaviour
{
    int score = 0;
    public GameObject panel;
    public void ShowLeaderBoardUI()
    {
        if (PlayerPrefs.GetInt("SignedOut", 0) == 1)
        {
            GameObject.FindGameObjectWithTag("ButtonClick").GetComponent<GPSmanager>().panelActive();
            panel.SetActive(false);
            
        }
        else { Social.ShowLeaderboardUI(); }
        
    }
    public void DoLeaderboardPost()
    {
        
        score = Spawner.highScore;
        Social.ReportScore(score,GPGSIds.leaderboard_leaderboard,(bool success) =>
        {
            if (success)
            {
                //Debug.Log("score posted");
                ShowLeaderBoardUI();

            }
            else
            {
                //Debug.Log("score post failed");
                ShowLeaderBoardUI();
            }
        });
    }
}
