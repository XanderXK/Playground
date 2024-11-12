using UnityEngine;

namespace ThirdPersonFSM
{
    public abstract class PlayerBaseState : State
    {
        protected readonly PlayerStateMachine _stateMachine;
        protected readonly ForceReceiver _forceReceiver;


        protected PlayerBaseState(PlayerStateMachine playerStateMachine)
        {
            _stateMachine = playerStateMachine;
            _forceReceiver = _stateMachine.GetComponent<ForceReceiver>();
        }

        protected void Move()
        {
            Move(Vector3.zero);
        }

        protected void Move(Vector3 motion)
        {
            motion += _forceReceiver.Impact;
            motion.y = _forceReceiver.VerticalVelocity;
            _stateMachine.PlayerController.Move(motion * Time.deltaTime);
        }

        protected void LookAtTarget()
        {
            if (!_stateMachine.PlayerTargeter.CurrentTarget)
            {
                return;
            }

            var lookPosition = _stateMachine.PlayerTargeter.CurrentTarget.transform.position -
                               _stateMachine.transform.position;
            lookPosition.y = 0;
            if (lookPosition != Vector3.zero)
            {
                _stateMachine.transform.rotation = Quaternion.LookRotation(lookPosition);
            }

        }

    }
}