using Code.Services.LoadSceneService;

namespace Code.StateMachine.States
{
    public sealed class LoadLevelState : IPayloadState<string>
    {
        private readonly IStateMachine _stateMachine;
        private readonly ILoadSceneService _loadSceneService;

        public LoadLevelState(IStateMachine stateMachine, ILoadSceneService loadSceneService)
        {
            _stateMachine = stateMachine;
            _loadSceneService = loadSceneService;
        }


        public void Enter(string sceneName)
        {
            _loadSceneService.Load(sceneName);
        }

        public void Exit() { }
    }
}