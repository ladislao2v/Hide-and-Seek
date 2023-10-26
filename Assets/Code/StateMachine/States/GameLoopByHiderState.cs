using Code.Services.CameraFollowService;
using Code.Services.InputService;
using Code.Views.Player;

namespace Code.StateMachine.States
{
    public sealed class GameLoopByHiderState : GameLoopState
    {
        public GameLoopByHiderState(
            IStateMachine stateMachine, 
            PlayerView.Factory playerFactory, 
            IInputService inputService, ICameraFollowService camera) : base(stateMachine, playerFactory, inputService, camera)
        {
        }
    }
}