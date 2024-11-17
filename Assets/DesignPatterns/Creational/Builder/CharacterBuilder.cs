using UnityEngine;

namespace DesignPatterns.Creational.Builder
{
    public class CharacterBuilder
    {
        private Character _character;
        private string _name;
        private Vector3 _position;
        private Quaternion _rotation;
        
        public Character Build()
        {
            _character = new GameObject().AddComponent<Character>();
            _character.name = _name;
            _character.transform.position = _position;
            _character.transform.rotation = _rotation;
            return _character;
        }
        
        public CharacterBuilder WithName(string name)
        {
            _name = name;
            return this;
        }
        
        public CharacterBuilder WithPosition(Vector3 position)
        {
            _position = position;
            return this;
        }
        
        public CharacterBuilder WithRotation(Quaternion rotation)
        {
            _rotation = rotation;
            return this;
        }
        
        public CharacterBuilder Reset()
        {
            _character = null;
            _name = null;
            _position = Vector3.zero;
            _rotation = Quaternion.identity;
            return this;
        }
    }
}