using UnityEngine;

namespace ThirdPersonFSM
{
    public class PlayerFallingState : PlayerBaseState
    {
        private readonly int _fallHash;
        private Vector3 _playerVelocity;


        public PlayerFallingState(PlayerStateMachine playerStateMachine) : base(playerStateMachine)
        {
            _fallHash = Animator.StringToHash("Fall");
        }

        public override void Enter()
        {
            _stateMachine.PlayerAnimator.CrossFade(_fallHash, 0.25f);
            _playerVelocity = _stateMachine.PlayerController.velocity;
            _playerVelocity.y = 0;
        }

        public override void Tick()
        {
            Move(_playerVelocity);
            if (_stateMachine.PlayerController.isGrounded)
            {
                _stateMachine.SwitchState(new PlayerFreeLookState(_stateMachine));
            }
        }

        public override void Exit()
        {

        }
    }
}