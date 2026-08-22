using Shooter.Input;
using UnityEngine;
using Zenject;

namespace Shooter.Test
{
    public class InputReaderLogger : MonoBehaviour
    {
        private IInputReader _inputReader;
        private Vector2 _lastLoggedDirection;
        private bool _lastLoggedFiring;

        [Inject]
        public void Construct(IInputReader inputReader)
        {
            _inputReader = inputReader;
        }

        private void Update()
        {
            if (_inputReader.MoveDirection != _lastLoggedDirection)
            {
                _lastLoggedDirection = _inputReader.MoveDirection;
                Debug.Log($"MoveDirection: {_lastLoggedDirection}");
            }

            if (_inputReader.IsFiring != _lastLoggedFiring)
            {
                _lastLoggedFiring = _inputReader.IsFiring;
                Debug.Log($"IsFiring: {_lastLoggedFiring}");
            }
        }
    }
}
