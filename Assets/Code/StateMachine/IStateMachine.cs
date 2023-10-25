using Code.StateMachine.States;

namespace Code.StateMachine
{
    public interface IStateMachine
    {
        void Enter<TState>() where TState : class, IEmptyState;
        void Enter<TState, TPayload>(TPayload payload) where TState : class, IPayloadState<TPayload>;
    }
}