using System.Collections.Generic;
using UnityEngine;

namespace SimpleAIFSM
{
    public class ActionWander : FSMAction
    {
        [SerializeField] private float _speed;
        [SerializeField] private float _wanderTime;
        [SerializeField] private float _moveRange;

        private Vector2 _movePosition;
        private float _timer;


        private void Start()
        {
            RecalculateNewDestination();
        }

        public override void Act()
        {
            _timer -= Time.deltaTime;
            if (_timer <= 0 || Vector2.Distance(transform.position, _movePosition) <= 0.1f)
            {
                RecalculateNewDestination();
            }

            Move();
        }

        private void Move()
        {
            var direction = (_movePosition - (Vector2)transform.position).normalized;
            transform.Translate(direction * (_speed * Time.deltaTime));
        }

        private void RecalculateNewDestination()
        {
            _timer = _wanderTime;
            var position = (Vector2)transform.position + Random.insideUnitCircle * _moveRange;
            var contactFilter = new ContactFilter2D();
            contactFilter.SetLayerMask(LayerMask.GetMask("Default"));
            if (Physics2D.Linecast(transform.position, position, contactFilter, new List<RaycastHit2D>()) > 0)
            {
                _movePosition = transform.position;
            }
            else
            {
                _movePosition = position;
            }
        }

        private void OnDrawGizmos()
        {
            if (_moveRange <= 0)
            {
                return;
            }

            Gizmos.color = Color.blue;
            Gizmos.DrawWireSphere(transform.position, _moveRange);
            Gizmos.color = Color.white;
            Gizmos.DrawLine(transform.position, _movePosition);
        }
    }
}