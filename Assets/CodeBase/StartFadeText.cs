using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class StartFadeText : MonoBehaviour
{
    private void Start()
    {
        GetComponent<Text>().DOFade(1f, 2f);
    }
}
