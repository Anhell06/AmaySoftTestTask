using Assets.CodeBase.StateMachine.State;
using Assets.CodeBase.StaticData;
using System;
using UnityEngine;

namespace Assets.CodeBase.StateMachine
{
    public class LoadLevelState : IEnterInState
    {
        private IGameFactory _gameFactory;
        private IGameStateMachine _stateMachine;
        private IStaticDataService _staticDataService;

        public LoadLevelState(IGameStateMachine stateMachine, IGameFactory gameFactory, IStaticDataService staticData)
        {
            _stateMachine = stateMachine;
            _gameFactory = gameFactory;
            _staticDataService = staticData;
        }

        public void Enter()
        {
            _gameFactory.CreateField(_staticDataService.GetCurrentLevel());
            _stateMachine.Enter<GameLoopState>();
        }

        public void Exit()
        {
            _staticDataService.SetNextLevel();
        }
    }
}
