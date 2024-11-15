using System;
using UnityEngine;

namespace RTS
{
    public class Unit : MonoBehaviour, ITargetable
    {
        public static event Action<Unit> OnUnitSpawned;
        public static event Action<Unit> OnUnitDespawned;

        [SerializeField] private GameObject _selectObject;

        private Mover _mover;
        private Attacker _attacker;
        private Health _health;
        private OwnerType _owner;


        public void SetUnit(OwnerType unitOwner)
        {
            _mover = GetComponent<Mover>();
            _attacker = GetComponent<Attacker>();
            _health = GetComponent<Health>();
            _owner = unitOwner;
            OnUnitSpawned?.Invoke(this);
        }

        public void Select()
        {
            _selectObject.SetActive(true);
        }

        public void Deselect()
        {
            _selectObject.SetActive(false);
        }

        public void MoveTo(Vector3 position)
        {
            _mover.MoveToPosition(position);
        }

        public void TryAttack(ITargetable target)
        {
            Debug.Log(target);
            _mover.SetChaseTarget(target.GetTransform());
            _attacker.SetTarget(target);
        }

        public OwnerType GetOwner()
        {
            return _owner;
        }

        public Transform GetTransform()
        {
            return transform;
        }

        public void ApplyDamage(int damage)
        {
            _health.TakeDamage(damage);
        }

        private void OnDisable()
        {
            OnUnitDespawned?.Invoke(this);
        }
    }
}