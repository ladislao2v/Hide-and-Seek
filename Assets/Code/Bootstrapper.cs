using Code.Services.GameDataService;
using Code.Services.ResourceBankService;
using Code.Services.SaveLoadDataService;
using Code.StateMachine;
using Code.StateMachine.States;
using UnityEngine;
using Zenject;

namespace Code
{
    public class Bootstrapper : MonoBehaviour
    {
        private IStateMachine _stateMachine;
        private IGameDataService _gameDataService;
        private IResourceBankService _bankService;

        [Inject]
        private void Construct(IStateMachine stateMachine, IGameDataService dataService, IResourceBankService bankService)
        {
            _stateMachine = stateMachine;
            _gameDataService = dataService;
            _bankService = bankService;
        }
        
        private void Awake()
        {
            AddToGameDataService((ILoadable) _bankService);

            _stateMachine.Enter<LoadDataState>();
            
            DontDestroyOnLoad(this);
        }

        private void AddToGameDataService(params ILoadable[] loadables)
        {
            foreach (var loadable in loadables)
            {
                _gameDataService.Add(loadable);
            }
        }
    }
}