using UnityEngine;
using UnityEngine.AI;

namespace ThirdPersonFSM
{
    public class ForceReceiver : MonoBehaviour
    {
        [SerializeField] private float _drag = 0.05f;

        private CharacterController _characterController;
        private NavMeshAgent _navMeshAgent;
        private Vector3 _dampingVelocity;
        public float VerticalVelocity { get; private set; }
        public Vector3 Impact { get; private set; }


        private void Awake()
        {
            _characterController = GetComponent<CharacterController>();
            _navMeshAgent = GetComponent<NavMeshAgent>();
        }

        private void Update()
        {
            if (VerticalVelocity < 0 && _characterController.isGrounded)
            {
                VerticalVelocity = 0;
            }
            else
            {
                VerticalVelocity += Physics.gravity.y * Time.deltaTime;
            }

            Impact = Vector3.SmoothDamp(Impact, Vector3.zero, ref _dampingVelocity, _drag);
            if (Impact.magnitude <= 0.1f && _navMeshAgent && !_navMeshAgent.enabled)
            {
                _navMeshAgent.enabled = true;
            }
        }

        public void AddForce(Vector3 force)
        {
            Impact += force;
            if (_navMeshAgent)
            {
                _navMeshAgent.enabled = false;
            }
        }

        public void Jump(float jumpForce)
        {
            VerticalVelocity += jumpForce;
        }
    }
}