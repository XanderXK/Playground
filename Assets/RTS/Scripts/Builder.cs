using UnityEngine;
using UnityEngine.InputSystem;

namespace RTS
{
    public class Builder : MonoBehaviour
    {
        [SerializeField] private Building _buildingPrefab;
        private bool _isStarted;
        private Building _buildingInstance;
        private Camera _mainCamera;
        private PlayerInput _playerInput;

        private void Awake()
        {
            _mainCamera = Camera.main;
            _playerInput = FindAnyObjectByType<PlayerInput>();
        }

        private void Update()
        {
            if (Keyboard.current.spaceKey.wasPressedThisFrame)
            {
                StartBuild();
            }

            if (_isStarted)
            {
                Preview();
            }

            if (Mouse.current.leftButton.wasPressedThisFrame && _isStarted)
            {
                PlaceBuilding();
            }
        }

        private void Preview()
        {
            var ray = _mainCamera.ScreenPointToRay(_playerInput.MousePosition);
            if (Physics.Raycast(ray, out var hitInfo))
            {
                _buildingInstance.transform.position = hitInfo.point;
            }
        }

        private void StartBuild()
        {
            _buildingInstance = Instantiate(_buildingPrefab);
            _isStarted = true;
        }

        private void PlaceBuilding()
        {
            _isStarted = false;
            _buildingInstance.SetBuilding();
            _buildingInstance = null;
        }
    }
}
