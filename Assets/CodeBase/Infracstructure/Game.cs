using Assets.CodeBase.Infracstructure;
using Assets.CodeBase.StateMachine;

internal class Game
{
    public GameStateMachine StateMachine;

    public Game()
    {
        StateMachine = new GameStateMachine(new ServiceLocator());
    }
}