namespace Code.StateMachine.States
{
    public interface IState
    {
        void Exit();
    }

    public interface IEmptyState : IState
    {
        void Enter();   
    }

    public interface IPayloadState<TPayload> : IState
    {
        void Enter(TPayload payload);
    }
}