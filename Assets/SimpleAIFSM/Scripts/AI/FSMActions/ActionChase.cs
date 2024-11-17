using UnityEngine;

namespace SimpleAIFSM
{
    public class ActionChase : FSMAction
    {
        [SerializeField] private float _speed;
        [SerializeField] private float _stopRange;
        private Transform _targetTransform;

        private void Awake()
        {
            _targetTransform = GameObject.FindWithTag("Player").transform;
        }

        public override void Act()
        {
            Chase();
        }

        private void Chase()
        {
            if (Vector3.Distance(transform.position, _targetTransform.position) <= _stopRange)
            {
                return;
            }

            var direction = (_targetTransform.position - transform.position).normalized;
            transform.Translate(direction * (_speed * Time.deltaTime));
        }
    }
}