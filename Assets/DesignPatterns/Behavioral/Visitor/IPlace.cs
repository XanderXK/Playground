namespace DesignPatterns.Behavioral.Visitor
{
    public interface IPlace
    {
        public void Accept(IVisitor visitor);
    }
}