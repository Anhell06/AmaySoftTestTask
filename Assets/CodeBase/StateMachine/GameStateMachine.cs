using Assets.CodeBase.AssetLoader;
using Assets.CodeBase.Infracstructure;
using Assets.CodeBase.StateMachine.State;
using Assets.CodeBase.StaticData;
using System;
using System.Collections.Generic;

namespace Assets.CodeBase.StateMachine
{
    internal class GameStateMachine : IGameStateMachine
    {
        Dictionary<Type, IExitableState> _states;
        IExitableState _activeState;
        public GameStateMachine(IServiceLocator service)
        {
            _states = new Dictionary<Type, IExitableState>()
            {
                [typeof(BootstrapState)] = new BootstrapState(this, service),
                [typeof(LoadLevelState)] = new LoadLevelState(this, 
                new GameFactory(service.GetService<IStaticDataService>(), service.GetService<IAssetProvider>(), this),
                service.GetService<IStaticDataService>())
                //[typeof(GameLoopState)] = new GameLoopState()
            };


        }
        public void Enter<TState>() where TState : class, IEnterInState
        {
            TState state = ChangeState<TState>();
            state.Enter();
        }
        public void Enter<TState, TPayLoad>(TPayLoad payLoad) where TState : class, IEnterInStatePayload<TPayLoad>
        {
            TState state = ChangeState<TState>();
            state.Enter(payLoad);
        }

        private TState ChangeState<TState>() where TState : class, IExitableState
        {
            _activeState?.Exit();

            TState state = GetState<TState>();
            _activeState = state;
            return state;
        }

        private TState GetState<TState>() where TState : class, IExitableState
        {
            return _states[typeof(TState)] as TState;
        }

    }
}