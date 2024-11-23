using UnityEngine;

namespace DesignPatterns.Behavioral.ChainOfResponsibility
{
    public class WaterHandler : SurfaceHandler
    {
        protected override bool CanHandle(string surface)
        {
            return surface == "water";
        }

        protected override void Run(string surface)
        {
            Debug.Log($"WaterHandler: {surface}");
        }
    }
}