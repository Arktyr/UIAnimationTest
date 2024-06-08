using _Scripts.Infrastructure.Singleton;
using _Scripts.Infrastructure.StateMachines.App.FSM;
using _Scripts.Infrastructure.StateMachines.Common.States;

namespace _Scripts.Infrastructure.StateMachines.App.States
{
    public class StartState : IState, IService
    {
        private IAppStateMachine _appStateMachine;
        
        public StartState(IAppStateMachine appStateMachine)
        {
            _appStateMachine = appStateMachine;
        }

        public void Enter()
        {
        }

        public void Exit()
        {
        }
    }
}