using UnityEngine;

namespace DesignPatterns.Behavioral.Command
{
    public class MoveForwardCommand : MoveCommand
    {
        public MoveForwardCommand(Transform goTransform) : base(goTransform)
        {
        }

        public override void Execute()
        {
            _goTransform.position += Vector3.forward;
        }

        public override void Undo()
        {
            _goTransform.position -= Vector3.forward;
        }
    }
}