using UnityEngine;

namespace DesignPatterns.Behavioral.Command
{
    public class MoveRightCommand : MoveCommand
    {
        public MoveRightCommand(Transform goTransform) : base(goTransform)
        {
        }

        public override void Execute()
        {
            _goTransform.position += Vector3.right;
        }

        public override void Undo()
        {
            _goTransform.position -= Vector3.right;
        }
    }
}