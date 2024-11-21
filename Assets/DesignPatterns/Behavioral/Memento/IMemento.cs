namespace DesignPatterns.Behavioral.Memento
{
    public interface IMemento
    {
        public object GetState();
        public void SetState(object state);
    }
}