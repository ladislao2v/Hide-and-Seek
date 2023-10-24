namespace Code.StateMachine.States
{
    public class GameLoopByHiderState : IEmptyState
    {
        private readonly GameStateMachine _stateMachine;

        public GameLoopByHiderState(GameStateMachine stateMachine)
        {
            _stateMachine = stateMachine;
        }

        public void Enter() 
        {
            
        }

        public void Exit() { }
    }
}