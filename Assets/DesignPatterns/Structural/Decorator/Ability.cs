using UnityEngine;

namespace DesignPatterns.Structural.Decorator
{
    public class Ability : IAbility
    {
        private int _damage;
        
        public Ability(int damage)
        {
            _damage = damage;
        }

        public int GetDamage()
        {
            return _damage;
        }

        public void Apply()
        {
            Debug.Log($"Damage: {GetDamage()}");
        }
    }
}