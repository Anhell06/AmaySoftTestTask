using Assets.CodeBase.StateMachine.State;
using Assets.CodeBase.StaticData;
using System;
using UnityEngine;

namespace Assets.CodeBase.StateMachine
{
    public class LoadLevelState : IEnterInState
    {
        private GameFactory _gameFactory;
        private IGameStateMachine _stateMachine;
        private IStaticDataService _staticDataService;

        public LoadLevelState(IGameStateMachine stateMachine, GameFactory gameFactory, IStaticDataService staticData)
        {
            _stateMachine = stateMachine;
            _gameFactory = gameFactory;
            _staticDataService = staticData;
        }

        public void Enter()
        {
            _gameFactory.CreateField(_staticDataService.GetCurrentLevel());
        }

        public void Exit()
        {
            _gameFactory.ClearField();
            _staticDataService.SetNextLevel();
        }
    }
}
