using System;
using UnityEngine;

namespace ThirdPersonFSM
{
    public class Health : MonoBehaviour
    {
        [SerializeField] private int _health = 100;
        private int _currentHealth;

        public bool IsInvulnerable { get; set; }
        public bool IsDead { get; private set; }

        public event Action OnTakeDamage;
        public event Action OnDie;


        private void Start()
        {
            _currentHealth = _health;
        }

        public void DealDamage(int damage)
        {
            if (_currentHealth <= 0 || IsInvulnerable)
            {
                return;
            }

            _currentHealth -= damage;
            OnTakeDamage?.Invoke();

            if (_currentHealth <= 0)
            {
                IsDead = true;
                OnDie?.Invoke();
            }
        }
    }

}