using UnityEngine;

namespace SimpleAIFSM
{
    public class DecisionAimPlayer : FSMDecision
    {
        [SerializeField] private float _aimRange;
        private Transform _targetTransform;

        private void Awake()
        {
            _targetTransform = GameObject.FindWithTag("Player").transform;
        }

        public override bool Decide()
        {
            return Vector3.Distance(transform.position, _targetTransform.position) <= _aimRange;
        }

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.cyan;
            Gizmos.DrawWireSphere(transform.position, _aimRange);
        }
    }
}