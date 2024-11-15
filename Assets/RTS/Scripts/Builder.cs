using UnityEngine;
using UnityEngine.InputSystem;

namespace RTS
{
    public class Builder : MonoBehaviour
    {
        [SerializeField] private Building buildingPrefab;
        private bool isStarted;
        private Building buildingInstance;
        private Camera mainCamera;
        private PlayerInput playerInput;

        private void Awake()
        {
            mainCamera = Camera.main;
            playerInput = FindObjectOfType<PlayerInput>();
        }

        private void Update()
        {
            if (Keyboard.current.spaceKey.wasPressedThisFrame)
            {
                StartBuld();
            }

            if (isStarted)
            {
                Preview();
            }

            if (Mouse.current.leftButton.wasPressedThisFrame && isStarted)
            {
                PlaceBuilding();
            }
        }

        private void Preview()
        {
            var ray = mainCamera.ScreenPointToRay(playerInput.MousePosition);
            if (Physics.Raycast(ray, out var hitInfo))
            {
                buildingInstance.transform.position = hitInfo.point;
            }
        }

        private void StartBuld()
        {
            buildingInstance = Instantiate(buildingPrefab);
            isStarted = true;
        }

        private void PlaceBuilding()
        {
            isStarted = false;
            buildingInstance.SetBuilding();
            buildingInstance = null;
        }
    }
}
