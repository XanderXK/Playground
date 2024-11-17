using System;
using UnityEngine;

namespace SimpleAIFSM
{
    [Serializable]

    public class FSMTransition
    {
        [field: SerializeField] public FSMDecision Decision { get; private set; }
        [field: SerializeField] public string TrueStateID { get; private set; }
        [field: SerializeField] public string FalseStateID { get; private set; }
    }
}