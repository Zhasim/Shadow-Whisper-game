using UnityEngine;

namespace CodeBase.Infrastructure.Services.Ads
{
    public class AdsService : IAdsService
    {
        public void Initialize()
        {
            Debug.Log("Ads initialized.");
        }
    }
}