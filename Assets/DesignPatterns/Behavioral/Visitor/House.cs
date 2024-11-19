namespace DesignPatterns.Behavioral.Visitor
{
    public class House : IPlace
    {
        public void Accept(IVisitor visitor)
        {
            visitor.Visit(this);
        }
    }
}