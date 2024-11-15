using UnityEngine;

namespace RTS
{
    public class AIUnit : MonoBehaviour, ITargetable
    {
        private Health _health;


        private void Awake()
        {
            _health = GetComponent<Health>();
        }

        public void ApplyDamage(int damage)
        {
            _health.TakeDamage(damage);
        }

        public OwnerType GetOwner()
        {
            return OwnerType.AI;
        }

        public Transform GetTransform()
        {
            return transform;
        }
    }
}