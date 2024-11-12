using UnityEngine;

namespace ThirdPersonFSM
{
    public class AIAttackingState : AIBaseState
    {
        private readonly int _attackHash;

        public AIAttackingState(AIStateMachine aiStateMachine) : base(aiStateMachine)
        {
            _attackHash = Animator.StringToHash("Attack");
        }

        public override void Enter()
        {
            _stateMachine.CurrentWeapon.SetWeaponDamage(_stateMachine.AttackDamage, _stateMachine.AttackKnockback);
            _stateMachine.AIAnimator.CrossFade(_attackHash, 0.15f);
        }

        public override void Tick()
        {
            Move();
            LookAtTarget();
            if (GetNormalizedTime(_stateMachine.AIAnimator) >= 1)
            {
                _stateMachine.SwitchState(new AIChasingState(_stateMachine));
            }
        }

        public override void Exit()
        {

        }
    }

}