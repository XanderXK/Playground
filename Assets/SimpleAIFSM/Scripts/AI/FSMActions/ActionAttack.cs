using UnityEngine;

namespace SimpleAIFSM
{
    public class ActionAttack : FSMAction
    {
        [SerializeField] private int _damage;
        [SerializeField] private float _attackCooldown;
        private float _timer;
        private GameObject _target;

        private void Awake()
        {
            _target = GameObject.FindWithTag("Player");
        }

        public override void Act()
        {
            Attack();
        }

        private void Attack()
        {
            _timer -= Time.deltaTime;
            if (_timer <= 0)
            {
                _timer = _attackCooldown;
                DealDamage();
            }
        }

        private void DealDamage()
        {
            Debug.Log($"Damage: {_damage}", _target);
        }
    }
}