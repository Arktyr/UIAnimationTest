using _Scripts.Infrastructure.Installer.Common;
using _Scripts.Infrastructure.Singleton;
using _Scripts.Infrastructure.StateMachines.App.FSM;
using _Scripts.Infrastructure.StateMachines.App.States;

namespace _Scripts.Infrastructure.Bootstrappers
{
    public class AppBootstrapper : IInjectable
    {
        private IAppStateMachine _appStateMachine;
        
        public override void Inject()
        {
            _appStateMachine = AllServices.Container.GetSingle<IAppStateMachine>();

            InitializationState initializationState = AllServices.Container.GetSingle<InitializationState>();
            MainState mainState = AllServices.Container.GetSingle<MainState>();
            StartState startState = AllServices.Container.GetSingle<StartState>();
            
            _appStateMachine.Add(initializationState);
            _appStateMachine.Add(mainState);
            _appStateMachine.Add(startState);
        }
        
        private void Start() => 
            _appStateMachine.Enter<InitializationState>();
    }
}