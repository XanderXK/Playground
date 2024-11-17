namespace DesignPatterns.Creational.AbstractFactory
{
    public interface ISpawnerFactory
    {
        public ICharacter SpawnPlayer();
        public ICharacter SpawnSlime();
        public IWorldItem SpawnWorldItem();
    }
}