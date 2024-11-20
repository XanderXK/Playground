namespace DesignPatterns.Creational.FactoryMethod
{
    public class SlimeConveyor: IConveyor
    {
        public IProduction Create()
        {
            return new Slime();
        }
    }
}