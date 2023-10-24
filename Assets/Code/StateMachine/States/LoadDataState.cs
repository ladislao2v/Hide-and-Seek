using Code.Services.GameDataService;
using Code.Services.LoadSceneService;

namespace Code.StateMachine.States
{
    public sealed class LoadDataState : IEmptyState
    {
        private readonly GameStateMachine _stateMachine;
        private readonly IGameDataService _gameDataService;

        public LoadDataState(GameStateMachine stateMachine, IGameDataService gameDataService)
        {
            _stateMachine = stateMachine;
            _gameDataService = gameDataService;
        }

        public void Enter()
        {
            _gameDataService.LoadData();
            
            _stateMachine.Enter<LoadLevelState,string>(LevelNames.Level1);
        }

        public void Exit() { }
    }
}