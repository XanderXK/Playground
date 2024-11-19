namespace DesignPatterns.Structural.Adapter
{
    public class AdapterForGems : Gem, ICurrency
    {
        public AdapterForGems(int value) : base(value)
        {
        }

        float ICurrency.GetValue() => base.GetValue() * 5;
    }
}