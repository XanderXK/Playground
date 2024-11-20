using UnityEngine;

namespace DesignPatterns.Creational.FactoryMethod
{
    public class FactoryMethodTester : MonoBehaviour
    {
        private void Start()
        {
            IConveyor conveyor = new GolemConveyor();
            var golem = conveyor.Create();
            conveyor = new SlimeConveyor();
            var slime = conveyor.Create();

            golem.Produce();
            slime.Produce();
        }
    }
}