using System;
using UnityEngine;

namespace SimpleAIFSM
{
    [Serializable]
    public class FSMState
    {
        [field: SerializeField] public string ID { get; private set; }
        [field: SerializeField] public FSMAction[] Actions { get; private set; }
        [field: SerializeField] public FSMTransition[] Transitions { get; private set; }


        public void UpdateState(AI ai)
        {
            ExecuteActions();
            ExecuteTransitions(ai);
        }

        private void ExecuteActions()
        {
            foreach (var action in Actions)
            {
                action.Act();
            }
        }

        private void ExecuteTransitions(AI ai)
        {
            if (Transitions is null)
            {
                return;
            }

            foreach (var transition in Transitions)
            {
                var decisionValue = transition.Decision.Decide();
                ai.ChangeState(decisionValue ? transition.TrueStateID : transition.FalseStateID);
            }
        }
    }
}