using System;

namespace CodeBase.Infrastructure.Foundation.Loader
{
    public interface ISceneLoader
    {
        void Load(string sceneName, Action onLoaded = null);
    }
}