using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace DesignPatterns.Behavioral.Command
{
    public class CommandTester : MonoBehaviour
    {
        private readonly Stack<MoveCommand> _moveCommands = new();

        private void Update()
        {
            if (Keyboard.current.wKey.wasPressedThisFrame)
            {
                MoveForward();
            }

            if (Keyboard.current.dKey.wasPressedThisFrame)
            {
                MoveRight();
            }

            if (Keyboard.current.cKey.wasPressedThisFrame)
            {
                Undo();
            }
        }

        private void MoveForward()
        {
            var command = new MoveForwardCommand(transform);
            command.Execute();
            _moveCommands.Push(command);
        }

        private void MoveRight()
        {
            var command = new MoveRightCommand(transform);
            command.Execute();
            _moveCommands.Push(command);
        }

        private void Undo()
        {
            if (_moveCommands.Count == 0)
            {
                return;
            }

            var command = _moveCommands.Pop();
            command.Undo();
        }
    }
}