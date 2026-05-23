using System;

namespace NSP.Ads.Core
{

    public interface IAdProvider
    {
        string Name { get; }

        void Initialize();

        bool IsBannerReady();

        bool IsInterstitialReady();

        bool IsRewardedReady();

        void ShowBanner();

        void HideBanner();

        void ShowInterstitial(Action<bool> callback);

        void ShowRewarded(Action<bool> callback);
    }
}