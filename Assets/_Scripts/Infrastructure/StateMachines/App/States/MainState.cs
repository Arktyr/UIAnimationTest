using _Scripts.Infrastructure.Singleton;
using _Scripts.Infrastructure.StateMachines.App.FSM;
using _Scripts.Infrastructure.StateMachines.Common.States;

namespace _Scripts.Infrastructure.StateMachines.App.States
{
    public class MainState : IState, IService
    {
        private readonly IAppStateMachine _appStateMachine;
        
        public MainState(IAppStateMachine appStateMachine)
        {
        }


        public void Exit()
        {
            
        }

        public void Enter()
        {
        }
    }
}