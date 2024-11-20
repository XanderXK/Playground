using UnityEngine;

namespace DesignPatterns.Structural.Bridge
{
    public class GolemSender : Sender
    {
        public GolemSender(IMiner miner) : base(miner)
        {
        }

        public override void Send()
        {
            _miner.Mine();
            Debug.Log("GolemSender Send");
        }
    }
}