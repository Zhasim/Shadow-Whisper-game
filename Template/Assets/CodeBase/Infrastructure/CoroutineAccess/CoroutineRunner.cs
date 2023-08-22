using UnityEngine;

namespace CodeBase.Infrastructure.Foundation.CoroutineAccess
{
    public class CoroutineRunner : MonoBehaviour, ICoroutineRunner
    {
        private void Start() => 
            DontDestroyOnLoad(this);
    }
}