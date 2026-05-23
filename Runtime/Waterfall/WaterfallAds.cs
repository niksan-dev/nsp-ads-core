using System;
using System.Collections.Generic;
namespace NSP.Ads.Core
{
    public class WaterfallAds
    {
        private List<IAdProvider> providers;

        public WaterfallAds(
            List<IAdProvider> providers)
        {
            this.providers = providers;
        }

        public void ShowRewarded(
            Action<bool> callback)
        {
            TryProvider(0, callback);
        }

        private void TryProvider(
            int index,
            Action<bool> callback)
        {
            if (index >= providers.Count)
            {
                callback(false);
                return;
            }

            var provider = providers[index];

            if (!provider.IsRewardedReady())
            {
                TryProvider(index + 1, callback);
                return;
            }

            provider.ShowRewarded(success =>
            {
                if (success)
                {
                    callback(true);
                }
                else
                {
                    TryProvider(index + 1, callback);
                }
            });
        }
    }
}