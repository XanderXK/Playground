using System;
using UnityEngine;

namespace ThirdPersonFSM
{
    public class Target : MonoBehaviour
    {
        public event Action<Target> OnDisabled;

        private void OnDisable()
        {
            OnDisabled?.Invoke(this);
        }
    }
}