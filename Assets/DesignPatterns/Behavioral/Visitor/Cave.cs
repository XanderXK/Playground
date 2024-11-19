namespace DesignPatterns.Behavioral.Visitor
{
    public class Cave: IPlace
    {
        public void Accept(IVisitor visitor)
        {
           visitor.Visit(this);
        }
    }
}