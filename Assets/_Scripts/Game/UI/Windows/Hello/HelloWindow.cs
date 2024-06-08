using _Scripts.Game.Animations.Window;
using _Scripts.Infrastructure.Installer;
using _Scripts.Infrastructure.Singleton;
using _Scripts.Infrastructure.StateMachines.App.FSM;
using _Scripts.Infrastructure.StateMachines.App.States;
using _Scripts.UI.Windows;
using UnityEngine;

namespace _Scripts.Game.UI.Windows.Hello
{
    public class HelloWindow : IInjectable, IWindow
    {
        [SerializeField] private WindowAnimation _windowAnimation;
        
        private IAppStateMachine _appStateMachine;

        public override void Inject()
        {
            _appStateMachine = AllServices.Container.GetSingle<IAppStateMachine>();
        }

        public async void Open()
        {
            gameObject.SetActive(true);
            await _windowAnimation.ShowWindow();
        }

        public async void Close()
        {
            await _windowAnimation.HideWindow();
            gameObject.SetActive(false);
            
            _appStateMachine.Enter<MainState>();
        }
    }
}