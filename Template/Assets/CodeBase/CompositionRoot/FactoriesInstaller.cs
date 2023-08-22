using CodeBase.Infrastructure.ResourceLoad;
using CodeBase.Infrastructure.Services.Factory;
using CodeBase.UI.Services.Factory;
using Zenject;

namespace CodeBase.CompositionRoot
{
    public class FactoriesInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            BindResourceLoader();

            BindGameFactory();
            
            BindUIFactory();
        }

        private void BindResourceLoader()
        {
            Container
                .Bind<IResourceLoader>()
                .To<ResourceLoader>()
                .AsSingle();
        }

        private void BindGameFactory()
        {
            Container
                .Bind<IGameFactory>()
                .To<GameFactory>()
                .AsSingle();
        }
        
        private void BindUIFactory()
        {
            Container
                .Bind<IUIFactory>()
                .To<UIFactory>()
                .AsSingle();
        }
    }
}