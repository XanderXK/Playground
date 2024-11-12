using System;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private int health = 100;
    private int currentHealth;

    public bool IsInvulnerable { get; set; }
    public bool IsDead { get; private set; }

    public event Action OnTakeDamage;
    public event Action OnDie;


    private void Start()
    {
        currentHealth = health;
    }

    public void DealDamage(int damage)
    {
        if (currentHealth <= 0 || IsInvulnerable)
        {
            return;
        }

        currentHealth -= damage;
        OnTakeDamage?.Invoke();

        if (currentHealth <= 0)
        {
            IsDead = true;
            OnDie?.Invoke();
        }
    }
}
