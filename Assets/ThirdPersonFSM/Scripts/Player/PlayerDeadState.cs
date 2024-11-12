using UnityEngine;

namespace ThirdPersonFSM
{
    public class PlayerDeadState : PlayerBaseState
    {
        private readonly int _dieHash;


        public PlayerDeadState(PlayerStateMachine playerStateMachine) : base(playerStateMachine)
        {
            _dieHash = Animator.StringToHash("Dead");
        }

        public override void Enter()
        {
            _stateMachine.CurrentWeapon.gameObject.SetActive(false);
            _stateMachine.PlayerRagdoll.ToggleRagdoll(true);
        }

        public override void Tick()
        {

        }

        public override void Exit()
        {

        }
    }

}