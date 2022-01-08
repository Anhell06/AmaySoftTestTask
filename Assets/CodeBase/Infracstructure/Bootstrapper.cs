﻿using Assets.CodeBase.StateMachine.State;
using UnityEngine;

public class Bootstrapper : MonoBehaviour, ICoroutinRunner
{
    private Game _game;

    private void Awake()
    {
        _game = new Game();
        _game.StateMachine.Enter<BootstrapState>();
        DontDestroyOnLoad(this);
    }
}
