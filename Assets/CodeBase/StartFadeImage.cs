using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class StartFadeImage : MonoBehaviour
{
    private void Start()
    {
        GetComponent<Image>().DOFade(1f, 2f);
    }

}
