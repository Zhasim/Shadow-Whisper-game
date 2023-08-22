using UnityEngine;

namespace CodeBase.Infrastructure.Services.StaticData
{
    public class StaticDataService : IStaticDataService
    {
        public void Initialize()
        {
            Debug.Log("Static data initialized.");
        }
    }
}