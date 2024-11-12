using UnityEngine;

namespace ThirdPersonFSM
{
    public class PlayerDodgingState : PlayerBaseState
    {
        private Vector2 _dodgingDirectionInput;
        private float _remainingDodgeTime = 1f;
        private Vector3 _movement;
        private readonly int _dodgeHash;


        public PlayerDodgingState(PlayerStateMachine playerStateMachine) : base(playerStateMachine)
        {
            _dodgeHash = Animator.StringToHash("Dodge");
        }

        public override void Enter()
        {
            _dodgingDirectionInput = _stateMachine.PlayerInput.MoveValue;
            _stateMachine.PlayerAnimator.CrossFade(_dodgeHash, 0.15f);
            _stateMachine.PlayerHealth.IsInvulnerable = true;
        }

        public override void Tick()
        {
            _remainingDodgeTime -= Time.deltaTime;
            if (_remainingDodgeTime > 0)
            {
                CalculateMovement();
                Move(_movement);
            }
            else
            {
                _stateMachine.SwitchState(new PlayerFreeLookState(_stateMachine));
            }
        }

        private void CalculateMovement()
        {
            var cameraForward = _stateMachine.CameraTransform.forward;
            cameraForward.y = 0;
            var cameraRight = _stateMachine.CameraTransform.right;
            cameraRight.y = 0;

            _movement = cameraForward * _dodgingDirectionInput.y + cameraRight * _dodgingDirectionInput.x;
            _movement.Normalize();
        }

        public override void Exit()
        {
            _stateMachine.PlayerHealth.IsInvulnerable = false;
        }
    }
}
