namespace DesignPatterns.Creational.FactoryMethod
{
    public class GolemConveyor: IConveyor
    {
        public IProduction Create()
        {
            return new Golem();
        }
    }
}