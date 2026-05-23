using System.Collections.Generic;
using NSP.Ads.Core;
public class AdsManager
{
    private WaterfallAds rewardedAds;

    public void Initialize(
        List<IAdProvider> providers)
    {
        foreach (var provider in providers)
        {
            provider.Initialize();
        }

        rewardedAds =
            new WaterfallAds(providers);
    }

    public void ShowRewarded()
    {
        if (!AdCooldown.CanShow(
            AdType.Rewarded,
            30))
        {
            return;
        }

        rewardedAds.ShowRewarded(success =>
        {
            if (success)
            {
                AdCooldown.MarkShown(
                    AdType.Rewarded);
            }
        });
    }
}