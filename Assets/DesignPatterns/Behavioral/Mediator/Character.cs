using UnityEngine;

namespace DesignPatterns.Behavioral.Mediator
{
    public class Character
    {
        private readonly string _name;

        public Character(string name)
        {
            _name = name;
        }

        public void SendMessage(IMediator mediator, string message)
        {
            Debug.Log($"{_name}: {message}");
            mediator.SendMessage(this, message);
        }

        public void ReceiveMessage(Character sender, string message)
        {
            Debug.Log($"{_name} received message from {sender._name}: {message}");
        }
    }
}