using System.Collections.Generic;
using UnityEngine;

namespace ThirdPersonFSM
{
    public class PlayerStateMachine : StateMachine
    {
        [SerializeField] private float moveSpeed;
        [SerializeField] private float dodgingCooldown;
        [SerializeField] private List<Attack> attacks;

        private float previousDodgeTime;

        public InputReader PlayerInput { get; private set; }
        public Health PlayerHealth { get; private set; }
        public CharacterController PlayerController { get; private set; }
        public Animator PlayerAnimator { get; private set; }
        public Targeter PlayerTargeter { get; private set; }
        public WeaponDamage CurrentWeapon { get; private set; }
        public Transform CameraTransform { get; private set; }
        public Ragdoll PlayerRagdoll { get; private set; }
        public List<Attack> Attacks => attacks;
        public float MoveSpeed => moveSpeed;


        private void Awake()
        {
            PlayerInput = GetComponent<InputReader>();
            PlayerHealth = GetComponent<Health>();
            PlayerController = GetComponent<CharacterController>();
            PlayerAnimator = GetComponent<Animator>();
            PlayerTargeter = GetComponentInChildren<Targeter>();
            CameraTransform = Camera.main.transform;
            PlayerRagdoll = GetComponent<Ragdoll>();
            CurrentWeapon = GetComponentInChildren<WeaponDamage>();
        }

        private void OnEnable()
        {
            PlayerHealth.OnTakeDamage += HandleTakeDamage;
            PlayerHealth.OnDie += HandleDie;
            PlayerInput.OnPlayerDodge += HandleDodge;
        }

        private void Start()
        {
            SwitchState(new PlayerFreeLookState(this));
        }

        private void HandleDodge()
        {
            if (Time.time - previousDodgeTime < dodgingCooldown)
            {
                return;
            }

            previousDodgeTime = Time.time;
            SwitchState(new PlayerDodgingState(this));
        }

        private void HandleTakeDamage()
        {
            SwitchState(new PlayerImpactState(this));
        }

        private void HandleDie()
        {
            SwitchState(new PlayerDeadState(this));
        }

        private void OnDisable()
        {
            PlayerHealth.OnTakeDamage -= HandleTakeDamage;
            PlayerHealth.OnDie -= HandleDie;
            PlayerInput.OnPlayerDodge -= HandleDodge;
        }
    }

}