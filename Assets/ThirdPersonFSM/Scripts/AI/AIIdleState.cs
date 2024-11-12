using UnityEngine;

namespace ThirdPersonFSM
{
    public class AIIdleState : AIBaseState
    {
        private readonly int _locomotionHash;
        private readonly int _speedHash;


        public AIIdleState(AIStateMachine aiStateMachine) : base(aiStateMachine)
        {
            _locomotionHash = Animator.StringToHash("Locomotion");
            _speedHash = Animator.StringToHash("Speed");

        }

        public override void Enter()
        {
            _stateMachine.AIAnimator.CrossFade(_locomotionHash, 0.25f);
        }

        public override void Tick()
        {
            Move();
            UpdateAnimation();

            if (IsInDetectRange())
            {
                _stateMachine.SwitchState(new AIChasingState(_stateMachine));
            }
        }

        public override void Exit()
        {

        }

        private void UpdateAnimation()
        {
            _stateMachine.AIAnimator.SetFloat(_speedHash, _stateMachine.AIController.velocity.magnitude, 0.1f,
                Time.deltaTime);
        }
    }

}