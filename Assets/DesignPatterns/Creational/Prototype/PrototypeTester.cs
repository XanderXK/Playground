using UnityEngine;

namespace DesignPatterns.Creational.Prototype
{
    public class PrototypeTester : MonoBehaviour
    {
        public void Start()
        {
            ICharacter slime = new Slime();
            slime.Name = "Awesome Slime";
            var clonedSlime = slime.Clone();
            Debug.Log(clonedSlime.Name);
        }
    }
}