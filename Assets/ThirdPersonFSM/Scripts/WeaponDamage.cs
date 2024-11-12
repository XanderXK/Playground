using System.Collections.Generic;
using UnityEngine;

public class WeaponDamage : MonoBehaviour
{
    private Collider characterCollider;
    private List<Collider> damagedColliders;
    private int weaponDamage;
    private float weaponKnockback;


    private void OnEnable()
    {
        damagedColliders = new List<Collider>();
    }

    private void Start()
    {
        characterCollider = transform.root.GetComponent<Collider>();
    }

    public void SetWeaponDamage(int damage, float knockback)
    {
        weaponDamage = damage;
        weaponKnockback = knockback;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other == characterCollider || damagedColliders.Contains(other))
        {
            return;
        }

        var health = other.GetComponent<Health>();
        if (health)
        {
            health.DealDamage(weaponDamage);
            damagedColliders.Add(other);
        }

        if (other.TryGetComponent<ForceReceiver>(out var forceReceiver))
        {
            var force = (other.transform.position - characterCollider.transform.position).normalized * weaponKnockback;
            forceReceiver.AddForce(force);
        }
    }
}
