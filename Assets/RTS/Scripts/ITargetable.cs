using UnityEngine;

namespace RTS
{
    public interface ITargetable
    {
        public OwnerType GetOwner();
        public Transform GetTransform();
        public void ApplyDamage(int damage);
    }
}