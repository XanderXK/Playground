using UnityEngine;

namespace DesignPatterns.Creational.FactoryMethod
{
    public class Slime:IProduction
    {
        public void Produce()
        {
            Debug.Log("Slime Produce");
        }
    }
}