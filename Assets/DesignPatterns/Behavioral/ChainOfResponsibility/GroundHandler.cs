using UnityEngine;

namespace DesignPatterns.Behavioral.ChainOfResponsibility
{
    public class GroundHandler : SurfaceHandler
    {
        protected override bool CanHandle(string surface)
        {
            return surface == "ground";
        }

        protected override void Run(string surface)
        {
            Debug.Log($"GroundHandler: {surface}");
        }
    }
}