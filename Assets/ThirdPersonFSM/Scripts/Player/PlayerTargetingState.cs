using UnityEngine;

namespace ThirdPersonFSM
{
    public class PlayerTargetingState : PlayerBaseState
    {
        private readonly int _targetingHash;
        private readonly int _targetingForwardHash;
        private readonly int _targetingRightHash;

        public PlayerTargetingState(PlayerStateMachine playerStateMachine) : base(playerStateMachine)
        {
            _targetingHash = Animator.StringToHash("Targeting");
            _targetingForwardHash = Animator.StringToHash("TargetingForward");
            _targetingRightHash = Animator.StringToHash("TargetingRight");
        }

        public override void Enter()
        {
            _stateMachine.PlayerInput.OnPlayerCancelTarget += CancelTarget;
            _stateMachine.PlayerAnimator.Play(_targetingHash);
        }

        private void CancelTarget()
        {
            _stateMachine.SwitchState(new PlayerFreeLookState(_stateMachine));
        }

        public override void Tick()
        {
            if (_stateMachine.PlayerInput.IsAttacking)
            {
                _stateMachine.SwitchState(new PlayerAttackingState(_stateMachine, 0));
                return;
            }

            if (_stateMachine.PlayerInput.IsBlocking)
            {
                _stateMachine.SwitchState(new PlayerBlockingState(_stateMachine));
            }

            if (!_stateMachine.PlayerTargeter.CurrentTarget)
            {
                _stateMachine.SwitchState(new PlayerFreeLookState(_stateMachine));
            }

            var movement = CalculateMovement();
            Move(movement * _stateMachine.MoveSpeed);
            SetAnimation();
            LookAtTarget();
        }

        private void SetAnimation()
        {
            var moveDirection =
                _stateMachine.transform.InverseTransformDirection(_stateMachine.PlayerController.velocity);
            _stateMachine.PlayerAnimator.SetFloat(_targetingForwardHash, moveDirection.z, 0.1f, Time.deltaTime);
            _stateMachine.PlayerAnimator.SetFloat(_targetingRightHash, moveDirection.x, 0.1f, Time.deltaTime);
        }

        private Vector3 CalculateMovement()
        {
            var movement = new Vector3();
            movement += _stateMachine.transform.right * _stateMachine.PlayerInput.MoveValue.x;
            movement += _stateMachine.transform.forward * _stateMachine.PlayerInput.MoveValue.y;
            return movement;
        }

        public override void Exit()
        {
            _stateMachine.PlayerInput.OnPlayerCancelTarget -= CancelTarget;
        }
    }
}