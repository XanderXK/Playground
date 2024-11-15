using System.Collections.Generic;
using UnityEngine;

namespace ThirdPersonFSM
{
    public class WeaponDamage : MonoBehaviour
    {
        private Collider _characterCollider;
        private List<Collider> _damagedColliders;
        private int _weaponDamage;
        private float _weaponKnockback;


        private void OnEnable()
        {
            _damagedColliders = new List<Collider>();
        }

        private void Start()
        {
            _characterCollider = transform.root.GetComponent<Collider>();
        }

        public void SetWeaponDamage(int damage, float knockback)
        {
            _weaponDamage = damage;
            _weaponKnockback = knockback;
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other == _characterCollider || _damagedColliders.Contains(other))
            {
                return;
            }

            var health = other.GetComponent<Health>();
            if (health)
            {
                health.DealDamage(_weaponDamage);
                _damagedColliders.Add(other);
            }

            if (other.TryGetComponent<ForceReceiver>(out var forceReceiver))
            {
                var force = (other.transform.position - _characterCollider.transform.position).normalized *
                            _weaponKnockback;
                forceReceiver.AddForce(force);
            }
        }
    }
}
