using System;
using System.Collections.Generic;

namespace NSP.Ads.Core
{
    public static class AdCooldown
    {
        private static Dictionary<AdType, DateTime> lastShown
            = new();

        public static bool CanShow(
            AdType type,
            float cooldownSeconds)
        {
            if (!lastShown.ContainsKey(type))
                return true;

            return
                (DateTime.UtcNow - lastShown[type])
                .TotalSeconds >= cooldownSeconds;
        }

        public static void MarkShown(AdType type)
        {
            lastShown[type] = DateTime.UtcNow;
        }
    }
}