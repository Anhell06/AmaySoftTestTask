using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonScript : MonoBehaviour
{
    [SerializeField]
    private GameObject _button;

    public void Restart()
    {
        SceneManager.LoadScene(0);
    }

    public void ButtonActive()
    {
        _button.gameObject.SetActive(true);
    }
}
