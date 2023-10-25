using Code.Factories.StateFactory;

namespace Code.StateMachine
{
    public sealed class GameStateMachine : StateMachine
    {
        public GameStateMachine(IStatesFactory statesFactory) : base(statesFactory) { }
    }
}