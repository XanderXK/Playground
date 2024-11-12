using UnityEngine;
using UnityEngine.AI;

public class ForceReceiver : MonoBehaviour
{
    [SerializeField] private float drag;

    private CharacterController characterController;
    private NavMeshAgent navMeshAgent;
    private Vector3 dampingVelocity;
    public float VerticalVelocity { get; private set; }
    public Vector3 Impact { get; private set; }


    private void Awake()
    {
        characterController = GetComponent<CharacterController>();
        navMeshAgent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        if (VerticalVelocity < 0 && characterController.isGrounded)
        {
            VerticalVelocity = 0;
        }
        else
        {
            VerticalVelocity += Physics.gravity.y * Time.deltaTime;
        }

        Impact = Vector3.SmoothDamp(Impact, Vector3.zero, ref dampingVelocity, drag);
        if (Impact.magnitude <= 0.1f && navMeshAgent && !navMeshAgent.enabled)
        {
            navMeshAgent.enabled = true;
        }
    }

    public void AddForce(Vector3 force)
    {
        Impact += force;
        if (navMeshAgent)
        {
            navMeshAgent.enabled = false;
        }
    }

    public void Jump(float jumpForce)
    {
        VerticalVelocity += jumpForce;
    }
}
