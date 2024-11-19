using UnityEngine;

namespace DesignPatterns.Structural.Decorator
{
    public class DecoratorTester : MonoBehaviour
    {
        private void Start()
        {
            var ability = new Ability(5);
            var abilityAdvanced = new AbilityAdvanced(ability, 10);

            ability.Apply();
            abilityAdvanced.Apply();
        }
    }
}