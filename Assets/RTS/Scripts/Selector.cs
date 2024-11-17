using System.Collections.Generic;
using UnityEngine;

namespace RTS
{
    public class Selector : MonoBehaviour
    {
        [SerializeField] private RectTransform selectionArea;
        [SerializeField] private LayerMask layerMask;

        private Camera _mainCamera;
        private Player _player;
        private PlayerInput _playerInput;
        private Vector2 _startPosition;
        public List<Unit> SelectedUnits { get; private set; }


        private void Awake()
        {
            _mainCamera = Camera.main;
            _playerInput = FindAnyObjectByType<PlayerInput>();
            SelectedUnits = new List<Unit>();
            _player = FindAnyObjectByType<Player>();
        }

        private void OnEnable()
        {
            _playerInput.OnPlayerSelectEnd += EndSelection;
            _playerInput.OnPlayerSelectStart += StartSelection;
        }

        private void StartSelection()
        {
            Deselect();
            selectionArea.gameObject.SetActive(true);
            _startPosition = _playerInput.MousePosition;
        }

        private void Deselect()
        {
            if (_playerInput.Adding)
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
            if (_playerInput.Selecting)
            {
                UpdateSelectionArea();
            }
        }

        private void UpdateSelectionArea()
        {
            var areaWidth = _playerInput.MousePosition.x - _startPosition.x;
            var areaHeight = _playerInput.MousePosition.y - _startPosition.y;

            selectionArea.sizeDelta = new Vector2(Mathf.Abs(areaWidth), Mathf.Abs(areaHeight));
            selectionArea.anchoredPosition = _startPosition + new Vector2(areaWidth / 2f, areaHeight / 2f);
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
            foreach (var unit in _player.PlayerUnits)
            {
                var screenPos = _mainCamera.WorldToScreenPoint(unit.transform.position);
                if (screenPos.x >= minPosition.x && screenPos.x <= maxPosition.x && screenPos.y >= minPosition.y &&
                    screenPos.y <= maxPosition.y)
                {
                    AddUnitToList(unit);
                }
            }
        }

        private void SingleSelection()
        {
            var ray = _mainCamera.ScreenPointToRay(_playerInput.MousePosition);
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
