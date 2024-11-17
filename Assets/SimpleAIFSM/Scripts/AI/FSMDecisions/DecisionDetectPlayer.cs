using UnityEngine;

namespace SimpleAIFSM
{
    public class DecisionDetectPlayer : FSMDecision
    {
        [SerializeField] private float _range;
        [SerializeField] private LayerMask _layerMask;


        public override bool Decide()
        {
            var playerCollider = Physics2D.OverlapCircle(transform.position, _range, _layerMask);
            return playerCollider is not null;
        }

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(transform.position, _range);
        }
    }
}


