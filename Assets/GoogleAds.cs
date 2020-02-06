﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleMobileAds.Api;
 
public class GoogleAds : MonoBehaviour {
 
	// Use this for initialization
	void Start () {
        // アプリID
        string appId = "ca-app-pub-9131760489850595~3015744991";
 
        // Initialize the Google Mobile Ads SDK.
        MobileAds.Initialize(appId);
 
        RequestBanner();
	}

    private void RequestBanner()
    {
        // 広告ユニットID これはテスト用
        string adUnitId = "ca-app-pub-3940256099942544/6300978111";

        // 本物
        // string adUnitId = "ca-app-pub-9131760489850595/1222768283";
 
        // Create a 320x50 banner at the top of the screen.
        BannerView bannerView = new BannerView(adUnitId, AdSize.Banner, AdPosition.Bottom);
 
        // Create an empty ad request.
        AdRequest request = new AdRequest.Builder().Build();
 
        // Load the banner with the request.
        bannerView.LoadAd(request);
    }
}