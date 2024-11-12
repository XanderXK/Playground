using UnityEngine;

namespace ThirdPersonFSM
{
    public class PlayerFreeLookState : PlayerBaseState
    {
        private const float RotationLerpSpeed = 10f;
        private const float AnimatorDampTime = 0.1f;

        private readonly int _freeLookSpeedHash;
        private readonly int _freeLookHash;
        private Vector3 _movement;


        public PlayerFreeLookState(PlayerStateMachine playerStateMachine) : base(playerStateMachine)
        {
            _freeLookSpeedHash = Animator.StringToHash("FreeLookSpeed");
            _freeLookHash = Animator.StringToHash("FreeLook");
        }

        public override void Enter()
        {
            _stateMachine.PlayerInput.OnPlayerSetTarget += SetTarget;
            _stateMachine.PlayerInput.OnPlayerJump += Jump;
            _stateMachine.PlayerAnimator.CrossFade(_freeLookHash, 0.25f);
        }

        private void Jump()
        {
            _stateMachine.SwitchState(new PlayerJumpingState(_stateMachine));
        }

        private void SetTarget()
        {
            if (_stateMachine.PlayerTargeter.SelectTarget())
            {
                _stateMachine.SwitchState(new PlayerTargetingState(_stateMachine));
            }
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

            CalculateMovement();
            Move(_movement * _stateMachine.MoveSpeed);
            Rotate();
            SetAnimation();
        }

        private void CalculateMovement()
        {
            var cameraForward = _stateMachine.CameraTransform.forward;
            cameraForward.y = 0;
            var cameraRight = _stateMachine.CameraTransform.right;
            cameraRight.y = 0;

            _movement = cameraForward * _stateMachine.PlayerInput.MoveValue.y +
                        cameraRight * _stateMachine.PlayerInput.MoveValue.x;
            _movement.Normalize();
        }

        private void Rotate()
        {
            if (_movement != Vector3.zero)
            {
                _stateMachine.PlayerController.transform.rotation =
                    Quaternion.Lerp(_stateMachine.PlayerController.transform.rotation,
                        Quaternion.LookRotation(_movement), Time.deltaTime * RotationLerpSpeed);
            }
        }

        private void SetAnimation()
        {
            _stateMachine.PlayerAnimator.SetFloat(_freeLookSpeedHash, _movement.magnitude, AnimatorDampTime,
                Time.deltaTime);
        }

        public override void Exit()
        {
            _stateMachine.PlayerInput.OnPlayerSetTarget -= SetTarget;
            _stateMachine.PlayerInput.OnPlayerJump -= Jump;
        }
    }
}
