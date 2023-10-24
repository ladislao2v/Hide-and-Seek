using System.Collections;
using UnityEngine;

namespace Code
{
    public interface ICoroutineRunner
    {
        Coroutine StartCoroutine(IEnumerator coroutine);
    }
}