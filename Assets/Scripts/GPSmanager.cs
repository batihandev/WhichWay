using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using GooglePlayGames;
using GooglePlayGames.BasicApi;
using UnityEngine.SocialPlatforms;

public class GPSmanager : MonoBehaviour
{
    private PlayGamesClientConfiguration clientConfiguration;
    public Text statusTxt;
    public Text descriptionTxt;
    public GameObject signinButton;
    public GameObject signoutButton;
    public GameObject gugulPlayPanel;
    public static bool achievements1 = false;
    public static bool achievements2 = false;
    public static bool achievements3 = false;
    public static bool achievements4 = false;
    public static bool achievements5 = false;
    public static bool achievements6 = false;
    public static bool achievements7 = false;
    public static bool achievements8 = false;
    
    int highScore = 0;
    int starClickCount = 0;
    
    
    int gameOverScore = 0;
    

    public bool isLogedIn;

    internal void ConfigureGPGS()
    {
        clientConfiguration = new PlayGamesClientConfiguration.Builder().Build();
    }
    
    private void Start()
    {
        highScore = Spawner.highScore;
        gameOverScore = Score.gameoverScore;
        starClickCount = OnClick.starClickCount;
        ConfigureGPGS();
        SingIntoGPS(SignInInteractivity.CanPromptOnce, clientConfiguration);
      
    }
    private void Update()
    {
        highScore = Spawner.highScore;
        starClickCount = OnClick.starClickCount;
        

        if (highScore >= 229 && !achievements1)
            {
            
            Social.ReportProgress(GPGSIds.achievement_skykinghardworking, 100.00f, (bool success) =>
            {
                achievements1 = true;
                OnClick.starClickCount++;
                GameObject.FindGameObjectWithTag("ButtonClick").GetComponent<JSONSaving>().CreatePlayerData();
                GameObject.FindGameObjectWithTag("ButtonClick").GetComponent<JSONSaving>().SaveData();
                if (success)
                    {
                       


                    }
                    else
                    {
                        
                    }

                });
            }
            if (highScore >= 200&&!achievements2)
            {
            achievements2 = true;
            OnClick.starClickCount++;
            GameObject.FindGameObjectWithTag("ButtonClick").GetComponent<JSONSaving>().CreatePlayerData();
            GameObject.FindGameObjectWithTag("ButtonClick").GetComponent<JSONSaving>().SaveData();

            Social.ReportProgress(GPGSIds.achievement_reach_200_score, 100.00f, (bool success) =>
                {
                    if (success)
                    {
                        

                    }
                    else
                    {
                        
                    }

                });
            }           

            
                    if (highScore >= 100&& !achievements3)
                    {
            achievements3 = true;
            OnClick.starClickCount++;
            GameObject.FindGameObjectWithTag("ButtonClick").GetComponent<JSONSaving>().CreatePlayerData();
            GameObject.FindGameObjectWithTag("ButtonClick").GetComponent<JSONSaving>().SaveData();
            Social.ReportProgress(GPGSIds.achievement_reach_100_score, 100.00f, (bool success) =>
                    {
                        if (success)
                        {
                            
                        }
                        else
                        {
                            
                        }

                    });
                }
                    if (highScore >= 50 && !achievements4)
                    {
            achievements4 = true;
            OnClick.starClickCount++;
            GameObject.FindGameObjectWithTag("ButtonClick").GetComponent<JSONSaving>().CreatePlayerData();
            GameObject.FindGameObjectWithTag("ButtonClick").GetComponent<JSONSaving>().SaveData();
            Social.ReportProgress(GPGSIds.achievement_reach_50_score, 100.00f, (bool success) =>
                    {
                        if (success)
                        {
                            
                        }
                        else
                        {
                            
                        }

                    });
                }
                    if (highScore >= 30 && !achievements5)
                    {
            achievements5 = true;
            OnClick.starClickCount++;
            GameObject.FindGameObjectWithTag("ButtonClick").GetComponent<JSONSaving>().CreatePlayerData();
            GameObject.FindGameObjectWithTag("ButtonClick").GetComponent<JSONSaving>().SaveData();
            Social.ReportProgress(GPGSIds.achievement_come_on, 100.00f, (bool success) =>
                    {
                        if (success)
                        {
                            

                        }
                        else
                        {

                        }

                    });
                }
                    if (highScore >= 25 && !achievements6)
                    {
            achievements6 = true; ;
            OnClick.starClickCount++;
            GameObject.FindGameObjectWithTag("ButtonClick").GetComponent<JSONSaving>().CreatePlayerData();
            GameObject.FindGameObjectWithTag("ButtonClick").GetComponent<JSONSaving>().SaveData();

            Social.ReportProgress(GPGSIds.achievement_reach_25_score, 100.00f, (bool success) =>
                    {
                        if (success)
                        {
                            

                        }
                        else
                        {

                        }

                    });
                }

                
            
        
        if (starClickCount >= 1 && !achievements7)
        {
            achievements7 = true;
            OnClick.starClickCount++;
            GameObject.FindGameObjectWithTag("ButtonClick").GetComponent<JSONSaving>().CreatePlayerData();
            GameObject.FindGameObjectWithTag("ButtonClick").GetComponent<JSONSaving>().SaveData();
            Social.ReportProgress(GPGSIds.achievement_all_star, 100.00f, (bool success) =>
            {
                if (success)
                {
                    

                }
                else
                {

                }

            });

        }
        if (gameOverScore == 199 && !achievements8)
        {
            achievements8 = true;
            OnClick.starClickCount++;
            GameObject.FindGameObjectWithTag("ButtonClick").GetComponent<JSONSaving>().CreatePlayerData();
            GameObject.FindGameObjectWithTag("ButtonClick").GetComponent<JSONSaving>().SaveData();
            Social.ReportProgress(GPGSIds.achievement_vexed, 100.00f, (bool success) =>
            {
                if (success)
                {
                    
                }
                else
                {

                }

            });

        }
        if (starClickCount == 25)
        {
            Social.ReportProgress(GPGSIds.achievement_sidereal, 0.00f, (bool success) =>
            {


            });
        }
        
            
            
         

    }
    public void RevealAchievement()
    {
        Social.ReportProgress(GPGSIds.achievement_sidereal, 0.00f, (bool success) =>
        {


        });
    }
    public void DoIncrementalAchievement(int starcount)
    {
        PlayGamesPlatform platform = (PlayGamesPlatform)Social.Active;
        platform.IncrementAchievement(GPGSIds.achievement_sidereal, starcount,(bool success)=> { 
        });
    }
    internal void SingIntoGPS(SignInInteractivity interactivity, PlayGamesClientConfiguration configuration)
    {
        configuration = clientConfiguration;
        PlayGamesPlatform.InitializeInstance(configuration);
        PlayGamesPlatform.Activate();
        PlayGamesPlatform.Instance.Authenticate(interactivity, (code) =>
        {
            
            statusTxt.text = "Authenticating...";
            if (code == SignInStatus.Success)
            {
                PlayerPrefs.SetInt("SignedOut", 0);
                signinButton.SetActive(false);
                signoutButton.SetActive(true);
                statusTxt.text = "Connected Account";
                descriptionTxt.text = "Hello: " + Social.localUser.userName + "You have an ID of: " + Social.localUser.id;
            }
            else
            {
                PlayerPrefs.SetInt("SignedOut", 1);
                signoutButton.SetActive(false);
                signinButton.SetActive(true);
                statusTxt.text = "Connection Failed";
                descriptionTxt.text = "Check your connection or google play settings." +
                "To see Leaderboard/Achievements you need to sign in. ";
            }
        });
    }
    public void BasicSignInBtn()
    {
        //PlayerPrefs.SetInt("SignedOut", 0);
        SingIntoGPS(SignInInteractivity.CanPromptAlways, clientConfiguration);
        GameObject.FindGameObjectWithTag("Menu").GetComponent<OptionsScript>().soundE();
        //signoutButton = GameObject.FindGameObjectWithTag("SignOut");
        //signoutButton.SetActive(true);
    }
    public void SignOutBtn()
    {
        PlayerPrefs.SetInt("SignedOut", 1);
        statusTxt.text = "Signed Out";
        descriptionTxt.text = "To see Leaderboard/Achievements you need to sign in.";
        signinButton.SetActive(true);
        PlayGamesPlatform.Instance.SignOut();
        GameObject.FindGameObjectWithTag("Menu").GetComponent<OptionsScript>().soundE();
    }

    public void panelActive()
    {
        gugulPlayPanel.SetActive(true);
    }
    public void panelDeactive()
    {
        gugulPlayPanel.SetActive(false);
    }
    public void Back()
    {
        GameObject.FindGameObjectWithTag("Menu").GetComponent<OptionsScript>().DeactivatePanel();
        GameObject.FindGameObjectWithTag("Menu").GetComponent<OptionsScript>().soundE();
    }
    public void ShowAchievementsUI()
    {
        Social.ShowAchievementsUI();
    }
    public void achievementCheck()
    {
        GameObject.FindGameObjectWithTag("ButtonClick").GetComponent<JSONSaving>().LoadData();
        if (achievements1)
        {
            Social.ReportProgress(GPGSIds.achievement_skykinghardworking, 100.00f, (bool success) =>
            {
                if (success)
                {
                    achievements1 = true; ;

                }
                else
                {

                }

            });
        }
        if (achievements2)
        {
            Social.ReportProgress(GPGSIds.achievement_reach_200_score, 100.00f, (bool success) =>
            {
                if (success)
                {
                    achievements2 = true;
                }
                else
                {

                }

            });
        }
        if (achievements3)
        {
            Social.ReportProgress(GPGSIds.achievement_reach_100_score, 100.00f, (bool success) =>
            {
                if (success)
                {
                    achievements3 = true;
                }
                else
                {

                }

            });
        }
        if (achievements4)
        {
            Social.ReportProgress(GPGSIds.achievement_reach_50_score, 100.00f, (bool success) =>
            {
                if (success)
                {
                    achievements4 = true;
                }
                else
                {

                }

            });
        }
        if (achievements5)
        {
            Social.ReportProgress(GPGSIds.achievement_come_on, 100.00f, (bool success) =>
            {
                if (success)
                {
                    achievements5=true;
                }
                else
                {

                }

            });
        }
        if (achievements6)
        {
            Social.ReportProgress(GPGSIds.achievement_reach_25_score, 100.00f, (bool success) =>
            {
                if (success)
                {
                    achievements6=true;
                }
                else
                {

                }

            });
        }
        if (achievements7)
        {
            Social.ReportProgress(GPGSIds.achievement_all_star, 100.00f, (bool success) =>
            {
                if (success)
                {
                    achievements7=true;
                }
                else
                {

                }

            });
        }
        if (achievements8)
        {
            Social.ReportProgress(GPGSIds.achievement_vexed, 100.00f, (bool success) =>
            {
                if (success)
                {
                    achievements8=true;
                }
                else
                {

                }

            });
        }
        starClickCount = OnClick.starClickCount;
        if (starClickCount >= 25)
        {
            Social.ReportProgress(GPGSIds.achievement_sidereal, 0.00f, (bool success) =>
            {


            });
        }
       // DoIncrementalAchievement(starClickCount);
    }
}
