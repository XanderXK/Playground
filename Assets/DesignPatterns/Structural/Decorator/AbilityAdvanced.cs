using UnityEngine;

namespace DesignPatterns.Structural.Decorator
{
    public class AbilityAdvanced : AbilityDecorator
    {
        private int _additionalDamage;

        public AbilityAdvanced(IAbility mainAbility, int additionalDamage) : base(mainAbility)
        {
            _mainAbility = mainAbility;
            _additionalDamage = additionalDamage;
        }

        public override int GetDamage()
        {
            var damage = base.GetDamage() + _additionalDamage;
            return damage;
        }

        public override void Apply()
        {
            Debug.Log($"Additional Damage: {GetDamage()}");
        }
    }
}