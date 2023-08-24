namespace CodeBase.Infrastructure.StateMachines.States
{
    public interface IPayloadState<TPayload> : IExitState
    { 
        void Enter(TPayload payload);
    }
}