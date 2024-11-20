using UnityEngine;

namespace DesignPatterns.Structural.Bridge
{
    public class BridgeTester : MonoBehaviour
    {
        private void Start()
        {
            Sender sender = new GolemSender(new CaveMiner());
            sender.Send();

            sender.SetMiner(new CaveMiner());
            sender.Send();

            sender = new SlimeSender(new CaveMiner());
            sender.Send();
        }
    }
}