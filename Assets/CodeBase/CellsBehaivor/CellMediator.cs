using Assets.CodeBase.StateMachine;
using DG.Tweening;
using System;
using UnityEngine;
using UnityEngine.Events;

public class CellMediator : MonoBehaviour
{
    private SpriteController _spriteController;
    private NextLevelTrigger _nextLevelTrigger;
    private SquareAnimator _squareAnimator;

    public UnityAction LevelEnded;

    private void Awake()
    {
        _spriteController = GetComponentInChildren<SpriteController>();
        _nextLevelTrigger = GetComponent<NextLevelTrigger>();
        _squareAnimator = GetComponentInChildren<SquareAnimator>();
    }
    private void Start()
    {
        _nextLevelTrigger.Constract(this);
    }
    public void UpdateSprite(Sprite sprite, float spriteRotation) => _spriteController.UpdateSprite(sprite, spriteRotation);
    public void SetTrue() => _nextLevelTrigger.IsTrue = true;
    public void PlayTrueAnimation() => _squareAnimator.PlayTrueAnimation(LevelEnded);
    public void PlayFalseAnimation() => _squareAnimator.PlayFalseAnimation();
    public void Bounce() => transform.DOScale(Vector3.one * 4, 2);

}