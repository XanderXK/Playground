using UnityEngine;

public class WeaponHandler : MonoBehaviour
{
    [SerializeField] private GameObject weapon;


    private void Start()
    {
        DisableWeapon();
    }

    public void EnableWeapon()
    {
        weapon.SetActive(true);
    }

    public void DisableWeapon()
    {
        weapon.SetActive(false);
    }
}
