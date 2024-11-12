using UnityEngine;

namespace ThirdPersonFSM
{
    public class AIChasingState : AIBaseState
    {
        private readonly int _locomotionHash;
        private readonly int _speedHash;

        public AIChasingState(AIStateMachine aiStateMachine) : base(aiStateMachine)
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
            MoveToPlayer();
            LookAtTarget();
            UpdateAnimation();
            if (!IsInDetectRange())
            {
                _stateMachine.SwitchState(new AIIdleState(_stateMachine));
            }

            if (IsInAttackRange() && !_stateMachine.PlayerHealth.IsDead)
            {
                _stateMachine.SwitchState(new AIAttackingState(_stateMachine));
            }
        }

        private void MoveToPlayer()
        {
            if (_stateMachine.AINavMeshAgent.enabled)
            {
                _stateMachine.AINavMeshAgent.SetDestination(_stateMachine.PlayerHealth.transform.position);
                Move(_stateMachine.AINavMeshAgent.desiredVelocity.normalized * _stateMachine.MoveSpeed);
            }

            _stateMachine.AINavMeshAgent.velocity = _stateMachine.AIController.velocity;
        }

        private void UpdateAnimation()
        {
            _stateMachine.AIAnimator.SetFloat(_speedHash, _stateMachine.AIController.velocity.magnitude, 0.1f,
                Time.deltaTime);
        }

        public override void Exit()
        {
            if (_stateMachine.AINavMeshAgent.enabled)
            {
                _stateMachine.AINavMeshAgent.ResetPath();
            }

            _stateMachine.AINavMeshAgent.velocity = Vector3.zero;
        }
    }

}