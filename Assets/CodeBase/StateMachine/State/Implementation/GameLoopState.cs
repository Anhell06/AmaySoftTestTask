using Assets.CodeBase.StateMachine.State;
using System;

namespace Assets.CodeBase.StateMachine
{
    internal class GameLoopState : IEnterInState
    {
        private GameStateMachine _gameStateMachine;
        private IGameFactory _gameFactory;

        public GameLoopState(GameStateMachine gameStateMachine, IGameFactory gameFactory)
        {
            _gameStateMachine = gameStateMachine;
            _gameFactory = gameFactory;
        }

        private void LevelEnded()
        {
            _gameStateMachine.Enter<LoadLevelState>();
        }

        public void Enter()
        {
            _gameFactory.TrueCell.GetComponent<CellMediator>().LevelEnded += LevelEnded;
        }

        public void Exit()
        {
            _gameFactory.ClearField();
        }
    }
}