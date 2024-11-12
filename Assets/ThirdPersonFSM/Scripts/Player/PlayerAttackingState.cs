namespace ThirdPersonFSM
{
    public class PlayerAttackingState : PlayerBaseState
    {
        private readonly Attack _attack;
        private float _previousTime;
        private bool _appliedForce;

        public PlayerAttackingState(PlayerStateMachine playerStateMachine, int attackId) : base(playerStateMachine)
        {
            _attack = _stateMachine.Attacks[attackId];
        }

        public override void Enter()
        {
            _stateMachine.PlayerAnimator.CrossFade(_attack.AnimationName, _attack.TransitionDuration);
            _stateMachine.CurrentWeapon.SetWeaponDamage(_attack.Damage, _attack.Knockback);
        }

        public override void Exit()
        {

        }

        public override void Tick()
        {
            Move();
            LookAtTarget();
            var normalizedTime = GetNormalizedTime(_stateMachine.PlayerAnimator);
            if (normalizedTime >= _previousTime && normalizedTime < 1f)
            {
                if (normalizedTime >= _attack.ForceTime)
                {
                    TryApplyForce();
                }

                if (_stateMachine.PlayerInput.IsAttacking)
                {
                    TryComboAttack(normalizedTime);
                }
            }
            else
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

            _previousTime = normalizedTime;
        }

        private void TryComboAttack(float normalizedTime)
        {
            if (_attack.ComboStateIndex == -1)
            {
                return;
            }

            if (normalizedTime < _attack.ComboAttackTime)
            {
                return;
            }

            _stateMachine.SwitchState(new PlayerAttackingState(_stateMachine, _attack.ComboStateIndex));
        }

        private void TryApplyForce()
        {
            if (_appliedForce)
            {
                return;
            }

            _forceReceiver.AddForce(_stateMachine.transform.forward * _attack.Force);
            _appliedForce = true;
        }
    }

}