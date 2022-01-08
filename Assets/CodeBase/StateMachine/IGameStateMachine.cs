using Assets.CodeBase.StateMachine.State;

namespace Assets.CodeBase.StateMachine
{
    public interface IGameStateMachine
    {
        void Enter<TState, TPayLoad>(TPayLoad payLoad) where TState : class, IEnterInStatePayload<TPayLoad>;
        void Enter<TState>() where TState : class, IEnterInState;
    }
}