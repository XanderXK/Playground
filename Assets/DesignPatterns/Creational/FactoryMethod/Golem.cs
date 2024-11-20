using UnityEngine;

namespace DesignPatterns.Creational.FactoryMethod
{
    public class Golem: IProduction
    {
        public void Produce()
        {
            Debug.Log("Golem Produce");
        }
    }
}