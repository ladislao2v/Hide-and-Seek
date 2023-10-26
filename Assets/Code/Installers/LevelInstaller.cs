﻿using Code.Factories.StateFactory;
using Code.Services.CameraFollowService;
using Code.Services.InputService;
using Code.StateMachine;
using Code.UI;
using Code.Views.Player;
using UnityEngine;
using Zenject;

namespace Code.Installers
{
    public class LevelInstaller : MonoInstaller
    {
        [Header("Units")]
        [SerializeField] private PlayerView _playerPrefab;

        [Header("Camera")] 
        [SerializeField] private CameraFollower _camera;
        
        [Header("Input")]
        [SerializeField] private Joystick _joystick;

        [Header("UI")]
        [SerializeField] private SideSelectorView _sideSelectorView;

        public override void InstallBindings()
        {
            BindCameraFollowService();
            BindInputService();
            BindSideSelectorView();
            BindPlayerFactory();
            BindStateMachine();
        }

        private void BindCameraFollowService() =>
            Container
                .Bind<ICameraFollowService>()
                .To<CameraFollower>()
                .FromInstance(_camera)
                .AsSingle()
                .NonLazy();

        private void BindPlayerFactory() => 
            Container
                .BindFactory<PlayerView, PlayerView.Factory>()
                .FromComponentInNewPrefab(_playerPrefab);

        private void BindSideSelectorView() =>
            Container
                .Bind<SideSelectorView>()
                .FromInstance(_sideSelectorView)
                .AsSingle();

        private void BindStateMachine()
        {
            Container
                .BindInterfacesAndSelfTo<StatesFactory>()
                .AsSingle();
            
            Container
                .Bind<IStateMachine>()
                .To<SceneStateMachine>()
                .AsSingle();
        }

        private void BindInputService() =>
            Container
                .Bind<IInputService>()
                .To<MobileInputService>()
                .AsSingle()
                .WithArguments(_joystick)
                .NonLazy();
    }
}