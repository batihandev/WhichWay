using UnityEngine.Events;
using UnityEngine;
using GoogleMobileAds.Api;
using GoogleMobileAds.Common;
using UnityEngine.UI;
using System;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

public class GoogleADMOBmanager : MonoBehaviour
{
    //private AppOpenAd appOpenAd;
    private BannerView bannerView;
    private InterstitialAd interstitialAd;
    private RewardedAd rewardedAd;
   // private RewardedAd rewardedAdEnd;
    //private RewardedInterstitialAd rewardedInterstitialAd;
    private float deltaTime;
    //private bool isShowingAppOpenAd;
    public UnityEvent OnAdLoadedEvent;
    public UnityEvent OnAdFailedToLoadEvent;
    public UnityEvent OnAdOpeningEvent;
    public UnityEvent OnAdFailedToShowEvent;
    public UnityEvent OnUserEarnedRewardEvent;
    public UnityEvent OnAdClosedEvent;
    bool initalized = false;
    bool rewardedadLoaded = false;
    bool rewarded = false;
    public static bool failedtoloadkilladstar=false;
    //public bool showFpsMeter = true;
    //public Text fpsMeter;
    //public Text statusText;


    #region UNITY MONOBEHAVIOR METHODS

    public void Start()
    {
//        MobileAds.SetiOSAppPauseOnBackground(true);

//        List<String> deviceIds = new List<String>() { AdRequest.TestDeviceSimulator };

//      //  Add some test device IDs(replace with your own device IDs).
//#if UNITY_IPHONE
//                deviceIds.Add("96e23e80653bb28980d3f40beb58915c");
//#elif UNITY_ANDROID
//                deviceIds.Add("756fa589ca59194f");
//#endif

//      //  Configure TagForChildDirectedTreatment and test device IDs.
//        RequestConfiguration requestConfiguration =
//            new RequestConfiguration.Builder()
//            .SetTagForChildDirectedTreatment(TagForChildDirectedTreatment.Unspecified)
//            .SetTestDeviceIds(deviceIds).build();
//        MobileAds.SetRequestConfiguration(requestConfiguration);

        // Initialize the Google Mobile Ads SDK.
        if (!initalized)
        {
            MobileAds.Initialize(HandleInitCompleteAction);
        }
     
        // RequestBannerAd();
    }

    private void HandleInitCompleteAction(InitializationStatus initstatus)
    {
        // Callbacks from GoogleMobileAds are not guaranteed to be called on
        // main thread.
        // In this example we use MobileAdsEventExecutor to schedule these calls on
        // the next Update() loop.
        MobileAdsEventExecutor.ExecuteInUpdate(() =>
        {
            //statusText.text = "Initialization complete";
            //Debug.Log("Initialization complete");
            initalized = true;
           // RequestBannerAd();
        });
    }

    //private void Update()
    //{
    //    //if (showFpsMeter)
    //    //{
    //    //    fpsMeter.gameObject.SetActive(true);
    //    //    deltaTime += (Time.deltaTime - deltaTime) * 0.1f;
    //    //    float fps = 1.0f / deltaTime;
    //    //    fpsMeter.text = string.Format("{0:0.} fps", fps);
    //    //}
    //    //else
    //    //{
    //    //    fpsMeter.gameObject.SetActive(false);
    //    //}
    //}

    #endregion

    #region HELPER METHODS

    private AdRequest CreateAdRequest()
    {
        return new AdRequest.Builder()
            .AddKeyword("unity-admob-sample")
            .Build();
    }

    //public void OnApplicationPause(bool paused)
    //{
    //    // Display the app open ad when the app is foregrounded.
    //    if (!paused)
    //    {
    //        ShowAppOpenAd();
    //    }
    //}

    #endregion

    #region BANNER ADS

    public void RequestBannerAd()
    {
        //statusText.text = "Requesting Banner Ad.";
       // Debug.Log("Requesting Banner Ad.");

        // These ad units are configured to always serve test ads.
#if UNITY_EDITOR
        string adUnitId = "ca-app-pub-5279556348564072/3267500437";
#elif UNITY_ANDROID
         string adUnitId = "ca-app-pub-5279556348564072/3267500437";
#elif UNITY_IPHONE
        string adUnitId = "ca-app-pub-5279556348564072/3267500437";
#else
        string adUnitId = "ca-app-pub-5279556348564072/3267500437";
#endif

        // Clean up banner before reusing
        if (bannerView != null)
        {
            bannerView.Destroy();
        }

        // Create a 320x50 banner at top of the screen
        bannerView = new BannerView(adUnitId, AdSize.SmartBanner, AdPosition.Top);

        // Add Event Handlers
        bannerView.OnAdLoaded += (sender, args) => OnAdLoadedEvent.Invoke();
        bannerView.OnAdFailedToLoad += (sender, args) => OnAdFailedToLoadEvent.Invoke();
        bannerView.OnAdOpening += (sender, args) => OnAdOpeningEvent.Invoke();
        bannerView.OnAdClosed += (sender, args) => OnAdClosedEvent.Invoke();

        // Load a banner ad
        bannerView.LoadAd(CreateAdRequest());
    }


    public void DestroyBannerAd()
    {
        if (bannerView != null)
        {
            bannerView.Destroy();
        }
    }

    #endregion

    #region INTERSTITIAL ADS

    public void RequestAndLoadInterstitialAd()
    {
        //statusText.text = "Requesting Interstitial Ad.";
        //Debug.Log("Requesting Interstitial Ad.");

#if UNITY_EDITOR
        string adUnitId = "ca-app-pub-5279556348564072/2462271958";
#elif UNITY_ANDROID
        string adUnitId = "ca-app-pub-5279556348564072/2462271958";
#elif UNITY_IPHONE
        string adUnitId = "ca-app-pub-5279556348564072/2462271958";
#else
        string adUnitId = "ca-app-pub-5279556348564072/2462271958";
#endif
        if (interstitialAd != null)
        {
            interstitialAd.Destroy();
        }
        // Clean up interstitial before using it

        interstitialAd = new InterstitialAd(adUnitId);

        // Add Event Handlers
        interstitialAd.OnAdLoaded += (sender, args) => OnAdLoadedEvent.Invoke();
        interstitialAd.OnAdFailedToLoad += (sender, args) => OnAdFailedToLoadEvent.Invoke();
        interstitialAd.OnAdOpening += (sender, args) => OnAdOpeningEvent.Invoke();
        interstitialAd.OnAdClosed += ClosedInterstitialAd;

        // Load an interstitial ad
        interstitialAd.LoadAd(CreateAdRequest());
    }
    void ClosedInterstitialAd(object sender, EventArgs args)
    {
        DestroyInterstitialAd();
        RequestAndLoadInterstitialAd();
        //Debug.Log("ClosedInterstititalaAD");
    }
    public void ShowInterstitialAd()
    {
        if (interstitialAd != null && interstitialAd.IsLoaded())
        {
            interstitialAd.Show();
            
        }
        else
        {
            // statusText.text = "Interstitial ad is not ready yet";
            Debug.Log("Interstitial ad is not ready yet");
        }
    }

    public void DestroyInterstitialAd()
    {
        if (interstitialAd != null)
        {
            interstitialAd.Destroy();
        }
    }

    #endregion

    #region REWARDED ADS

    public void RequestAndLoadRewardedAd()
    {
        // statusText.text = "Requesting Rewarded Ad.";
        //Debug.Log("Requesting Rewarded Ad.");
#if UNITY_EDITOR
        string adUnitId = "ca-app-pub-5279556348564072/4524193044";
#elif UNITY_ANDROID
        string adUnitId = "ca-app-pub-5279556348564072/4524193044";
#elif UNITY_IPHONE
        string adUnitId = "ca-app-pub-5279556348564072/4524193044";
#else
        string adUnitId = "ca-app-pub-5279556348564072/4524193044";
#endif

        if (rewardedAd != null)
        {
            rewardedAd.Destroy();
            rewardedAd = null;
        }
        // create new rewarded ad instance
        rewardedadLoaded = false;
        rewardedAd = new RewardedAd(adUnitId);

        // Add Event Handlers
        rewardedAd.OnAdLoaded += Loaded;
        //rewardedAd.OnAdFailedToLoad += (sender, args) => OnAdFailedToLoadEvent.Invoke();
        //rewardedAd.OnAdOpening += (sender, args) => OnAdOpeningEvent.Invoke();
        //rewardedAd.OnAdFailedToShow += (sender, args) => OnAdFailedToShowEvent.Invoke();
        rewardedAd.OnAdClosed += HandleRewardBasedVideoClosed;
        rewardedAd.OnUserEarnedReward += HandleRewardBasedVideoRewarded;
        rewardedAd.OnAdFailedToLoad += FailedLoad;
        rewardedAd.OnAdFailedToShow += FailedShow;
       
        // Create empty ad request
        rewardedAd.LoadAd(CreateAdRequest());
    }
    public void Loaded(object sender, EventArgs args)
    {
        failedtoloadkilladstar = false;
        rewardedadLoaded = true;
       Debug.Log("loadedad");
    }
    public void ToWait()
    {
        
        SceneManager.LoadScene("GamePlay");


    }
 
    public void FailedShow(object sender, EventArgs args)
    {
        if (EndGameMenu.endgameMenuisOn)
        {
            if (GameObject.FindGameObjectWithTag("EndGMenu") != null) { GameObject.FindGameObjectWithTag("EndGMenu").GetComponent<EndGameMenu>().ConButtonRemover(); }

            //Debug.Log("failed show ");
        }
        else
        {
            if (GameObject.FindGameObjectWithTag("Pwaypoint") != null)
            {
                OnClickAdd.adstarClicked = true;
                GameObject.FindGameObjectWithTag("Pwaypoint").GetComponent<AdsStarScript>().DeadManWalking();
            }
            GameObject.FindGameObjectWithTag("Menu").GetComponent<PauseMenu>().Resume();
            Debug.Log("failed show ");
            Debug.Log(args);
        }

    }
    public void FailedLoad(object sender, EventArgs args)
    {
        if (EndGameMenu.endgameMenuisOn)
        {
            if (GameObject.FindGameObjectWithTag("EndGMenu") != null) { GameObject.FindGameObjectWithTag("EndGMenu").GetComponent<EndGameMenu>().ConButtonRemover(); }

            Debug.Log("failed load ");
        }
        else
        {
            OnClickAdd.adstarClicked = true;
            failedtoloadkilladstar = true;
            //if (GameObject.FindGameObjectWithTag("Pwaypoint") != null)
            //{
            //    GameObject.FindGameObjectWithTag("Pwaypoint").GetComponent<AdsStarScript>().DeadManWalking();
            //}

            Debug.Log("failed load ");
        }

    }


    public void HandleRewardBasedVideoClosed (object sender, EventArgs args)
    {
        if (rewarded)
        {
            rewarded = false;
            if (EndGameMenu.endgameMenuisOn)
            {
                rewardedadLoaded = false;
                //RequestAndLoadRewardedAd();
               // Debug.Log("closed");
            }
            else
            {
                GameObject.FindGameObjectWithTag("Menu").GetComponent<PauseMenu>().Resume();
                rewardedadLoaded = false;
                OnClickAdd.adstarClicked = false;
                RequestAndLoadRewardedAd();
              //  Debug.Log("closed");
            }
        }
        else
        {
            if (EndGameMenu.endgameMenuisOn)
            {
                if (GameObject.FindGameObjectWithTag("EndGMenu") != null) { GameObject.FindGameObjectWithTag("EndGMenu").GetComponent<EndGameMenu>().ConButtonRemover(); }

               // Debug.Log("failed load ");
            }
            else
            {
                GameObject.FindGameObjectWithTag("Menu").GetComponent<PauseMenu>().Resume();
                if (GameObject.FindGameObjectWithTag("Pwaypoint") != null)
                {
                    OnClickAdd.adstarClicked = true;
                    GameObject.FindGameObjectWithTag("Pwaypoint").GetComponent<AdsStarScript>().DeadManWalking();
                }

              //  Debug.Log("failed load ");
            }

        }
      
       
    }
    public void HandleRewardBasedVideoRewarded(object sender, Reward args)
    {
        rewarded = true;
        if (EndGameMenu.endgameMenuisOn)
        {
           // Debug.Log("endgamemenu");
            EndGameMenu.thisIsTheSameGame = true;
            EndGameMenu.adWatchedToContinue = true;
            Time.timeScale = 1;
            PauseMenu.swiped = false;
            PauseMenu.gameIsPaused = false;
            GameObject.FindGameObjectWithTag("ButtonClick").GetComponent<SaveMe>().PlaySound();
            Invoke("ToWait", 0.2f);
           // Debug.Log("rewareded");
        }
        else
        {
            OnClickAdd.adstarClicked = true;
            GameObject.FindGameObjectWithTag("Pwaypoint").GetComponent<AdsStarScript>().AdsStarEffect();
            //EndGameMenu.adWatchedToContinue = true;
            if (ChosePortal.starportalsDestroyed)
            {
                ChosePortal.starisClicked = true;
            }
          //  Debug.Log("rewareded");
        }

    }
      
    
   
    //public void Reward()
    //{
    //    OnClickAdd.adstarClicked = true;
    //}
 
    public void ShowRewardedAd()
    {
        if (rewardedAd != null && rewardedadLoaded)
        {
            rewardedAd.Show();
           // Debug.Log("showingrewarded");
        }
        else
        {
            if (rewardedAd != null)
            {
                rewardedAd.Destroy();
                rewardedAd = null;
            }
            if (!failedtoloadkilladstar) {
                if (EndGameMenu.endgameMenuisOn)
                {
                   // Debug.Log("endgamemenu");
                    EndGameMenu.thisIsTheSameGame = true;
                    EndGameMenu.adWatchedToContinue = true;
                    Time.timeScale = 1;
                    PauseMenu.swiped = false;
                    PauseMenu.gameIsPaused = false;
                    GameObject.FindGameObjectWithTag("ButtonClick").GetComponent<SaveMe>().PlaySound();
                    Invoke("ToWait", 0.2f);
                  //  Debug.Log("toomanyadswatchedsoEnd");
                }
                else
                {
                    OnClickAdd.adstarClicked = true;
                    GameObject.FindGameObjectWithTag("Pwaypoint").GetComponent<AdsStarScript>().AdsStarEffect();
                    //EndGameMenu.adWatchedToContinue = true;
                    if (ChosePortal.starportalsDestroyed)
                    {
                        ChosePortal.starisClicked = true;
                    }
                   // Debug.Log("toomanyadswatcheds");
                }
            }
            else
            {
                if (EndGameMenu.endgameMenuisOn)
                {
                    if (GameObject.FindGameObjectWithTag("EndGMenu") != null) { GameObject.FindGameObjectWithTag("EndGMenu").GetComponent<EndGameMenu>().ConButtonRemover(); }

                   // Debug.Log("failed load ");
                }
                else
                {
                    //failedtoloadkilladstar = true;
                    //if (GameObject.FindGameObjectWithTag("Pwaypoint") != null)
                    //{
                    //    GameObject.FindGameObjectWithTag("Pwaypoint").GetComponent<AdsStarScript>().DeadManWalking();
                    //}

                  //  Debug.Log("failed load ");
                }
            }
         
            // statusText.text = "Rewarded ad is not ready yet.";
          //  Debug.Log("Rewarded ad is not ready yet.");
        }
    }

//    public void RequestAndLoadRewardedInterstitialAd()
//    {
//        // statusText.text = "Requesting Rewarded Interstitial Ad.";
//        Debug.Log("Requesting Rewarded Interstitial Ad.");

//        // These ad units are configured to always serve test ads.
//#if UNITY_EDITOR
//        string adUnitId = "unused";
//#elif UNITY_ANDROID
//            string adUnitId = "ca-app-pub-3940256099942544/5354046379";
//#elif UNITY_IPHONE
//            string adUnitId = "ca-app-pub-3940256099942544/6978759866";
//#else
//            string adUnitId = "unexpected_platform";
//#endif

//        // Create an interstitial.
//        RewardedInterstitialAd.LoadAd(adUnitId, CreateAdRequest(), (rewardedInterstitialAd, error) =>
//        {
//            if (error != null)
//            {
//                MobileAdsEventExecutor.ExecuteInUpdate(() => {
//                    //statusText.text = "RewardedInterstitialAd load failed, error: " + error;
//                    Debug.Log("RewardedInterstitialAd load failed, error: " + error);
//                });
//                return;
//            }
//            this.rewardedInterstitialAd = rewardedInterstitialAd;
//            MobileAdsEventExecutor.ExecuteInUpdate(() => {
//                // statusText.text = "RewardedInterstitialAd loaded";
//                Debug.Log("RewardedInterstitialAd loaded");
//            });
//            // Register for ad events.
//            this.rewardedInterstitialAd.OnAdDidPresentFullScreenContent += (sender, args) =>
//            {
//                MobileAdsEventExecutor.ExecuteInUpdate(() => {
//                    // statusText.text = "Rewarded Interstitial presented.";
//                    Debug.Log("Rewarded Interstitial presented.");
//                });
//            };
//            this.rewardedInterstitialAd.OnAdDidDismissFullScreenContent += (sender, args) =>
//            {
//                MobileAdsEventExecutor.ExecuteInUpdate(() => {
//                    // statusText.text = "Rewarded Interstitial dismissed.";
//                    Debug.Log("Rewarded Interstitial dismissed.");
//                });
//                this.rewardedInterstitialAd = null;
//            };
//            this.rewardedInterstitialAd.OnAdFailedToPresentFullScreenContent += (sender, args) =>
//            {
//                MobileAdsEventExecutor.ExecuteInUpdate(() => {
//                    //statusText.text = "Rewarded Interstitial failed to present.";
//                    Debug.Log("Rewarded Interstitial failed to present.");
//                });
//                this.rewardedInterstitialAd = null;
//            };
//        });
//    }

    //public void ShowRewardedInterstitialAd()
    //{
    //    if (rewardedInterstitialAd != null)
    //    {
    //        rewardedInterstitialAd.Show((reward) => {
    //            MobileAdsEventExecutor.ExecuteInUpdate(() => {
    //               // statusText.text = "User Rewarded: " + reward.Amount;
    //                Debug.Log("User Rewarded: " + reward.Amount);
    //            });
    //        });
    //    }
    //    else
    //    {
    //        //statusText.text = "Rewarded ad is not ready yet.";
    //        Debug.Log("Rewarded ad is not ready yet.");
    //    }
    //}

    #endregion

//    #region APPOPEN ADS

//    public void RequestAndLoadAppOpenAd()
//    {
//       // statusText.text = "Requesting App Open Ad.";

//        Debug.Log("Requesting App Open Ad.");
//#if UNITY_EDITOR
//        string adUnitId = "unused";
//#elif UNITY_ANDROID
//        string adUnitId = "ca-app-pub-3940256099942544/3419835294";
//#elif UNITY_IPHONE
//        string adUnitId = "ca-app-pub-3940256099942544/5662855259";
//#else
//        string adUnitId = "unexpected_platform";
//#endif
//        // create new app open ad instance
//        AppOpenAd.LoadAd(adUnitId, ScreenOrientation.Portrait, CreateAdRequest(), (appOpenAd, error) =>
//        {
//            if (error != null)
//            {
//                MobileAdsEventExecutor.ExecuteInUpdate(() => {
//                    //statusText.text = "AppOpenAd load failed, error: " + error;
//                    Debug.Log("AppOpenAd load failed, error: " + error);
//                });
//                return;
//            }
//            MobileAdsEventExecutor.ExecuteInUpdate(() => {
//                //statusText.text = "AppOpenAd loaded. Please background the app and return.";
//                Debug.Log("AppOpenAd loaded. Please background the app and return.");
//            });
//            this.appOpenAd = appOpenAd;
//        });
//    }

//    public void ShowAppOpenAd()
//    {
//        if (isShowingAppOpenAd)
//        {
//            return;
//        }
//        if (appOpenAd == null)
//        {
//            return;
//        }
//        // Register for ad events.
//        this.appOpenAd.OnAdDidDismissFullScreenContent += (sender, args) =>
//        {
//            isShowingAppOpenAd = false;
//            MobileAdsEventExecutor.ExecuteInUpdate(() => {
//                Debug.Log("AppOpenAd dismissed.");
//                if (this.appOpenAd != null)
//                {
//                    this.appOpenAd.Destroy();
//                    this.appOpenAd = null;
//                }
//            });
//        };
//        this.appOpenAd.OnAdFailedToPresentFullScreenContent += (sender, args) =>
//        {
//            isShowingAppOpenAd = false;
//            var msg = args.AdError.GetMessage();
//            MobileAdsEventExecutor.ExecuteInUpdate(() => {
//                //statusText.text = "AppOpenAd present failed, error: " + msg;
//                Debug.Log("AppOpenAd present failed, error: " + msg);
//                if (this.appOpenAd != null)
//                {
//                    this.appOpenAd.Destroy();
//                    this.appOpenAd = null;
//                }
//            });
//        };
//        this.appOpenAd.OnAdDidPresentFullScreenContent += (sender, args) =>
//        {
//            isShowingAppOpenAd = true;
//            MobileAdsEventExecutor.ExecuteInUpdate(() => {
//                Debug.Log("AppOpenAd presented.");
//            });
//        };
//        this.appOpenAd.OnAdDidRecordImpression += (sender, args) =>
//        {
//            MobileAdsEventExecutor.ExecuteInUpdate(() => {
//                Debug.Log("AppOpenAd recorded an impression.");
//            });
//        };
//        this.appOpenAd.OnPaidEvent += (sender, args) =>
//        {
//            string currencyCode = args.AdValue.CurrencyCode;
//            long adValue = args.AdValue.Value;
//            string suffix = "AppOpenAd received a paid event.";
//            MobileAdsEventExecutor.ExecuteInUpdate(() => {
//                string msg = string.Format("{0} (currency: {1}, value: {2}", suffix, currencyCode, adValue);
//                //statusText.text = msg;
//                Debug.Log( msg);
//            });
//        };
//        appOpenAd.Show();
//    }

//    #endregion


    #region AD INSPECTOR

    public void OpenAdInspector()
    {
        // statusText.text = "Open Ad Inspector.";
        Debug.Log("Open Ad Inspector.");
        MobileAds.OpenAdInspector((error) =>
        {
            if (error != null)
            {
                string errorMessage = error.GetMessage();
                MobileAdsEventExecutor.ExecuteInUpdate(() => {
                    //statusText.text = "Ad Inspector failed to open, error: " + errorMessage;
                    Debug.Log("Ad Inspector failed to open, error: " + errorMessage);
                });
            }
            else
            {
                MobileAdsEventExecutor.ExecuteInUpdate(() => {
                    //statusText.text = "Ad Inspector closed.";
                    Debug.Log("Ad Inspector closed.");
                });
            }
        });
    }

    #endregion
}
