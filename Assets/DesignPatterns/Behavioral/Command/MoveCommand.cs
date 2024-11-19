using UnityEngine;

namespace DesignPatterns.Behavioral.Command
{
    public abstract class MoveCommand
    {
        protected Transform _goTransform;

        protected MoveCommand(Transform goTransform)
        {
            _goTransform = goTransform;
        }

        public abstract void Execute();
        public abstract void Undo();
    }
}