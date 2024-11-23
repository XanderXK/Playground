namespace DesignPatterns.Behavioral.ChainOfResponsibility
{
    using UnityEngine;

    public class ChainOfResponsibilityTester : MonoBehaviour
    {
        private void Start()
        {
            var surfaceHandler = new GroundHandler();
            var waterHandler = new WaterHandler();
            surfaceHandler.SetNext(waterHandler);

            surfaceHandler.TryHandle("ground");
            surfaceHandler.TryHandle("water");
            surfaceHandler.TryHandle("grass");
        }
    }
}