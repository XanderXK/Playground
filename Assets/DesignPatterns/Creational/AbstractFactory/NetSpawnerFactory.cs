using UnityEngine;

namespace DesignPatterns.Creational.AbstractFactory
{
    public class NetSpawnerFactory: ISpawnerFactory
    {
        public ICharacter SpawnPlayer()
        {
            var character = new GameObject("Player (Net)");
            var player = character.AddComponent<Character>();
            return player;
        }

        public ICharacter SpawnSlime()
        {
            var character = new GameObject("Slime (Net)");
            var slime = character.AddComponent<Character>();
            return slime;
        }

        public IWorldItem SpawnWorldItem()
        {
            var worldItem = new GameObject("WorldItem (Net)");
            var item = worldItem.AddComponent<WorldItem>();
            return item;
        }
    }
}