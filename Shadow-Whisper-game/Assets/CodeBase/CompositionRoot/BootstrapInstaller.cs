using CodeBase.CompositionRoot.SubContainers;
using CodeBase.Infrastructure.Foundation.CoroutineAccess;
using CodeBase.Infrastructure.Foundation.Curtain;
using CodeBase.Infrastructure.Foundation.Loader;
using CodeBase.Infrastructure.StateMachines.GameStates;
using CodeBase.Infrastructure.StateMachines.Machines;
using CodeBase.StaticData;
using Zenject;

namespace CodeBase.CompositionRoot
{
    public class BootstrapInstaller : MonoInstaller, IInitializable
    {
        public override void InstallBindings()
        {
            BindSelf();
            
            BindCoroutineRunner();
            
            BindSceneLoader();
            
            BindLoadingCurtain();

            BindGlobalStateMachine();
        }


        public void Initialize()
        {
            var stateMachine = Container.Resolve<IGameStateMachine>();
            stateMachine.Enter<BootstrapState>();
        }

        private void BindSelf()
        {
            Container.BindInterfacesTo<BootstrapInstaller>()
                .FromInstance(this)
                .AsSingle();
        }

        private void BindCoroutineRunner()
        {
            Container
                .Bind<ICoroutineRunner>()
                .To<CoroutineRunner>()
                .FromComponentInNewPrefabResource(ResourcePath.COROUTINE_RUNNER)
                .AsSingle();
        }

        private void BindSceneLoader()
        {
            Container
                .Bind<ISceneLoader>()
                .To<SceneLoader>()
                .AsSingle();
        }

        private void BindLoadingCurtain()
        {
            Container
                .Bind<ILoadingCurtain>()
                .To<LoadingCurtain>()
                .FromComponentInNewPrefabResource(ResourcePath.CURTAIN)
                .AsSingle();
        }
        
        private void BindGlobalStateMachine()
        {
            Container
                .Bind<IGameStateMachine>()
                .FromSubContainerResolve()
                .ByInstaller<GameStateMachineInstaller>()
                .AsSingle();
        }
    }
}