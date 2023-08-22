namespace CodeBase.Infrastructure.StateMachines.States
{
    public interface IState : IExitState
    {
       void Enter();
    }
}