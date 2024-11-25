using UnityEngine;

namespace DesignPatterns.Behavioral.Mediator
{
    public class MediatorTester : MonoBehaviour
    {
        private void Start()
        {
            var slime = new Character("Slime");
            var golem = new Character("Golem");
            var elemental = new Character("Elemental");

            var mediator = new Mediator();
            mediator.Register(slime);
            mediator.Register(golem);
            mediator.Register(elemental);

            slime.SendMessage(mediator, "Hello!");
        }
    }
}