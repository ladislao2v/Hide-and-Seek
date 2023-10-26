using Code.Services.CameraFollowService;
using Code.Services.InputService;
using Code.Views.Player;

namespace Code.StateMachine.States
{
    public abstract class GameLoopState : IEmptyState
    {
        private readonly IStateMachine _stateMachine;
        private readonly PlayerView.Factory _playerFactory;
        private readonly IInputService _inputService;
        private readonly ICameraFollowService _camera;

        protected GameLoopState(IStateMachine stateMachine, PlayerView.Factory playerFactory, IInputService inputService, ICameraFollowService camera)
        {
            _stateMachine = stateMachine;
            _playerFactory = playerFactory;
            _inputService = inputService;
            _camera = camera;
        }

        public void Enter()
        {
            var player = _playerFactory.Create();
            _camera.SetTarget(player.transform);
            
            _inputService.Enable();
        }

        public void Exit()
        {
            _inputService.Disable();
        }
    }
}