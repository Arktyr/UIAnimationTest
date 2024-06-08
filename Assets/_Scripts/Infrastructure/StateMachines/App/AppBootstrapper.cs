using _Scripts.Infrastructure.Installer;
using _Scripts.Infrastructure.Singleton;
using _Scripts.Infrastructure.StateMachines.App.FSM;
using _Scripts.Infrastructure.StateMachines.App.States;

namespace _Scripts.Infrastructure.StateMachines.App
{
    public class AppBootstrapper : IInjectable
    {
        private IAppStateMachine _appStateMachine;
        
        public override void Inject()
        {
            _appStateMachine = AllServices.Container.GetSingle<IAppStateMachine>();
        }
        
        private void Start() => 
            _appStateMachine.Enter<InitializationState>();
    }
}