using UnityEngine;

namespace DesignPatterns.Structural.Bridge
{
    public class MountainMiner : IMiner
    {
        public void Mine()
        {
            Debug.Log("MountainMiner Mine");
        }
    }
}