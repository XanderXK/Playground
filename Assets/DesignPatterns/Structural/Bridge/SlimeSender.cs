using UnityEngine;

namespace DesignPatterns.Structural.Bridge
{
    public class SlimeSender : Sender
    {
        public SlimeSender(IMiner miner) : base(miner)
        {
        }

        public override void Send()
        {
            _miner.Mine();
            Debug.Log("SlimeSender Send");
        }
    }
}