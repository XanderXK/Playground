using UnityEngine;

namespace DesignPatterns.Structural.Bridge
{
    public class CaveMiner: IMiner
    {
        public void Mine()
        {
            Debug.Log("CaveMiner Mine");
        }
    }
}