using UnityEngine;

namespace RTS
{
    public class Attacker : MonoBehaviour
    {
        [SerializeField] private Transform projectileSpawnPoint;
        [SerializeField] private Projectile projectilePrefab;
        [SerializeField] private float distance = 5f;
        [SerializeField] private float cooldown = 1f;
        [SerializeField] private float angle = 10f;

        private ITargetable currentTarget;
        private float cooldownTimer;
        private OwnerType owner;

        private void Start()
        {
            owner = GetComponent<Unit>().GetOwner();
        }

        public void SetTarget(ITargetable target)
        {
            currentTarget = target;
        }

        public void ClaerTarget()
        {
            currentTarget = null;
        }

        private void Update()
        {
            if (cooldownTimer > 0)
            {
                cooldownTimer -= Time.deltaTime;
            }

            TryShoot();
        }

        private void TryShoot()
        {
            if (currentTarget == null || (currentTarget as MonoBehaviour) == null)
            {
                return;
            }

            if (cooldownTimer > 0)
            {
                return;
            }

            var currentDistance = Vector3.Distance(transform.position, currentTarget.GetTransform().position);
            if (currentDistance > distance)
            {
                return;
            }

            var direction = currentTarget.GetTransform().position - transform.position;
            var targetAngle = Vector3.Angle(direction, transform.forward);
            if (targetAngle > angle)
            {
                return;
            }

            var projectile = Instantiate(projectilePrefab, projectileSpawnPoint.position,
                projectileSpawnPoint.rotation);
            projectile.Engage(owner);
            cooldownTimer = cooldown;
        }
    }
}
