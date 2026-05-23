using UnityEngine;
namespace NSP.Ads.Core
{
    public class RetryPolicy
    {
        private int retryCount;

        public float GetDelay()
        {
            retryCount++;

            return Mathf.Min(
                Mathf.Pow(2, retryCount),
                60f
            );
        }

        public void Reset()
        {
            retryCount = 0;
        }
    }
}