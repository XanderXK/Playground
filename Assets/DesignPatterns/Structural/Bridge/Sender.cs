namespace DesignPatterns.Structural.Bridge
{
    public abstract class Sender
    {
        protected IMiner _miner;

        public Sender(IMiner miner)
        {
            _miner = miner;
        }

        public void SetMiner(IMiner miner)
        {
            _miner = miner;
        }

        public abstract void Send();
    }
}