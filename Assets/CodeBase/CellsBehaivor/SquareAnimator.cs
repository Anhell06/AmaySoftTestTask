using DG.Tweening;
using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class SquareAnimator : MonoBehaviour
{
    [SerializeField]
    private ParticleSystem _star;

    public void PlayTrueAnimation(UnityAction onEnded)
    {
        StartCoroutine(PlayAnimation(onEnded));
    }

    private IEnumerator PlayAnimation(UnityAction onEnded)
    {
        var particl = Instantiate(_star, transform.position, Quaternion.identity);
        yield return new WaitForSeconds(particl.duration + particl.startLifetime);
        onEnded?.Invoke();
    }

    public void PlayFalseAnimation()
    {
        transform.DOShakePosition(1, new Vector3(.07f, 0, 0)).SetEase(Ease.InBounce);
    }
}