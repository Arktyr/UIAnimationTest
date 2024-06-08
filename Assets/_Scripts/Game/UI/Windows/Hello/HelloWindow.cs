using _Scripts.Game.Animations.Window;
using _Scripts.Game.UI.Curtain;
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
        private CurtainPresenter _curtain;


        public override void Inject()
        {
            _appStateMachine = AllServices.Container.GetSingle<IAppStateMachine>();
            _curtain = AllServices.Container.GetSingle<CurtainPresenter>();
        }

        public void Open()
        {
            gameObject.SetActive(true);
            _windowAnimation.ShowWindow(default);
        }

        public void Close() => 
            _windowAnimation.HideWindow(OnHideWindow);

        private async void OnHideWindow()
        {
            gameObject.SetActive(false);
            
            await _curtain.ShowCurtain();
            _appStateMachine.Enter<MainState>();
        }
    }
}