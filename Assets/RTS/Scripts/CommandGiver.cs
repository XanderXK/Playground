using UnityEngine;

namespace RTS
{
    public class CommandGiver : MonoBehaviour
    {
        private Selector _selector;
        private PlayerInput _playerInput;
        private Camera _mainCamera;


        private void Awake()
        {
            _selector = FindAnyObjectByType<Selector>();
            _playerInput = FindAnyObjectByType<PlayerInput>();
            _mainCamera = Camera.main;
        }

        private void OnEnable()
        {
            _playerInput.OnPlayerMove += Act;
        }

        private void Act()
        {
            var ray = _mainCamera.ScreenPointToRay(_playerInput.MousePosition);
            if (Physics.Raycast(ray, out var hitInfo, 100f))
            {
                if (hitInfo.collider.TryGetComponent<ITargetable>(out var target))
                {
                    if (target.GetOwner() == OwnerType.Player)
                    {
                        TryMove(hitInfo.point);
                        return;
                    }
                    else
                    {
                        TryAttack(target);
                    }
                }
                else
                {
                    TryMove(hitInfo.point);
                }
            }
        }

        private void TryMove(Vector3 point)
        {
            foreach (var unit in _selector.SelectedUnits)
            {
                unit.MoveTo(point);
            }
        }

        private void TryAttack(ITargetable target)
        {
            foreach (var unit in _selector.SelectedUnits)
            {
                unit.TryAttack(target);
            }
        }
    }
}
