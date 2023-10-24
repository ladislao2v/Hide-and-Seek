using Code.Services.GameDataService;
using Code.Services.LoadSceneService;
using Code.Services.ResourceBankService;
using Code.Services.SaveLoadDataService;
using Code.StateMachine;
using Code.UI;
using UnityEngine;
using Zenject;

namespace Code.Installers
{
    public class BootstrapInstaller : MonoInstaller
    {
        [SerializeField] private CoroutineRunner _coroutineRunnerPrefab;
        [SerializeField] private SideSelectorView _sideSelectorView;

        public override void InstallBindings()
        {
            BindSideSelectorViewFactory();
            BindCoroutineRunner();
            BindLoadSceneService();
            BindSaveLoadDataService();
            BindDataService();
            BindResourceBankService();
            BindStateMachine();
        }

        private void BindSideSelectorViewFactory()
        {
            Container
                .BindFactory<SideSelectorView, SideSelectorView.Factory>()
                .FromComponentInNewPrefab(_sideSelectorView);
        }

        private void BindStateMachine() =>
            Container
                .Bind<GameStateMachine>()
                .AsSingle();

        private void BindResourceBankService() =>
            Container
                .Bind<IResourceBankService>()
                .To<CoinBank>()
                .AsSingle();

        private void BindDataService() =>
            Container
                .Bind<IGameDataService>()
                .To<GameDataService>()
                .AsSingle();

        private void BindLoadSceneService() =>
            Container
                .Bind<ILoadSceneService>()
                .To<SceneLoader>()
                .AsSingle();

        private void BindSaveLoadDataService() =>
            Container
                .Bind<ISaveLoadDataService>()
                .To<SaveLoadDataService>()
                .AsSingle();

        private void BindCoroutineRunner()
        {
            var coroutineRunner = Container
                .InstantiatePrefabForComponent<CoroutineRunner>(_coroutineRunnerPrefab);

            Container
                .Bind<ICoroutineRunner>()
                .To<CoroutineRunner>()
                .FromInstance(coroutineRunner);
        }
    }
}