namespace DesignPatterns.Behavioral.Memento
{
    public class Stats : IMemento
    {
        public int Health { get; private set; } = 100;
        public int Mana { get; private set; } = 10;


        public void TakeDamage(int damage)
        {
            Health -= damage;
        }

        public void UseMana(int mana)
        {
            Mana -= mana;
        }
        
        public object GetState()
        {
            return new StatsSaveData()
            {
                Health = Health,
                Mana = Mana
            };
        }

        public void SetState(object state)
        {
            var saveData = (StatsSaveData)state;
            Health = saveData.Health;
            Mana = saveData.Mana;
        }
    }
}