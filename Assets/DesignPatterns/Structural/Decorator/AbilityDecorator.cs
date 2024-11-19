using UnityEngine;

namespace DesignPatterns.Structural.Decorator
{
    public abstract class AbilityDecorator: IAbility
    {
        protected IAbility _mainAbility;
        
        public AbilityDecorator(IAbility mainAbility)
        {
            _mainAbility = mainAbility;
        }
        
        public virtual int GetDamage()
        {
            return _mainAbility.GetDamage();
        }

        public virtual void Apply()
        {
            _mainAbility.Apply();
        }
    }
}