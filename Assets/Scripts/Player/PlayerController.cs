using Shooter.Bullets;
using Shooter.Input;
using UnityEngine;
using UnityEngine.Serialization;
using Zenject;

namespace Shooter.Player
{
    public class PlayerController : MonoBehaviour
    {
        private IInputReader _inputReader;

        [FormerlySerializedAs("mover")]
        [SerializeField] private Mover _mover;

        [FormerlySerializedAs("shooter")]
        [SerializeField] private BulletShooter _shooter;

        [Inject]
        public void Construct(IInputReader inputReader)
        {
            _inputReader = inputReader;
        }

        private void Update()
        {
            _mover.Move(_inputReader.MoveDirection, Time.deltaTime);

            if (_inputReader.IsFiring)
            {
                _shooter.Fire();
            }
        }
    }
}
