using CodeBase.Infrastructure.StateMachines.GameStates;
using CodeBase.Infrastructure.StateMachines.Machines;
using Zenject;

namespace CodeBase.CompositionRoot.SubContainers
{
    public class GameStateMachineInstaller : Installer<GameStateMachineInstaller>
    {
        public override void InstallBindings()
        {
            BindGlobalStates();
            BindGlobalStateMachine();
        }
        

        private void BindGlobalStates()
        {
            Container.BindFactory<IGameStateMachine, BootstrapState, BootstrapState.Factory>();
            Container.BindFactory<IGameStateMachine, LoadProgressState, LoadProgressState.Factory>();
            Container.BindFactory<IGameStateMachine, LoadSceneState, LoadSceneState.Factory>();
            Container.BindFactory<IGameStateMachine, GameLoopState, GameLoopState.Factory>();
        }

        private void BindGlobalStateMachine()
        {
            Container
                .Bind<IGameStateMachine>()
                .To<GameStateMachine>()
                .AsSingle();
        }
    }
}