using UnityEngine;

namespace ThirdPersonFSM
{

    public class PlayerImpactState : PlayerBaseState
    {
        private readonly int _impactHash;
        private float _duration = 0.35f;

        public PlayerImpactState(PlayerStateMachine playerStateMachine) : base(playerStateMachine)
        {
            _impactHash = Animator.StringToHash("Impact");
        }

        public override void Enter()
        {
            _stateMachine.PlayerAnimator.CrossFade(_impactHash, 0.25f);
        }

        public override void Tick()
        {
            _duration -= Time.deltaTime;
            if (_duration <= 0)
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
        }
    }
}