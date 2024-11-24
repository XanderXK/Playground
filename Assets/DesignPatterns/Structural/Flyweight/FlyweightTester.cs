using UnityEngine;

namespace DesignPatterns.Structural.Flyweight
{
    public class FlyweightTester : MonoBehaviour
    {
        private void Start()
        {
            var spawner = new Spawner();
            var animal1 = spawner.SpawnCharacter(CharacterType.Animal, Vector3.one);
            var animal2 = spawner.SpawnCharacter(CharacterType.Animal, Vector3.one * 2f);
            var monster1 = spawner.SpawnCharacter(CharacterType.Monster, Vector3.one * 3f);
            var monster2 = spawner.SpawnCharacter(CharacterType.Monster, Vector3.one * 5f);

            animal1.ShowInfo();
            animal2.ShowInfo();
            monster1.ShowInfo();
            monster2.ShowInfo();
        }
    }
}