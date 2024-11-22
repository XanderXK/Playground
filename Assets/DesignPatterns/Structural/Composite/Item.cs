using UnityEngine;

namespace DesignPatterns.Structural.Composite
{
    public class Item : IComponent
    {
        private readonly string _name;

        public Item(string name)
        {
            _name = name;
        }

        public void Run()
        {
            Debug.Log($"Name: {_name}");
        }
    }
}