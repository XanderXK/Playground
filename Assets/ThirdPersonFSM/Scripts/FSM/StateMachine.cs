using UnityEngine;

namespace ThirdPersonFSM
{
    public abstract class StateMachine : MonoBehaviour
    {
        private State _currentState;


        public void SwitchState(State newState)
        {
            _currentState?.Exit();
            _currentState = newState;
            _currentState.Enter();
        }

        private void Update()
        {
            _currentState?.Tick();
        }
    }
}