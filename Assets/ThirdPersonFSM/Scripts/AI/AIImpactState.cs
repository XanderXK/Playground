using UnityEngine;

namespace ThirdPersonFSM
{
    public class AIImpactState : AIBaseState
    {
        private readonly int _impactHash;
        private float _duration = 0.35f;


        public AIImpactState(AIStateMachine aiStateMachine) : base(aiStateMachine)
        {
            _impactHash = Animator.StringToHash("Impact");
        }

        public override void Enter()
        {
            _stateMachine.AIAnimator.CrossFade(_impactHash, 0.25f);
        }

        public override void Tick()
        {
            Move();
            _duration -= Time.deltaTime;
            if (_duration <= 0)
            {
                _stateMachine.SwitchState(new AIIdleState(_stateMachine));
            }
        }

        public override void Exit()
        {
        }
    }
}