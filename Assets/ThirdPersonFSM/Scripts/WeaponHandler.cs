using UnityEngine;

namespace ThirdPersonFSM
{
    public class WeaponHandler : MonoBehaviour
    {
        [SerializeField] private GameObject _weapon;


        private void Start()
        {
            DisableWeapon();
        }

        public void EnableWeapon()
        {
            _weapon.SetActive(true);
        }

        public void DisableWeapon()
        {
            _weapon.SetActive(false);
        }
    }

}