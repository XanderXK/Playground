using UnityEngine;

namespace ThirdPersonFSM
{
    public class PlayerBlockingState : PlayerBaseState
    {
        private readonly int _blockHash;


        public PlayerBlockingState(PlayerStateMachine playerStateMachine) : base(playerStateMachine)
        {
            _blockHash = Animator.StringToHash("Block");
        }

        public override void Enter()
        {
            _stateMachine.PlayerAnimator.CrossFade(_blockHash, 0.15f);
            _stateMachine.PlayerHealth.IsInvulnerable = true;
        }

        public override void Tick()
        {
            Move();
            if (!_stateMachine.PlayerInput.IsBlocking)
            {
                if (_stateMachine.PlayerTargeter.CurrentTarget)
                {
                    _stateMachine.SwitchState(new PlayerTargetingState(_stateMachine));
                }
                else
                {
                    _stateMachine.SwitchState(new PlayerFreeLookState(_stateMachine));
                }
            }
        }

        public override void Exit()
        {
            _stateMachine.PlayerHealth.IsInvulnerable = false;
        }
    }

}