using UnityEngine.Events;
using UnityEngine;
using GoogleMobileAds.Api;
using GoogleMobileAds.Common;
using UnityEngine.UI;
using System;
using System.Collections.Generic;

public class AdMobAds : MonoBehaviour
{
    private BannerView bannerAd;
    // Start is called before the first frame update
    void Start()
    {
        MobileAds.Initialize(InitializationStatus => { });
        

    }

    public void RequestBanner()
    {
        if (bannerAd != null)
        {
            bannerAd.Destroy();
        }
        string adUnitId = "ca-app-pub-5279556348564072/3267500437";
        this.bannerAd = new BannerView(adUnitId, AdSize.SmartBanner, AdPosition.Top);
        AdRequest request = new AdRequest.Builder().Build();
        this.bannerAd.LoadAd(request);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
