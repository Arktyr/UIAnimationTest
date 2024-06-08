﻿using _Scripts.Infrastructure.Scene;
using _Scripts.Infrastructure.Singleton;
using _Scripts.Infrastructure.StateMachines.App;
using _Scripts.Infrastructure.StateMachines.App.FSM;
using _Scripts.Infrastructure.StateMachines.App.States;
using _Scripts.Infrastructure.StateMachines.Common;
using _Scripts.UI.Windows;

namespace _Scripts.Infrastructure.Installer
{
    public class StateMachineInstaller : Installer
    {
        public override void Install()
        {
            IAppStateMachine appStateMachine = BindStateMachine();
            BindStates(appStateMachine);
        }

        private IAppStateMachine BindStateMachine()
        {
            StateMachine stateMachine = new StateMachine();
            
            IAppStateMachine appStateMachine = AllServices.Container
                .RegisterSingle<IAppStateMachine>(new AppStateMachine(stateMachine));

            return appStateMachine;
        }

        private void BindStates(IAppStateMachine appStateMachine)
        {
            IWindowService windowService = AllServices.Container.GetSingle<IWindowService>();
            ISceneLoaderService sceneLoaderService = AllServices.Container.GetSingle<ISceneLoaderService>();
            
            InitializationState initializationState = AllServices.Container
                .RegisterSingle(new InitializationState(appStateMachine));
            
            MainState mainState = AllServices.Container
                .RegisterSingle(new MainState(appStateMachine));
            
            StartState state = AllServices.Container
                .RegisterSingle(new StartState(appStateMachine, windowService, sceneLoaderService));
        }
    }
}