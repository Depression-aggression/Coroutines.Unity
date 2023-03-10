using Depra.Coroutines.Domain.Entities;
using UnityEngine;

namespace Depra.Coroutines.Unity.Runtime
{
    public sealed class RuntimeCoroutine : ICoroutine 
    {
        private readonly RuntimeCoroutineHost _host;
        
        private Coroutine _coroutine;

        public RuntimeCoroutine(RuntimeCoroutineHost host, Coroutine coroutine)
        {
            _host = host;
            _coroutine = coroutine;
        }
        
        public bool IsDone => _coroutine == null;
        
        public void Stop()
        {
            if (IsDone)
            {
                return;
            }
            
            _host.StopCoroutine(_coroutine);
            _coroutine = null;
        }
    }
}