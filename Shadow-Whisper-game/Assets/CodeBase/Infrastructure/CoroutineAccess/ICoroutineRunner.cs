using System.Collections;
using UnityEngine;

namespace CodeBase.Infrastructure.Foundation.CoroutineAccess
{
    public interface ICoroutineRunner
    {
        Coroutine StartCoroutine(IEnumerator coroutine);
        void StopCoroutine(Coroutine coroutine);
    }
}