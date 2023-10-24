using Code.Services.InputService;

namespace Code.StateMachine.States
{
    public sealed class GameLoopBySeekerState : IEmptyState
    {
        private readonly GameStateMachine _gameStateMachine;
        private readonly IInputService _inputService;

        public GameLoopBySeekerState(GameStateMachine gameStateMachine, IInputService inputService)
        {
            _gameStateMachine = gameStateMachine;
            _inputService = inputService;
        }

        public void Enter()
        {
            _inputService.Enable();
        }

        public void Exit()
        {
            _inputService.Disable();
        }
    }
}