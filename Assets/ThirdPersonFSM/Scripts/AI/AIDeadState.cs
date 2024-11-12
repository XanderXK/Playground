using UnityEngine;

namespace ThirdPersonFSM
{
    public class AIDeadState : AIBaseState
    {
        private readonly int _dieHash;


        public AIDeadState(AIStateMachine aiStateMachine) : base(aiStateMachine)
        {
            _dieHash = Animator.StringToHash("Dead");
        }

        public override void Enter()
        {
            _stateMachine.CurrentWeapon.gameObject.SetActive(false);
            _stateMachine.AIRagdoll.ToggleRagdoll(true);
        }

        public override void Tick()
        {
        }

        public override void Exit()
        {
        }
    }

}