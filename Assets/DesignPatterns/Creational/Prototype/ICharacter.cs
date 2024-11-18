namespace DesignPatterns.Creational.Prototype
{
    public interface ICharacter
    {
        public string Name { get; set; }
        public ICharacter Clone();
    }
}