namespace DesignPatterns.Structural.Adapter
{
    public class Gold : ICurrency
    {
        private float _value;

        public Gold(float value)
        {
            _value = value;
        }

        public float GetValue()
        {
            return _value;
        }
    }
}