using _Scripts.Game.UI.Windows.Hello;
using _Scripts.Infrastructure.Installer.Common;
using _Scripts.Infrastructure.Singleton;
using _Scripts.Infrastructure.StateMachines.App.States;
using UnityEngine;

namespace _Scripts.Infrastructure.Bootstrappers
{
    public class StartBootstrapper : IInjectable
    {
        [SerializeField] private HelloWindow _helloWindow;

        private StartState _startState;

        public override void Inject()
        {
            _startState = AllServices.Container.GetSingle<StartState>();

            _startState.SetLocalDependencies(_helloWindow);
        }
    }
}