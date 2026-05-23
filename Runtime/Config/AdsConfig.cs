using UnityEngine;

namespace NSP.Ads.Core
{
    [CreateAssetMenu(
        fileName = "AdsConfig",
        menuName = "NSP/Ads Config")]
    public class AdsConfig : ScriptableObject
    {
        [Header("AdMob")]
        public AdUnitIds AdMob;

        [Header("Unity Ads")]
        public AdUnitIds UnityAds;

        [Header("IronSource")]
        public AdUnitIds IronSource;

        [Header("Settings")]
        public bool TestMode = true;

        public float InterstitialCooldown = 60f;

        public float RewardedCooldown = 30f;

        public int RetryCount = 3;
    }
}