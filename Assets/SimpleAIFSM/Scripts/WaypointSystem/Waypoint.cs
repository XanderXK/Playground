using System.Collections.Generic;
using UnityEngine;

namespace SimpleAIFSM
{
    public class Waypoint : MonoBehaviour
    {
        [field: SerializeField] public List<Vector2> Points { get; set; }

        private void Awake()
        {
            for (var i = 0; i < Points.Count; i++)
            {
                Points[i] += (Vector2)transform.position;
            }
        }
    }
}
