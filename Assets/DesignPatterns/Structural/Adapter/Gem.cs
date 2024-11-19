namespace DesignPatterns.Structural.Adapter
{
    public class Gem 
    {
        private float _value;

        public Gem(int value)
        {
            _value = value;
        }

        public float GetValue()
        {
            return _value;
        }
    }
}