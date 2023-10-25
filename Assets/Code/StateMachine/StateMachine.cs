using Code.Factories.StateFactory;
using Code.StateMachine.States;

namespace Code.StateMachine
{
    public abstract class StateMachine : IStateMachine
    {
        private readonly IStatesFactory _statesFactory;
        private IState _currentState;

        public StateMachine(IStatesFactory statesFactory)
        {
            _statesFactory = statesFactory;
        }

        public void Enter<TState>() where TState : class, IEmptyState
        {
            TState state = ChangeState<TState>();
            state.Enter();
        }
        
        public void Enter<TState, TPayload>(TPayload payload) where TState : class, IPayloadState<TPayload>
        {
            TState state = ChangeState<TState>();
            state.Enter(payload);
        }

        private TState ChangeState<TState>() where TState : class, IState
        {
            _currentState?.Exit(); 
            TState state = _statesFactory.Create<TState>() as TState;
            _currentState = state;

            return state;
        }
    }
}
