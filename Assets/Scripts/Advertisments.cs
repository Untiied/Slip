using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleMobileAds.Api;

public class Advertisments : MonoBehaviour {

#if UNITY_EDITOR
    //static string adUnitId = "unused";
    static string badUnitId = "ca-app-pub-3940256099942544/6300978111";
    static string iadUnitId = "	ca-app-pub-3940256099942544/1033173712";
#elif UNITY_ANDROID
       static string badUnitId = "ca-app-pub-7068414689270670/8464757810";
       static string iadUnitId = "ca-app-pub-7068414689270670/3307923619";
#elif UNITY_IPHONE
       static string badUnitId = "INSERT_IOS_BANNER_AD_UNIT_ID_HERE";
       static string iadUnitId = "INSERT_ANDROID_INTERSTITIAL_AD_UNIT_ID_HERE";
#else
       static string badUnitId = "unexpected_platform";
       static string iadUnitId = "INSERT_ANDROID_INTERSTITIAL_AD_UNIT_ID_HERE";
#endif


    public static BannerView bannerView;
    public static InterstitialAd interstitial;

   public static AdRequest request = new AdRequest.Builder().AddTestDevice(AdRequest.TestDeviceSimulator).AddTestDevice(SystemInfo.deviceUniqueIdentifier).Build();

    public static bool Load()
    {
        interstitial = new InterstitialAd(iadUnitId);
        interstitial.LoadAd(request);

        bannerView = new BannerView(badUnitId, AdSize.Banner, AdPosition.Bottom);
        return true;
    }

    public static void ShowBanner()
    {
        bannerView.LoadAd(request);
    }

    public static void ShowInterstitial()
    {
        if (interstitial.IsLoaded())
        {
            interstitial.Show();
        }
    }

}

