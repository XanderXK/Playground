using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace SimpleAIFSM
{
    public class AI : MonoBehaviour
    {
        [SerializeField] private string _initialStateID;
        [SerializeField] private List<FSMState> _states;

        public FSMState CurrentState { get; private set; }

        private void Start()
        {
            ChangeState(_initialStateID);
        }

        private void Update()
        {
            CurrentState?.UpdateState(this);
        }

        public void ChangeState(string stateID)
        {
            if (string.IsNullOrEmpty(stateID))
            {
                return;
            }

            if (CurrentState != null && CurrentState.ID == stateID)
            {
                return;
            }

            if (_states.Any(x => x.ID == stateID))
            {
                CurrentState = _states.Find(s => s.ID == stateID);
            }
            else
            {
                Debug.Log("No state found with ID: " + stateID);
            }

            Debug.Log("Current State: " + CurrentState.ID);
        }
    }
}