﻿using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using _Scripts.Extensions;
using _Scripts.Game.UI.Windows.Hello;
using _Scripts.Infrastructure.Scene;
using _Scripts.Infrastructure.Singleton;
using _Scripts.Infrastructure.StateMachines.App.FSM;
using _Scripts.Infrastructure.StateMachines.Common.States;
using _Scripts.UI.Windows;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace _Scripts.Infrastructure.StateMachines.App.States
{
    public class StartState : IState, IService
    {
        private readonly IAppStateMachine _appStateMachine;
        private readonly IWindowService _windowService;
        private readonly ISceneLoaderService _sceneLoaderService;
        
        private bool _isSetLocalDependencies;
        
        public StartState(IAppStateMachine appStateMachine,
            IWindowService windowService,
            ISceneLoaderService sceneLoaderService)
        {
            _appStateMachine = appStateMachine;
            _windowService = windowService;
            _sceneLoaderService = sceneLoaderService;
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