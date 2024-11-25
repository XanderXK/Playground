using System.Collections.Generic;

namespace DesignPatterns.Behavioral.Mediator
{
    public class Mediator : IMediator
    {
        public List<Character> Characters { get; } = new();

        public void Register(Character character)
        {
            Characters.Add(character);
        }

        public void SendMessage(Character sender, string message)
        {
            foreach (var character in Characters)
            {
                if (sender == character)
                {
                    continue;
                }

                character.ReceiveMessage(sender, message);
            }
        }
    }
}