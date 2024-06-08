namespace _Scripts.Infrastructure.StateMachines.Common.States
{
    public interface IStateWithArgument<in TArgs> : IExitableState
    {
        void Enter(TArgs args);
    }
}