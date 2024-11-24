namespace DesignPatterns.Structural.Flyweight
{
    public class Description
    {
        public string Name { get; private set; }
        public string Text { get; private set; }


        public Description(string name, string text)
        {
            Name = name;
            Text = text;
        }
    }
}