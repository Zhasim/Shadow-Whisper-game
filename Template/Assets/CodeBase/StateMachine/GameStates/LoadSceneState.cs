using CodeBase.Infrastructure.Foundation.Curtain;
using CodeBase.Infrastructure.Foundation.Loader;
using CodeBase.Infrastructure.Services.Factory;
using CodeBase.Infrastructure.Services.Progress.Service;
using CodeBase.Infrastructure.StateMachines.Machines;
using CodeBase.Infrastructure.StateMachines.States;
using UnityEngine.SceneManagement;
using Zenject;
using ILogger = CodeBase.Infrastructure.Services.CustomLogger.ILogger;

namespace CodeBase.Infrastructure.StateMachines.GameStates
{
    public class LoadSceneState : IPayloadState<string>
    {
        private readonly IGameStateMachine _stateMachine;
        private readonly ISceneLoader _sceneLoader;
        private readonly ILoadingCurtain _loadingCurtain;
        private readonly ILogger _logger;
        
        private readonly IProgressService _progressService;
        private readonly IGameFactory _gameFactory;

        public LoadSceneState(IGameStateMachine stateMachine, 
            ISceneLoader sceneLoader,
            ILoadingCurtain loadingCurtain,
            ILogger logger,
            IGameFactory gameFactory,
            IProgressService progressService)
        {
            _stateMachine = stateMachine;
            _sceneLoader = sceneLoader;
            _loadingCurtain = loadingCurtain;
            _logger = logger;
            _gameFactory = gameFactory;
            _progressService = progressService;
        }

        public void Enter(string sceneName)
        {
            _logger.LogInfo($"Entered to State - {GetType().Name}, Scene - {SceneManager.GetActiveScene().name}");
            _loadingCurtain.Show();
            _sceneLoader.Load(sceneName, OnLoaded);
        }

        private void OnLoaded()
        {
            InitGameWorld();
            _stateMachine.Enter<GameLoopState>();
        }

        private void InitGameWorld()
        {
            _logger.LogInfo("Game World INIT");
        }
        
        public void Exit()
        {
            _loadingCurtain.Hide();
            _logger.LogInfo($"Exited from State - {GetType().Name}, Scene - {SceneManager.GetActiveScene().name}");
        }
        
        public class Factory : PlaceholderFactory<IGameStateMachine, LoadSceneState>
        {
        }
    }
}