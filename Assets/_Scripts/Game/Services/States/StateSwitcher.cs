using _Scripts.Infrastructure.Installer.Common;
using _Scripts.Infrastructure.Singleton;
using _Scripts.Infrastructure.StateMachines.App.FSM;
using _Scripts.Infrastructure.StateMachines.App.States;
using _Scripts.Infrastructure.StateMachines.Common.States;
using UnityEngine;

namespace _Scripts.Game.Services.States
{
    public class StateSwitcher : IInjectable
    {
        private IAppStateMachine _appStateMachine;

        public override void Inject()
        {
            _appStateMachine = AllServices.Container.GetSingle<IAppStateMachine>();
        }

        public void SwitchState(StateID stateID)
        {
            switch (stateID)
            {
                case StateID.Initialize:
                    _appStateMachine.Enter<InitializationState>();
                    break;
                case StateID.Start:
                    _appStateMachine.Enter<StartState>();
                    break;
                case StateID.Main:
                    _appStateMachine.Enter<MainState>();
                    break;
                default:
                    Debug.LogError($"{stateID}: This State Not Found");
                    break;
            }
        }
    }
}