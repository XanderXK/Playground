namespace DesignPatterns.Behavioral.Visitor
{
    public interface IVisitor
    {
        public void Visit(House house);
        public void Visit(Cave cave);
    }
}