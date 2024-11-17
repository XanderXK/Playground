using UnityEngine;

namespace DesignPatterns.Creational.AbstractFactory
{
    public class LocalSpawnFactory : ISpawnerFactory
    {
        public ICharacter SpawnPlayer()
        {
            var character = new GameObject("Player (Local)");
            var player = character.AddComponent<Character>();
            return player;
        }

        public ICharacter SpawnSlime()
        {
            var character = new GameObject("Slime (Local)");
            var slime = character.AddComponent<Character>();
            return slime;
        }

        public IWorldItem SpawnWorldItem()
        {
            var worldItem = new GameObject("WorldItem (Local)");
            var item = worldItem.AddComponent<WorldItem>();
            return item;
        }
    }
}