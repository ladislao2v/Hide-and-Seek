using Code.Factories.StateFactory;

namespace Code.StateMachine
{
    public sealed class SceneStateMachine : StateMachine
    {
        public SceneStateMachine(IStatesFactory statesFactory) : base(statesFactory) { }
    }
}