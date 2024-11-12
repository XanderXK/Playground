using UnityEngine;
using UnityEngine.AI;

namespace ThirdPersonFSM
{
    public class AIStateMachine : StateMachine
    {
        [field: SerializeField] public float MoveSpeed { get; private set; } = 1.5f;
        [field: SerializeField] public float DetectRange { get; private set; } = 7f;
        [field: SerializeField] public float AttackRange { get; private set; } = 2f;
        [field: SerializeField] public float AttackKnockback { get; private set; } = 5f;
        [field: SerializeField] public int AttackDamage { get; private set; } = 5;

        public Health AIHealth { get; private set; }
        public CharacterController AIController { get; private set; }
        public Animator AIAnimator { get; private set; }
        public NavMeshAgent AINavMeshAgent { get; private set; }
        public WeaponDamage CurrentWeapon { get; private set; }
        public Ragdoll AIRagdoll { get; private set; }
        public Health PlayerHealth { get; private set; }


        private void Awake()
        {
            AIHealth = GetComponent<Health>();
            AIController = GetComponent<CharacterController>();
            AIAnimator = GetComponent<Animator>();
            AIRagdoll = GetComponent<Ragdoll>();
            PlayerHealth = GameObject.FindGameObjectWithTag("Player").GetComponent<Health>();
            AINavMeshAgent = GetComponent<NavMeshAgent>();
            CurrentWeapon = GetComponentInChildren<WeaponDamage>();
            AINavMeshAgent.updatePosition = false;
            AINavMeshAgent.updateRotation = false;
        }

        private void OnEnable()
        {
            AIHealth.OnTakeDamage += HandleTakeDamage;
            AIHealth.OnDie += HandleDie;
        }

        private void Start()
        {
            SwitchState(new AIIdleState(this));
        }

        private void HandleTakeDamage()
        {
            SwitchState(new AIImpactState(this));
        }

        private void HandleDie()
        {
            SwitchState(new AIDeadState(this));
        }

        private void OnDrawGizmosSelected()
        {
            Gizmos.DrawWireSphere(transform.position, DetectRange);
        }

        private void OnDisable()
        {
            AIHealth.OnTakeDamage -= HandleTakeDamage;
            AIHealth.OnDie -= HandleDie;
        }
    }
}