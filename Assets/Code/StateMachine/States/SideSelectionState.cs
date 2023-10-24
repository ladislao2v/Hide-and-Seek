using Code.Services.GameDataService;
using Code.Services.ResourceBankService;
using Code.Services.SaveLoadDataService.Data;
using Code.UI;
using UnityEngine;
using Zenject;

namespace Code.StateMachine.States
{
    public sealed class SideSelectionState : IEmptyState
    {
        private readonly GameStateMachine _gameStateMachine;
        private readonly SideSelectorView.Factory _sideSelectorViewFactory;
        private SideSelectorView _sideSelectorView;

        public SideSelectionState(GameStateMachine gameStateMachine, SideSelectorView.Factory sideSelectorViewFactory)
        {
            _gameStateMachine = gameStateMachine;
            _sideSelectorViewFactory = sideSelectorViewFactory;
        }

        public void Enter()
        {
            _sideSelectorView = _sideSelectorViewFactory.Create();
            
            _sideSelectorView.HideButton.onClick.AddListener(OnHideButtonClicked);
            _sideSelectorView.SeekButton.onClick.AddListener(OnSeekButtonClicked);
            
            _sideSelectorView.Show();
        }

        public void OnHideButtonClicked()
        {
            _gameStateMachine.Enter<GameLoopBySeekerState>();
        }

        public void OnSeekButtonClicked()
        {
            _gameStateMachine.Enter<GameLoopByHiderState>();
        }

        public void Exit()
        {
            _sideSelectorView.Hide();
            
            _sideSelectorView.HideButton.onClick.RemoveAllListeners();
            _sideSelectorView.SeekButton.onClick.RemoveAllListeners();
        }
    }
}