using UnityEngine;

namespace DesignPatterns.Structural.Flyweight
{
    public class Character
    {
        private Vector3 _position;
        private Description _description;

        public Character(Vector3 position, Description description)
        {
            _position = position;
            _description = description;
        }

        public void ShowInfo()
        {
            Debug.Log($"Position: {_position}, Name: {_description.Name}, Text: {_description.Text}");
        }
    }
}