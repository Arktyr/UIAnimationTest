namespace _Scripts.Infrastructure.StateMachines.Common.States
{
    public interface IState : IExitableState
    { 
        void Enter();
    }
}