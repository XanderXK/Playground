using UnityEngine;

namespace SimpleAIFSM
{
    public abstract class FSMDecision : MonoBehaviour
    {
        public abstract bool Decide();
    }
}