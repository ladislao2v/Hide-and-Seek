using Code.Services.InputService;
using Code.UI;
using Code.Views.Player;
using UnityEngine;
using Zenject;

namespace Code.Installers
{
    public class LevelInstaller : MonoInstaller
    {
        [Header("Input")]
        [SerializeField] private Joystick _joystick;

        [Header("Player")] 
        [SerializeField] private Transform _spawnPoint;
        [SerializeField] private PlayerView _playerPrefab; 
        
        
        public override void InstallBindings()
        {
            BindJoystick();
            BindInputService();
            BindPlayer();
        }

        private void BindPlayer()
        {
            var player = Container.InstantiatePrefabForComponent<PlayerView>(
                _playerPrefab,
                _spawnPoint.position,
                Quaternion.identity,
                null);

            Container
                .Bind<PlayerView>()
                .FromInstance(player)
                .AsSingle();
        }

        private void BindInputService()
        {
            Container
                .Bind<IInputService>()
                .To<MobileInputService>()
                .AsSingle();
        }

        private void BindJoystick()
        {
            Container
                .Bind<Joystick>()
                .FromInstance(_joystick)
                .AsSingle()
                .NonLazy();
        }
    }
}