using System;
using Code.Services.LoadSceneService;

namespace Code.StateMachine.States
{
    public sealed class LoadLevelState : IPayloadState<string>
    {
        private readonly GameStateMachine _stateMachine;
        private readonly ILoadSceneService _loadSceneService;

        public LoadLevelState(GameStateMachine stateMachine, ILoadSceneService loadSceneService)
        {
            _stateMachine = stateMachine;
            _loadSceneService = loadSceneService;
        }


        public void Enter(string sceneName)
        {
            _loadSceneService.Load(sceneName, OnLoadNewLevel);
        }

        private void OnLoadNewLevel()
        {
            _stateMachine.Enter<SideSelectionState>();
        }

        public void Exit() { }
    }
}