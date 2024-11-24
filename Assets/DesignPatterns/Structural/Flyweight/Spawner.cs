using System.Collections.Generic;
using UnityEngine;

namespace DesignPatterns.Structural.Flyweight
{
    public class Spawner
    {
        private readonly Dictionary<CharacterType, Description> _characterDescriptions = new();


        public Character SpawnCharacter(CharacterType characterType, Vector3 position)
        {
            if (_characterDescriptions.TryGetValue(characterType, out var description))
            {
                return new Character(position, description);
            }
            else
            {
                description = new Description(characterType.ToString(), "Some description");
                _characterDescriptions.Add(characterType, description);
                return new Character(position, description);
            }
        }
    }
}