using UnityEngine;

namespace RTS
{
    public class Health : MonoBehaviour
    {
        [SerializeField] private int hp = 100;
        [SerializeField] private Transform healthBar;
        private int currentHP;
        private float healthBarStartScale;
        private Transform cameraTransform;


        private void Awake()
        {
            currentHP = hp;
            healthBarStartScale = healthBar.localScale.x;
            cameraTransform = Camera.main.transform;
        }

        private void LateUpdate()
        {
            LookAtCamera();
        }

        private void LookAtCamera()
        {
            healthBar.LookAt(transform.position + cameraTransform.rotation * Vector3.forward,
                cameraTransform.rotation * Vector3.up);
        }

        public void TakeDamage(int damage)
        {
            currentHP -= damage;
            healthBar.localScale = new Vector3(healthBarStartScale * currentHP / hp, healthBar.localScale.y,
                healthBar.localScale.z);
            if (currentHP <= 0)
            {
                Die();
            }
        }

        private void Die()
        {
            Destroy(gameObject);
        }
    }
}
