namespace DesignPatterns.Creational.Prototype
{
    public class Slime : ICharacter
    {
        public string Name { get; set; }

        public Slime()
        {
        }

        public Slime(Slime slime)
        {
            Name = slime.Name;
        }

        public ICharacter Clone()
        {
            return new Slime(this);
        }
    }
}