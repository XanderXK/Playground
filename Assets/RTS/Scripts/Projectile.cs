using UnityEngine;

namespace RTS
{
    public abstract class Projectile : MonoBehaviour
    {
        [SerializeField] protected int damage = 5;

        protected OwnerType owner;

        public abstract void Engage(OwnerType ownerType);
    }
}
