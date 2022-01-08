using System.Collections;
using UnityEngine;

public interface ICoroutinRunner
{
    Coroutine StartCoroutine(string methodName);
    Coroutine StartCoroutine(IEnumerator routine);
}