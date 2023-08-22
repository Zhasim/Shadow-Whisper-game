using System;

namespace CodeBase.Data
{
    [Serializable]
    public class OverallProgress
    {
        public WorldData WorldData;

        public OverallProgress()
        {
            WorldData = new WorldData();
        }
    }
}