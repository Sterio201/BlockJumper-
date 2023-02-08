using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mycom.Target.Unity.Ads;
using System;

public class MyTargetManager : MonoBehaviour
{
    public uint ANDROID_SLOT_ID;

    private void Start()
    {
        InitAd();
    }

    InterstitialAd CreateInterstitial()
    {
        UInt32 slotId = ANDROID_SLOT_ID;
#if UNITY_ANDROID
        slotId = ANDROID_SLOT_ID;
#elif UNITY_IOS
    slotId = IOS_SLOT_ID;
#endif

        // Включение режима отладки
        // InterstitialAd.IsDebugMode = true;
        // Создаем экземпляр InterstitialAd
        return new InterstitialAd(slotId);
    }

    private InterstitialAd _interstitialAd;

    private void InitAd()
    {
        // Создаем экземпляр InterstitialAd
        _interstitialAd = CreateInterstitial();

        // Запускаем загрузку данных
        _interstitialAd.Load();
    }

    public void Show()
    {
        _interstitialAd.Show();
    }
}