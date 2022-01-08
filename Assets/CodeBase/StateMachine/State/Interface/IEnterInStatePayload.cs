namespace Assets.CodeBase.StateMachine.State
{
    public interface IEnterInStatePayload<TPayload> : IExitableState
    {
        void Enter(TPayload payload);
    }
}
