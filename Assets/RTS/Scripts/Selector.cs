using System.Collections.Generic;
using UnityEngine;

namespace RTS
{
    public class Selector : MonoBehaviour
    {
        [SerializeField] private RectTransform selectionArea;
        [SerializeField] private LayerMask layerMask;

        private Camera mainCamera;
        private Player player;
        private PlayerInput playerInput;
        private Vector2 startPosition;
        public List<Unit> SelectedUnits { get; private set; }


        private void Awake()
        {
            mainCamera = Camera.main;
            playerInput = FindAnyObjectByType<PlayerInput>();
            SelectedUnits = new List<Unit>();
            player = FindObjectOfType<Player>();
        }

        private void OnEnable()
        {
            playerInput.OnPlayerSelectEnd += EndSelection;
            playerInput.OnPlayerSelectStart += StartSelection;
        }

        private void StartSelection()
        {
            Deselect();
            selectionArea.gameObject.SetActive(true);
            startPosition = playerInput.MousePosition;
        }

        private void Deselect()
        {
            if (playerInput.Adding)
            {
                return;
            }

            foreach (var unit in SelectedUnits)
            {
                unit.Deselect();
            }

            SelectedUnits.Clear();
        }

        private void Update()
        {
            if (playerInput.Selecting)
            {
                UpdateSelectionArea();
            }
        }

        private void UpdateSelectionArea()
        {
            var areaWidth = playerInput.MousePosition.x - startPosition.x;
            var areaHeight = playerInput.MousePosition.y - startPosition.y;

            selectionArea.sizeDelta = new Vector2(Mathf.Abs(areaWidth), Mathf.Abs(areaHeight));
            selectionArea.anchoredPosition = startPosition + new Vector2(areaWidth / 2f, areaHeight / 2f);
        }

        private void EndSelection()
        {
            selectionArea.gameObject.SetActive(false);

            if (selectionArea.sizeDelta.magnitude <= 1f)
            {
                SingleSelection();
            }
            else
            {
                MultiSelection();
            }
        }

        private void MultiSelection()
        {
            var minPosition = selectionArea.anchoredPosition - (selectionArea.sizeDelta / 2f);
            var maxPosition = selectionArea.anchoredPosition + (selectionArea.sizeDelta / 2f);
            foreach (var unit in player.PlayerUnits)
            {
                var screenPos = mainCamera.WorldToScreenPoint(unit.transform.position);
                if (screenPos.x >= minPosition.x && screenPos.x <= maxPosition.x && screenPos.y >= minPosition.y &&
                    screenPos.y <= maxPosition.y)
                {
                    AddUnitToList(unit);
                }
            }
        }

        private void SingleSelection()
        {
            var ray = mainCamera.ScreenPointToRay(playerInput.MousePosition);
            if (Physics.Raycast(ray, out var hitInfo, 100f))
            {
                if (hitInfo.collider.TryGetComponent<Unit>(out var unit))
                {
                    AddUnitToList(unit);
                }
            }
        }

        private void AddUnitToList(Unit unit)
        {
            if (SelectedUnits.Contains(unit))
            {
                return;
            }

            SelectedUnits.Add(unit);
            unit.Select();
        }
    }
}
