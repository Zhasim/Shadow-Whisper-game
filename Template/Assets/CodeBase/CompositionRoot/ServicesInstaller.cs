using CodeBase.CompositionRoot.SubContainers;
using CodeBase.Infrastructure.Services.Ads;
using CodeBase.Infrastructure.Services.CustomLogger;
using CodeBase.Infrastructure.Services.Disposal;
using CodeBase.Infrastructure.Services.Input;
using CodeBase.Infrastructure.Services.Progress.Generator;
using CodeBase.Infrastructure.Services.Progress.Registration;
using CodeBase.Infrastructure.Services.Progress.Service;
using CodeBase.Infrastructure.Services.Randomizer;
using CodeBase.Infrastructure.Services.SaveLoad;
using CodeBase.Infrastructure.Services.StaticData;
using Zenject;

namespace CodeBase.CompositionRoot.MonoInstallers
{
    public class ServicesInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            BindInputService();
            
            BindCustomLogger();

            BindDisposer();
            
            BindRandomService();

            BindProgress();
            
            BindStaticDataService();

            BindSaveLoadService();
            
            BindAdsService();
        }

        private void BindProgressGenerator()
        {
            Container
                .Bind<IProgressGenerator>()
                .To<ProgressGenerator>()
                .AsSingle();
        }

        private void BindProgressService()
        {
            Container
                .Bind<IProgressService>()
                .To<ProgressService>()
                .AsSingle();
        }

        private void BindRegistrationService()
        {
            Container
                .Bind<IRegistrationService>()
                .To<RegistrationService>()
                .AsSingle();
        }

        private void BindCustomLogger()
        {
            Container
                .Bind<ILogger>()
                .To<Logger>()
                .AsSingle();
        }

        private void BindDisposer()
        {
            Container
                .Bind<IDisposer>()
                .To<Disposer>()
                .AsSingle();
        }

        private void BindStaticDataService()
        {
            Container
                .Bind<IStaticDataService>()
                .To<StaticDataService>()
                .AsSingle();
        }

        private void BindRandomService()
        {
            Container
                .Bind<IRandomService>()
                .To<RandomService>()
                .AsSingle();
        }

        private void BindSaveLoadService()
        {
            Container
                .Bind<ISaveLoadService>()
                .To<SaveLoadService>()
                .AsSingle();
        }

        private void BindAdsService()
        {
            Container
                .Bind<IAdsService>()
                .To<AdsService>()
                .AsSingle();
        }


        private void BindInputService()
        {
            Container
                .Bind<IInputService>()
                .FromSubContainerResolve()
                .ByInstaller<InputInstaller>()
                .AsSingle();
        }

        private void BindProgress()
        {
            BindRegistrationService();

            BindProgressGenerator();
            
            BindProgressService();
        }
    }
}