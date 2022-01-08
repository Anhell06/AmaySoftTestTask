using Assets.CodeBase.StateMachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class NextLevelTrigger : MonoBehaviour, IPointerClickHandler
{
    private bool isTrue = false;
    private IGameStateMachine _stateMachine;
    private CellMediator _mediator;

    public bool IsTrue { get => isTrue; set => isTrue = value; }

    public void Constract(CellMediator parent, IGameStateMachine stateMachine)
    {
        _stateMachine = stateMachine;
        _mediator = parent;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (isTrue)
            _mediator.PlayTrueAnimation();
        else
            _mediator.PlayFalseAnimation();
    }
}

