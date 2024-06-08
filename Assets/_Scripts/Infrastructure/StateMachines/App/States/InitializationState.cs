using _Scripts.Infrastructure.Singleton;
using _Scripts.Infrastructure.StateMachines.App.FSM;
using _Scripts.Infrastructure.StateMachines.Common.States;
using DG.Tweening;

namespace _Scripts.Infrastructure.StateMachines.App.States
{
    public class InitializationState : IState, IService
    {
        private readonly IAppStateMachine _appStateMachine;

        public InitializationState(IAppStateMachine appStateMachine)
        {
            _appStateMachine = appStateMachine;
        }

        public void Enter()
        {
            DOTween.Init();
            
            _appStateMachine.Enter<StartState>();
        }

        public void Exit()
        {
        }
    }
}