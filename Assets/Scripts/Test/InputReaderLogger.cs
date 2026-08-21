using Shooter.Input;
using UnityEngine;
using Zenject;

namespace Shooter.Test
{
    public class InputReaderLogger : MonoBehaviour
    {
        private InputReader inputReader;
        private Vector2 lastLoggedDirection;
        private bool lastLoggedFiring;

        [Inject]
        public void Construct(InputReader inputReader)
        {
            this.inputReader = inputReader;
        }

        private void Update()
        {
            if (inputReader.MoveDirection != lastLoggedDirection)
            {
                lastLoggedDirection = inputReader.MoveDirection;
                Debug.Log($"MoveDirection: {lastLoggedDirection}");
            }

            if (inputReader.IsFiring != lastLoggedFiring)
            {
                lastLoggedFiring = inputReader.IsFiring;
                Debug.Log($"IsFiring: {lastLoggedFiring}");
            }
        }
    }
}
