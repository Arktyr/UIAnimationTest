using _Scripts.Infrastructure.Singleton;
using _Scripts.Infrastructure.StateMachines.Common.States;

namespace _Scripts.Infrastructure.StateMachines.App.FSM
{
    public interface IAppStateMachine : IService
    {
        void Enter<TState>() where TState : IState;
        void Add<TState>(TState state) where TState : IExitableState;
    }
}