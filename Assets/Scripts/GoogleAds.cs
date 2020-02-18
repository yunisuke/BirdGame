using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleMobileAds.Api;
 
public class GoogleAds : MonoBehaviour {
    private BannerView bannerView;

    public void RequestBanner()
    {
        // アプリID
        string appId = "ca-app-pub-9131760489850595~3015744991";
 
        // Initialize the Google Mobile Ads SDK.
        MobileAds.Initialize(appId);

        // 広告ユニットID 本物
        #if DEVELOPMENT_BUILD
            string adUnitId = "ca-app-pub-3940256099942544/6300978111";
        #elif UNITY_ANDROID
            string adUnitId = "ca-app-pub-9131760489850595/1222768283";
        #elif UNTI_IPHONE

        #else
            string adUnitId = "other";
        #endif

        // Create a 320x50 banner at the top of the screen.
        bannerView = new BannerView(adUnitId, AdSize.Banner, AdPosition.Top);
 
        // Create an empty ad request.
        AdRequest request = new AdRequest.Builder().Build();
 
        // Load the banner with the request.
        bannerView.LoadAd(request);
    }

    public void HideBannerView () {
        bannerView.Hide ();
    }

    public void ShowBannerView () {
        bannerView.Show ();
    }
}