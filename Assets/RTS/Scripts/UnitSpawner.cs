using UnityEngine;
using UnityEngine.EventSystems;

namespace RTS
{
    public class UnitSpawner : Building, IPointerClickHandler
    {
        [SerializeField] private Unit _unitPrefab;
        [SerializeField] private Transform _spawnPoint;
        [SerializeField] private OwnerType _owner;


        private void SpawnUnit()
        {
            var unit = Instantiate(_unitPrefab, _spawnPoint.position, _spawnPoint.rotation);
            unit.SetUnit(_owner);
        }

        public void OnPointerClick(PointerEventData eventData)
        {
            if (eventData.button != PointerEventData.InputButton.Left)
            {
                return;
            }

            SpawnUnit();
        }
    }
}