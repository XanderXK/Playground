using UnityEngine;

namespace ThirdPersonFSM
{
    public abstract class AIBaseState : State
    {
        private const float RotationLerpSpeed = 10f;
        protected readonly AIStateMachine _stateMachine;
        private readonly ForceReceiver _forceReceiver;


        protected AIBaseState(AIStateMachine aiStateMachine)
        {
            _stateMachine = aiStateMachine;
            _forceReceiver = aiStateMachine.GetComponent<ForceReceiver>();
        }

        protected bool IsInDetectRange()
        {
            var distance = Vector3.Distance(_stateMachine.PlayerHealth.transform.position,
                _stateMachine.transform.position);
            return _stateMachine.DetectRange > distance;
        }

        protected bool IsInAttackRange()
        {
            var distance = Vector3.Distance(_stateMachine.PlayerHealth.transform.position,
                _stateMachine.transform.position);
            return _stateMachine.AttackRange > distance;
        }

        protected void Move()
        {
            Move(Vector3.zero);
        }

        protected void Move(Vector3 motion)
        {
            motion += _forceReceiver.Impact;
            motion.y = _forceReceiver.VerticalVelocity;
            _stateMachine.AIController.Move(motion * Time.deltaTime);
        }

        protected void LookAtTarget()
        {
            if (!_stateMachine.PlayerHealth)
            {
                return;
            }

            var lookPosition = _stateMachine.PlayerHealth.transform.position - _stateMachine.transform.position;
            lookPosition.y = 0;
            _stateMachine.transform.rotation =
                Quaternion.Lerp(_stateMachine.transform.rotation, Quaternion.LookRotation(lookPosition),
                    RotationLerpSpeed * Time.deltaTime);
        }
    }

}