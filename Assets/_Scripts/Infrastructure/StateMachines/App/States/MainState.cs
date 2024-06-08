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
        
        private CurtainPresenter _curtain;
        
        public MainState(IAppStateMachine appStateMachine,
            ISceneLoaderService sceneLoaderService,
            CurtainPresenter curtainPresenter)
        {
            _appStateMachine = appStateMachine;
            _sceneLoaderService = sceneLoaderService;
            _curtain = curtainPresenter;
        }


        public async void Enter()
        {
            await _sceneLoaderService.LoadSceneAsync(SceneID.MainScene);
            await _curtain.DisableCurtain();
        }

        public void Exit()
        {
            
        }
    }
}