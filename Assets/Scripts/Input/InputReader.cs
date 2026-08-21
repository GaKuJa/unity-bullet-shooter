using UnityEngine;
using UnityEngine.InputSystem;

namespace Shooter.Input
{
    public class InputReader : MonoBehaviour, IInputReader
    {
        public Vector2 MoveDirection { get; private set; }
        public bool IsFiring { get; private set; }

        private void Update()
        {
            var keyboard = Keyboard.current;
            if (keyboard == null)
            {
                MoveDirection = Vector2.zero;
                IsFiring = false;
                return;
            }

            float x = 0f;
            float y = 0f;

            if (keyboard.aKey.isPressed || keyboard.leftArrowKey.isPressed) x -= 1f;
            if (keyboard.dKey.isPressed || keyboard.rightArrowKey.isPressed) x += 1f;
            if (keyboard.sKey.isPressed || keyboard.downArrowKey.isPressed) y -= 1f;
            if (keyboard.wKey.isPressed || keyboard.upArrowKey.isPressed) y += 1f;

            MoveDirection = new Vector2(x, y).normalized;
            IsFiring = keyboard.spaceKey.isPressed || keyboard.zKey.isPressed;
        }
    }
}
