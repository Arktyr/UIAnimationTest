﻿using _Scripts.Extensions;
using _Scripts.Game.Services.Windows;
using _Scripts.Game.Services.Windows.Main;
using _Scripts.Game.UI.Curtain;
using _Scripts.Game.UI.Windows.Hello;
using _Scripts.Infrastructure.Scene;
using _Scripts.Infrastructure.Singleton;
using _Scripts.Infrastructure.StateMachines.App.FSM;
using _Scripts.Infrastructure.StateMachines.Common.States;

namespace _Scripts.Infrastructure.StateMachines.App.States
{
    public class StartState : IState, IService
    {
        private readonly IAppStateMachine _appStateMachine;
        private readonly IWindowService _windowService;
        private readonly ISceneLoaderService _sceneLoaderService;
        
        private readonly CurtainPresenter _curtain;
        
        private bool _isSetLocalDependencies;
        
        public StartState(IAppStateMachine appStateMachine,
            IWindowService windowService,
            ISceneLoaderService sceneLoaderService,
            CurtainPresenter curtainPresenter)
        {
            _appStateMachine = appStateMachine;
            _windowService = windowService;
            _sceneLoaderService = sceneLoaderService;

            _curtain = curtainPresenter;
        }

        public void SetLocalDependencies(params IWindow[] windows)
        {
            foreach (var window in windows) 
                _windowService.AddWindow(window);

            _isSetLocalDependencies = true;
        }
        
        public async void Enter()
        {
            await _sceneLoaderService.LoadSceneAsync(SceneID.StartScene);

            await AsyncOpertions.GetAwaitBool(() => _isSetLocalDependencies);
            
            _windowService.Open<HelloWindow>();
        }

        public void Exit()
        {
            _windowService.ClearWindows();

            _isSetLocalDependencies = false;
        }
    }
}