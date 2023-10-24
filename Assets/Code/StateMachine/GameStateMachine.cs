using System;
using System.Collections.Generic;
using Code.Services.GameDataService;
using Code.Services.InputService;
using Code.Services.LoadSceneService;
using Code.StateMachine.States;
using Code.UI;

namespace Code.StateMachine
{
    public sealed class GameStateMachine
    {
        private readonly Dictionary<Type, IState> _states;
        private IState _currentState;

        public GameStateMachine(IGameDataService gameDataService,
            ILoadSceneService loadSceneService, 
            SideSelectorView.Factory sideSelectorViewFactory,
            IInputService inputService)
        {
            _states = new Dictionary<Type, IState>()
            {
                [typeof(LoadDataState)] = new LoadDataState(this, gameDataService),
                [typeof(LoadLevelState)] = new LoadLevelState(this, loadSceneService),
                [typeof(SideSelectionState)] = new SideSelectionState(this, sideSelectorViewFactory),
                [typeof(GameLoopBySeekerState)] = new GameLoopBySeekerState(this, inputService),
                [typeof(GameLoopByHiderState)] = new GameLoopByHiderState(this),
            };
        }

        public void Enter<TState>() where TState : class, IEmptyState
        {
            TState state = ChangeState<TState>();
            state.Enter();
        }
        
        public void Enter<TState, TPayload>(TPayload payload) where TState : class, IPayloadState<TPayload>
        {
            TState state = ChangeState<TState>();
            state.Enter(payload);
        }

        private TState ChangeState<TState>() where TState : class, IState
        {
            if (_states.ContainsKey(typeof(TState)) == false)
                throw new Exception(typeof(TState).ToString());
            
            _currentState?.Exit(); 
            TState state = _states[typeof(TState)] as TState;
            _currentState = state;

            return state;
        }
    }
}
