using _Scripts.Game.Services.Sound;
using _Scripts.Game.Services.Windows.Main;
using _Scripts.Game.UI.Curtain;
using _Scripts.Infrastructure.Scene;
using _Scripts.Infrastructure.Services.Settings;
using _Scripts.Infrastructure.Services.Sound;
using _Scripts.Infrastructure.Singleton;
using _Scripts.Infrastructure.StateMachines.App.FSM;
using _Scripts.Infrastructure.StateMachines.App.States;
using _Scripts.Infrastructure.StateMachines.Common;

namespace _Scripts.Infrastructure.Installer
{
    public class StateMachineInstaller : Common.Installer
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
            ISoundService soundService = AllServices.Container.GetSingle<ISoundService>();
            ISettingsService settingsService = AllServices.Container.GetSingle<ISettingsService>();
            CurtainPresenter curtainPresenter = AllServices.Container.GetSingle<CurtainPresenter>();
            
            InitializationState initializationState = AllServices.Container
                .RegisterSingle(new InitializationState(appStateMachine, soundService, settingsService));
            
            MainState mainState = AllServices.Container
                .RegisterSingle
                    (new MainState(appStateMachine, sceneLoaderService, windowService, curtainPresenter));
            
            StartState state = AllServices.Container
                .RegisterSingle
                    (new StartState(appStateMachine, windowService, sceneLoaderService, curtainPresenter));
        }
    }
}