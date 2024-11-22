using System.Collections.Generic;
using UnityEngine;

namespace DesignPatterns.Structural.Composite
{
    public class ItemContainer : IComponent
    {
        private readonly string _name;
        private readonly List<IComponent> _components = new();

        public ItemContainer(string name)
        {
            _name = name;
        }

        public void Add(IComponent component)
        {
            _components.Add(component);
        }

        public void Remove(IComponent component)
        {
            _components.Remove(component);
        }

        public void Run()
        {
            Debug.Log($"Container: {_name}");
            _components.ForEach(c => c.Run());
        }
    }
}