using UnityEngine;

namespace DesignPatterns.Behavioral.ChainOfResponsibility
{
    public abstract class SurfaceHandler
    {
        protected SurfaceHandler _next;

        public void SetNext(SurfaceHandler next)
        {
            _next = next;
        }

        public void TryHandle(string surface)
        {
            if (CanHandle(surface))
            {
                Run(surface);
            }
            else if (_next != null)
            {
                _next.TryHandle(surface);
            }
            else
            {
                Debug.Log("No handler found");
            }
        }

        protected abstract bool CanHandle(string surface);
        protected abstract void Run(string surface);
    }
}