using UnityEngine;

namespace ThirdPersonFSM
{
    public class Ragdoll : MonoBehaviour
    {
        private Collider[] _allColliders;
        private Rigidbody[] _allRigidbodies;


        private void Awake()
        {
            _allColliders = GetComponentsInChildren<Collider>(true);
            _allRigidbodies = GetComponentsInChildren<Rigidbody>(true);
            ToggleRagdoll(false);
        }

        public void ToggleRagdoll(bool toggle)
        {
            GetComponent<Animator>().enabled = !toggle;
            GetComponent<CharacterController>().enabled = !toggle;

            var ragdollLayer = LayerMask.NameToLayer("Ragdoll");
            foreach (var item in _allColliders)
            {
                if (item.gameObject.layer == ragdollLayer)
                {
                    item.enabled = toggle;
                }
            }

            foreach (var item in _allRigidbodies)
            {
                if (item.gameObject.layer == ragdollLayer)
                {
                    item.useGravity = toggle;
                    item.isKinematic = !toggle;
                }
            }
        }
    }

}