using Code.UI;

namespace Code.StateMachine.States
{
    public sealed class SideSelectionState : IEmptyState
    {
        private readonly IStateMachine _stateMachine;
        private readonly SideSelectorView _sideSelectorView;

        public SideSelectionState(IStateMachine stateMachine, SideSelectorView sideSelectorView)
        {
            _stateMachine = stateMachine;
            _sideSelectorView = sideSelectorView;
        }

        public void Enter()
        {
            _sideSelectorView.HideButton.onClick.AddListener(OnHideButtonClicked);
            _sideSelectorView.SeekButton.onClick.AddListener(OnSeekButtonClicked);
            
            _sideSelectorView.Show();
        }

        public void OnHideButtonClicked()
        {
            _stateMachine.Enter<GameLoopByHiderState>();
        }

        public void OnSeekButtonClicked()
        {
            _stateMachine.Enter<GameLoopBySeekerState>();
        }

        public void Exit()
        {
            _sideSelectorView.Hide();
            
            _sideSelectorView.HideButton.onClick.RemoveAllListeners();
            _sideSelectorView.SeekButton.onClick.RemoveAllListeners();
        }
    }
}