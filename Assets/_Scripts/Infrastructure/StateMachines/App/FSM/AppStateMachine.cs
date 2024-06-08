using _Scripts.Infrastructure.StateMachines.Common.States;
using UnityEngine;

namespace _Scripts.Infrastructure.StateMachines.App.FSM
{
    public class AppStateMachine : IAppStateMachine
    {
        private readonly Common.StateMachine _stateMachine;

        public AppStateMachine(Common.StateMachine stateMachine)
        {
            _stateMachine = stateMachine;
        }

        public void Enter<TState>() where TState : IState
        {
            _stateMachine.Enter<TState>();
            Debug.LogError($"Enter In : {typeof(TState).Name}");
        }

        public void Add<TState>(TState state) where TState : IExitableState =>
            _stateMachine.AddState(state);
    }
}