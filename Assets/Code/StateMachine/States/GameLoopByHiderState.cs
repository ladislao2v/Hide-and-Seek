using Code.Services.InputService;
using Code.Views.Player;

namespace Code.StateMachine.States
{
    public class GameLoopByHiderState : IEmptyState
    {
        private readonly IStateMachine _stateMachine;
        private readonly PlayerView.Factory _playerFactory;
        private readonly IInputService _inputService;

        public GameLoopByHiderState(IStateMachine stateMachine, PlayerView.Factory playerFactory, IInputService inputService)
        {
            _stateMachine = stateMachine;
            _playerFactory = playerFactory;
            _inputService = inputService;
        }

        public void Enter()
        {
            _playerFactory.Create();
            
            _inputService.Enable();
        }

        public void Exit()
        {
            _inputService.Disable();
        }
    }
}