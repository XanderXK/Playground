using UnityEngine;

namespace RTS
{
    public class Building : MonoBehaviour
    {
        public void SetBuilding()
        {
            GetComponent<Collider>().enabled = true;
        }
    }
}