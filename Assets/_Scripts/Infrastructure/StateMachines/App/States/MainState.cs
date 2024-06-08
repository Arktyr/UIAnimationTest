using _Scripts.Game.Services.Windows;
using _Scripts.Game.Services.Windows.Main;
using _Scripts.Game.UI.Curtain;
using _Scripts.Infrastructure.Scene;
using _Scripts.Infrastructure.Singleton;
using _Scripts.Infrastructure.StateMachines.App.FSM;
using _Scripts.Infrastructure.StateMachines.Common.States;

namespace _Scripts.Infrastructure.StateMachines.App.States
{
    public class MainState : IState, IService
    {
        private readonly IAppStateMachine _appStateMachine;
        private readonly ISceneLoaderService _sceneLoaderService;
        private readonly IWindowService _windowService;
        
        private readonly CurtainPresenter _curtain;
        
        public MainState(IAppStateMachine appStateMachine,
            ISceneLoaderService sceneLoaderService,
            IWindowService windowService,
            CurtainPresenter curtainPresenter)
        {
            _appStateMachine = appStateMachine;
            _sceneLoaderService = sceneLoaderService;
            _windowService = windowService;
            _curtain = curtainPresenter;
        }


        public void SetLocalDependencies(params IWindow[] windows)
        {
            foreach (var window in windows) 
                _windowService.AddWindow(window);
        }

        public async void Enter()
        {
            await _sceneLoaderService.LoadSceneAsync(SceneID.MainScene);
            
            await _curtain.DisableCurtain();
        }

        public async void Exit()
        {
            _windowService.ClearWindows();
            await _curtain.ShowCurtain();
        }
    }
}