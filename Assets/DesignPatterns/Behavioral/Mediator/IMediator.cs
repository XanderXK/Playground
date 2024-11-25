using System.Collections.Generic;

namespace DesignPatterns.Behavioral.Mediator
{
    public interface IMediator
    {
        public List<Character> Characters { get; }
        public void Register(Character character);
        public void SendMessage(Character character, string message);
    }
}