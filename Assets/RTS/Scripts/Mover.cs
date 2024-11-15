using UnityEngine;
using UnityEngine.AI;


namespace RTS
{
    public class Mover : MonoBehaviour
    {
        [SerializeField] private float chasingDistance = 5;
        [SerializeField] private float rotationSpeed = 5f;

        private NavMeshAgent navMeshAgent;
        private Transform chaseTarget;


        private void Awake()
        {
            navMeshAgent = GetComponent<NavMeshAgent>();
        }

        private void Update()
        {
            if (navMeshAgent.remainingDistance <= navMeshAgent.stoppingDistance && navMeshAgent.hasPath)
            {
                navMeshAgent.ResetPath();
            }

            Chase();
        }

        public void MoveToPosition(Vector3 pos)
        {
            chaseTarget = null;
            if (NavMesh.SamplePosition(pos, out var hit, 1f, NavMesh.AllAreas))
            {
                navMeshAgent.SetDestination(hit.position);
            }
        }

        public void SetChaseTarget(Transform target)
        {
            chaseTarget = target;
        }

        private void Chase()
        {
            if (!chaseTarget)
            {
                return;
            }

            var distance = Vector3.Distance(transform.position, chaseTarget.position);
            if (distance > chasingDistance)
            {
                navMeshAgent.SetDestination(chaseTarget.position);
            }
            else
            {
                RotateToTarget();
                navMeshAgent.ResetPath();
            }
        }

        private void RotateToTarget()
        {
            var direction = chaseTarget.position - transform.position;
            // direction.y = 0;
            var targetAngle = Vector3.Angle(direction, transform.forward);
            if (targetAngle > 3f)
            {
                var finalRotation = Quaternion.LookRotation(direction);
                transform.rotation = Quaternion.Lerp(transform.rotation, finalRotation, rotationSpeed * Time.deltaTime);
            }

        }
    }
}
