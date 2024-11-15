using System.Collections.Generic;
using UnityEngine;

namespace RTS
{
    public class Player : MonoBehaviour
    {
        public List<Unit> PlayerUnits { get; private set; }

        private void Awake()
        {
            PlayerUnits = new List<Unit>();
        }

        private void OnEnable()
        {
            Unit.OnUnitSpawned += UnitSpawned;
            Unit.OnUnitDespawned += UnitDespawned;
        }

        private void UnitSpawned(Unit unit)
        {
            if (unit.GetOwner() == OwnerType.Player)
            {
                PlayerUnits.Add(unit);
            }
        }

        private void UnitDespawned(Unit unit)
        {
            if (unit.GetOwner() == OwnerType.Player)
            {
                PlayerUnits.Remove(unit);
            }
        }

        private void OnDisable()
        {
            Unit.OnUnitSpawned -= UnitSpawned;
            Unit.OnUnitDespawned -= UnitDespawned;
        }
    }
}
