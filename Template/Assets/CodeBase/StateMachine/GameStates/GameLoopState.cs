using CodeBase.Infrastructure.StateMachines.Machines;
using CodeBase.Infrastructure.StateMachines.States;
using UnityEngine.SceneManagement;
using Zenject;
using ILogger = CodeBase.Infrastructure.Services.CustomLogger.ILogger;

namespace CodeBase.Infrastructure.StateMachines.GameStates
{
    public class GameLoopState : IState, IInitializable, ITickable
    {
        private readonly IGameStateMachine _gameStateMachine;
        private readonly ILogger _logger;
        
        public GameLoopState(IGameStateMachine gameStateMachine, 
            ILogger logger)
        {
            _gameStateMachine = gameStateMachine;
            _logger = logger;
        }

        public void Initialize()
        {
            
        }

        public void Enter()
        {
            _logger.LogInfo($"State - {GetType().Name}, Scene - {SceneManager.GetActiveScene().name}");
        }

        public void Exit()
        {
        }

        public void Tick()
        {
            
        }

        public class Factory : PlaceholderFactory<IGameStateMachine, GameLoopState>
        {
        }
    }
}