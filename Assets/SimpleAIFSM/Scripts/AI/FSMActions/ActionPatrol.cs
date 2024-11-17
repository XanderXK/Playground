using UnityEngine;

namespace SimpleAIFSM
{
    public class ActionPatrol : FSMAction
    {
        [SerializeField] private float _speed = 3f;
        [SerializeField] private Waypoint _waypoint;
        private int _currentPointIndex;


        public override void Act()
        {
            Move();
        }

        private void Move()
        {
            var direction = (_waypoint.Points[_currentPointIndex] - (Vector2)transform.position).normalized;
            transform.Translate(direction * (_speed * Time.deltaTime));

            transform.position = Vector2.MoveTowards(transform.position, _waypoint.Points[_currentPointIndex],
                _speed * Time.deltaTime);
            if (Vector2.Distance(transform.position, _waypoint.Points[_currentPointIndex]) < 0.1f)
            {
                _currentPointIndex = (_currentPointIndex + 1) % _waypoint.Points.Count;
            }
        }
    }
}