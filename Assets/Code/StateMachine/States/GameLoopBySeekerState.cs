using Code.Services.InputService;

namespace Code.StateMachine.States
{
    public sealed class GameLoopBySeekerState : IEmptyState
    {
        private readonly IStateMachine _stateMachine;

        public GameLoopBySeekerState(GameStateMachine gameStateMachine)
        {
            _stateMachine = gameStateMachine;
        }

        public void Enter()
        {
        }

        public void Exit() { }
    }
}