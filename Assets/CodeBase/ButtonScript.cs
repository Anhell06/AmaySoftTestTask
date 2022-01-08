using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

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
