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
    int highScore = 0;
    int starClickCount = 0;
    int steps = 0;
    
    int gameOverScore = 0;
    

    public bool isLogedIn;

    internal void ConfigureGPGS()
    {
        clientConfiguration = new PlayGamesClientConfiguration.Builder().Build();
    }
    public void Awake()
    {
        
    }
    private void Start()
    {
        highScore = PlayerPrefs.GetInt("highScore", 0);
        gameOverScore = PlayerPrefs.GetInt("gameOverScore", 0);
        starClickCount = PlayerPrefs.GetInt("starClickCount", 0);
        ConfigureGPGS();
        SingIntoGPS(SignInInteractivity.CanPromptOnce, clientConfiguration);
      
    }
    private void Update()
    {
        highScore = PlayerPrefs.GetInt("highScore", 0);
        starClickCount = PlayerPrefs.GetInt("starClickCount",0);
        steps = PlayerPrefs.GetInt("steps", 0);

        if (highScore == 229 && PlayerPrefs.GetInt("achievements1", 0)==0)
            {
                Social.ReportProgress(GPGSIds.achievement_skykinghardworking, 100.00f, (bool success) =>
                {
                    if (success)
                    {
                        PlayerPrefs.SetInt("achievements1", 1);

                    }
                    else
                    {
                        
                    }

                });
            }
            if (highScore == 200&&PlayerPrefs.GetInt("achievements2", 0) == 0)
            {
                Social.ReportProgress(GPGSIds.achievement_reach_200_score, 100.00f, (bool success) =>
                {
                    if (success)
                    {
                        PlayerPrefs.SetInt("achievements2", 1);
                    }
                    else
                    {
                        
                    }

                });
            }           

            
                    if (highScore == 100&& PlayerPrefs.GetInt("achievements3", 0) == 0)
                    {
                    Social.ReportProgress(GPGSIds.achievement_reach_100_score, 100.00f, (bool success) =>
                    {
                        if (success)
                        {
                            PlayerPrefs.SetInt("achievements3", 1);
                        }
                        else
                        {
                            
                        }

                    });
                }
                    if (highScore == 50 && PlayerPrefs.GetInt("achievements4", 0) == 0)
                    {
                    Social.ReportProgress(GPGSIds.achievement_reach_50_score, 100.00f, (bool success) =>
                    {
                        if (success)
                        {
                            PlayerPrefs.SetInt("achievements4", 1);
                        }
                        else
                        {
                            
                        }

                    });
                }
                    if (highScore == 30 && PlayerPrefs.GetInt("achievements5", 0) == 0)
                    {
                    Social.ReportProgress(GPGSIds.achievement_come_on, 100.00f, (bool success) =>
                    {
                        if (success)
                        {
                            PlayerPrefs.SetInt("achievements5", 1);
                        }
                        else
                        {

                        }

                    });
                }
                    if (highScore == 25 && PlayerPrefs.GetInt("achievements6", 0) == 0)
                    {
                    Social.ReportProgress(GPGSIds.achievement_reach_25_score, 100.00f, (bool success) =>
                    {
                        if (success)
                        {
                            PlayerPrefs.SetInt("achievements6", 1);
                        }
                        else
                        {

                        }

                    });
                }

                
            
        
        if (starClickCount == 1 && PlayerPrefs.GetInt("achievements7", 0) == 0)
        {
            Social.ReportProgress(GPGSIds.achievement_all_star, 100.00f, (bool success) =>
            {
                if (success)
                {
                    PlayerPrefs.SetInt("achievements7", 1);
                }
                else
                {

                }

            });

        }
        if (gameOverScore == 199 && PlayerPrefs.GetInt("achievements8", 0) == 0)
        {
            Social.ReportProgress(GPGSIds.achievement_vexed, 100.00f, (bool success) =>
            {
                if (success)
                {
                    PlayerPrefs.SetInt("achievements8", 1);
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
                
                signinButton.SetActive(false);
                signoutButton.SetActive(true);
                statusTxt.text = "Connected Account";
                descriptionTxt.text = "Hello: " + Social.localUser.userName + "You have an ID of: " + Social.localUser.id;
            }
            else
            {
                
                signoutButton.SetActive(false);
                signinButton.SetActive(true);
                statusTxt.text = "Connection Failed";
                descriptionTxt.text = "Check your connection or google play settings. " ;
            }
        });
    }
    public void BasicSignInBtn()
    {
        
        SingIntoGPS(SignInInteractivity.CanPromptAlways, clientConfiguration);
        GameObject.FindGameObjectWithTag("Menu").GetComponent<OptionsScript>().soundE();
        //signoutButton = GameObject.FindGameObjectWithTag("SignOut");
        //signoutButton.SetActive(true);
    }
    public void SignOutBtn()
    {
        
        statusTxt.text = "Signed Out";
        descriptionTxt.text = "";
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
        if (PlayerPrefs.GetInt("achievements1", 0) == 1)
        {
            Social.ReportProgress(GPGSIds.achievement_skykinghardworking, 100.00f, (bool success) =>
            {
                if (success)
                {
                    PlayerPrefs.SetInt("achievements1", 1);

                }
                else
                {

                }

            });
        }
        if (PlayerPrefs.GetInt("achievements2", 0) == 1)
        {
            Social.ReportProgress(GPGSIds.achievement_reach_200_score, 100.00f, (bool success) =>
            {
                if (success)
                {
                    PlayerPrefs.SetInt("achievements2", 1);
                }
                else
                {

                }

            });
        }
        if (PlayerPrefs.GetInt("achievements3", 0) == 1)
        {
            Social.ReportProgress(GPGSIds.achievement_reach_100_score, 100.00f, (bool success) =>
            {
                if (success)
                {
                    PlayerPrefs.SetInt("achievements3", 1);
                }
                else
                {

                }

            });
        }
        if (PlayerPrefs.GetInt("achievements4", 0) == 1)
        {
            Social.ReportProgress(GPGSIds.achievement_reach_50_score, 100.00f, (bool success) =>
            {
                if (success)
                {
                    PlayerPrefs.SetInt("achievements4", 1);
                }
                else
                {

                }

            });
        }
        if (PlayerPrefs.GetInt("achievements5", 0) == 1)
        {
            Social.ReportProgress(GPGSIds.achievement_come_on, 100.00f, (bool success) =>
            {
                if (success)
                {
                    PlayerPrefs.SetInt("achievements5", 1);
                }
                else
                {

                }

            });
        }
        if (PlayerPrefs.GetInt("achievements6", 0) == 1)
        {
            Social.ReportProgress(GPGSIds.achievement_reach_25_score, 100.00f, (bool success) =>
            {
                if (success)
                {
                    PlayerPrefs.SetInt("achievements6", 1);
                }
                else
                {

                }

            });
        }
        if (PlayerPrefs.GetInt("achievements7", 0) == 1)
        {
            Social.ReportProgress(GPGSIds.achievement_all_star, 100.00f, (bool success) =>
            {
                if (success)
                {
                    PlayerPrefs.SetInt("achievements7", 1);
                }
                else
                {

                }

            });
        }
        if (PlayerPrefs.GetInt("achievements8", 0) == 1)
        {
            Social.ReportProgress(GPGSIds.achievement_vexed, 100.00f, (bool success) =>
            {
                if (success)
                {
                    PlayerPrefs.SetInt("achievements8", 1);
                }
                else
                {

                }

            });
        }
        starClickCount = PlayerPrefs.GetInt("starClickCount", 0);
        if (starClickCount >= 25)
        {
            Social.ReportProgress(GPGSIds.achievement_sidereal, 0.00f, (bool success) =>
            {


            });
        }
       // DoIncrementalAchievement(starClickCount);
    }
}
