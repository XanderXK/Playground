using System.Collections.Generic;
using Unity.Cinemachine;
using UnityEngine;

namespace ThirdPersonFSM
{
    public class Targeter : MonoBehaviour
    {
        private List<Target> _targets;
        private CinemachineTargetGroup _cinemachineTargetGroup;
        private Camera _mainCamera;

        public Target CurrentTarget { get; private set; }


        private void Awake()
        {
            _targets = new List<Target>();
            _cinemachineTargetGroup = FindAnyObjectByType<CinemachineTargetGroup>();
            _mainCamera = Camera.main;
        }

        public bool SelectTarget()
        {
            if (_targets.Count == 0)
            {
                return false;
            }

            Target closestTarget = null;
            var closestDistance = float.MaxValue;
            foreach (var target in _targets)
            {
                var targetPosition = _mainCamera.WorldToViewportPoint(target.transform.position);
                if (targetPosition.x < 0 || targetPosition.x > 1 || targetPosition.y < 0 || targetPosition.y > 1)
                {
                    continue;
                }

                var distanceToCenter = Mathf.Abs(targetPosition.x - 0.5f);
                if (distanceToCenter < closestDistance)
                {
                    closestDistance = distanceToCenter;
                    closestTarget = target;
                }
            }

            if (closestTarget)
            {
                CurrentTarget = closestTarget;
                _cinemachineTargetGroup.AddMember(CurrentTarget.transform, 1f, 2f);
                return true;
            }

            return false;
        }

        public void CancelTarget()
        {
            _cinemachineTargetGroup.RemoveMember(CurrentTarget.transform);
            CurrentTarget = null;
        }

        private void OnTriggerEnter(Collider other)
        {
            var target = other.GetComponent<Target>();
            if (target)
            {
                _targets.Add(target);
                target.OnDisabled += RemoveTarget;
            }
        }

        private void RemoveTarget(Target target)
        {
            target.OnDisabled -= RemoveTarget;
            _targets.Remove(target);
            if (target == CurrentTarget)
            {
                CurrentTarget = null;
            }
        }

        private void OnTriggerExit(Collider other)
        {
            var target = other.GetComponent<Target>();
            if (target)
            {
                RemoveTarget(target);
            }
        }
    }
}
