using UnityEngine;

namespace RTS
{
    public class CommandGiver : MonoBehaviour
    {
        private Selector selector;
        private PlayerInput playerInput;
        private Camera mainCamera;


        private void Awake()
        {
            selector = FindObjectOfType<Selector>();
            playerInput = FindObjectOfType<PlayerInput>();
            mainCamera = Camera.main;
        }

        private void OnEnable()
        {
            playerInput.OnPlayerMove += Act;
        }

        private void Act()
        {
            var ray = mainCamera.ScreenPointToRay(playerInput.MousePosition);
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
            foreach (var unit in selector.SelectedUnits)
            {
                unit.MoveTo(point);
            }
        }

        private void TryAttack(ITargetable target)
        {
            foreach (var unit in selector.SelectedUnits)
            {
                unit.TryAttack(target);
            }
        }
    }
}
