using _Scripts.Infrastructure.Singleton;
using _Scripts.Infrastructure.StateMachines.App;
using _Scripts.Infrastructure.StateMachines.App.FSM;
using _Scripts.Infrastructure.StateMachines.App.States;
using _Scripts.Infrastructure.StateMachines.Common;

namespace _Scripts.Infrastructure.Installer
{
    public class StateMachineInstaller : Installer
    {
        public override void Install()
        {
            BindStateMachine();
        }

        private void BindStateMachine()
        {
            StateMachine stateMachine = new StateMachine();
            
            IAppStateMachine appStateMachine = AllServices.Container
                .RegisterSingle<IAppStateMachine>(new AppStateMachine(stateMachine));
            
            InitializationState initializationState = AllServices.Container
                .RegisterSingle(new InitializationState(appStateMachine));
            
            MainState mainState = AllServices.Container
                .RegisterSingle(new MainState(appStateMachine));
            
            StartState state = AllServices.Container
                .RegisterSingle(new StartState(appStateMachine));
            

            appStateMachine.Add(initializationState);
            appStateMachine.Add(mainState);
            appStateMachine.Add(state);
        }
    }
}