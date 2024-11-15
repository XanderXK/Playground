using UnityEngine;

namespace RTS
{
    public class CommonProjectile : Projectile
    {
        [SerializeField] private float force = 25f;


        public override void Engage(OwnerType ownerType)
        {
            owner = ownerType;
            GetComponent<Rigidbody>().AddForce(transform.forward * force, ForceMode.Impulse);
            Destroy(gameObject, 5f);
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.TryGetComponent<ITargetable>(out var target))
            {
                if (target.GetOwner() != owner)
                {
                    target.ApplyDamage(damage);
                }
            }

            Destroy(gameObject);
        }
    }
}
