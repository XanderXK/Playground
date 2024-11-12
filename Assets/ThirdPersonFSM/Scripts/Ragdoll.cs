using UnityEngine;

public class Ragdoll : MonoBehaviour
{
    private Collider[] allColliders;
    private Rigidbody[] allRigidbodies;


    private void Awake()
    {
        allColliders = GetComponentsInChildren<Collider>(true);
        allRigidbodies = GetComponentsInChildren<Rigidbody>(true);
        ToggleRagdoll(false);
    }

    public void ToggleRagdoll(bool toggle)
    {
        GetComponent<Animator>().enabled = !toggle;
        GetComponent<CharacterController>().enabled = !toggle;

        var ragdollLayer = LayerMask.NameToLayer("Ragdoll");
        foreach (var item in allColliders)
        {
            if (item.gameObject.layer == ragdollLayer)
            {
                item.enabled = toggle;
            }
        }

        foreach (var item in allRigidbodies)
        {
            if (item.gameObject.layer == ragdollLayer)
            {
                item.useGravity = toggle;
                item.isKinematic = !toggle;
            }
        }
    }
}
