using UnityEngine;

namespace ThirdPersonFSM
{
    public class PlayerJumpingState : PlayerBaseState
    {
        private readonly int _jumpHash;
        private Vector3 _playerVelocity;


        public PlayerJumpingState(PlayerStateMachine playerStateMachine) : base(playerStateMachine)
        {
            _jumpHash = Animator.StringToHash("Jump");
        }

        public override void Enter()
        {
            _playerVelocity = _stateMachine.PlayerController.velocity;
            _playerVelocity.y = 0;
            _stateMachine.PlayerAnimator.CrossFade(_jumpHash, 0.15f);
            _forceReceiver.Jump(5);
        }

        public override void Tick()
        {
            Move(_playerVelocity);
            if (_stateMachine.PlayerController.velocity.y <= 0)
            {
                _stateMachine.SwitchState(new PlayerFallingState(_stateMachine));
            }
        }

        public override void Exit()
        {
        }
    }
}