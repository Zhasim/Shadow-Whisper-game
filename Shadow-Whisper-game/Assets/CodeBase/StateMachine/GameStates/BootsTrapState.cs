using CodeBase.Infrastructure.Foundation.Loader;
using CodeBase.Infrastructure.StateMachines.Machines;
using CodeBase.Infrastructure.StateMachines.States;
using CodeBase.StaticData;
using UnityEngine.SceneManagement;
using Zenject;
using ILogger = CodeBase.Infrastructure.Services.CustomLogger.ILogger;

namespace CodeBase.Infrastructure.StateMachines.GameStates
{
    public class BootstrapState : IState
    {
        private readonly IGameStateMachine _stateMachine;
        private readonly ILogger _logger;
        private readonly ISceneLoader _sceneLoader;

        public BootstrapState(IGameStateMachine stateMachine, 
            ILogger logger,
            ISceneLoader sceneLoader)
        {
            _stateMachine = stateMachine;
            _logger = logger;
            _sceneLoader = sceneLoader;
        }

        public void Enter()
        {
            _logger.LogInfo($"Entered to State - {GetType().Name}, Scene - {SceneManager.GetActiveScene().name}");
            
            InitServices();
            _sceneLoader.Load(ScenesID.INIT, EnterLoadLevel);
        }

        private void InitServices()
        {
 
        }

        private void EnterLoadLevel() =>
            _stateMachine.Enter<LoadProgressState>();

        public void Exit() => 
            _logger.LogInfo($"Exited from State - {GetType().Name}, Scene - {SceneManager.GetActiveScene().name}");

        public class Factory : PlaceholderFactory<IGameStateMachine, BootstrapState>
        {
        }
    }
}